using Bombones.BL;
using Bombones.BL.Dtos.Bombon;
using Bombones.Data.Repositorios.Facales;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios
{
    public class RepositorioBombones : IRepositorioBombones
    {
        private readonly SqlConnection _conexion;
        private IRepositorioTipodeNuez _repositorioTipoDeNuez;
        private IRepositorioTipodeRelleno _repositorioTipodeRelleno;
        private IRepositorioTiposDeChocolate _repositorioTipoDeChocolate;
        private SqlTransaction _tran;

        public RepositorioBombones(SqlConnection sqlConnection, IRepositorioTipodeNuez repositorioTipodeNuez, IRepositorioTipodeRelleno repositorioTipodeRelleno, IRepositorioTiposDeChocolate repositorioTiposDeChocolate)
        {
            _conexion = sqlConnection;
            _repositorioTipoDeNuez = repositorioTipodeNuez;
            _repositorioTipodeRelleno = repositorioTipodeRelleno;
            _repositorioTipoDeChocolate = repositorioTiposDeChocolate;
        }

        public RepositorioBombones(SqlConnection sqlConnection)
        {
            _conexion = sqlConnection;
        }


        public void Borrar(int bombonId)
        {
            try
            {
                var cadenaComando = "DELETE FROM Bombones WHERE BombonId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", bombonId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                if (e.Message.Contains("REFERENCE"))
                {
                    throw new Exception("Registro con datos asociados... Baja denegada");
                }

            }
        }

        public bool EstaRelacionado(BombonListDto bombonListDto)
        {

            try
            {
                string cadenaComando = "SELECT * FROM DetallesVentas WHERE  BombonId=@Id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@Id", bombonListDto.BombonId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }



           



            //if (reader.HasRows == false)
            //{
            //    string cadenaComando2 = "SELECT * FROM ItemsCajas WHERE  BombonId=@Id";
            //    SqlCommand comando2 = new SqlCommand(cadenaComando2, _conexion);
            //    comando.Parameters.AddWithValue("@Id", bombonListDto.BombonId);
            //    SqlDataReader reader2 = comando2.ExecuteReader();

            //    return reader2.HasRows;
            //}
            //else
            //{
            //    return reader.HasRows;
            //}

        }

        public bool Existe(Bombon bombon)
        {
            if (bombon.BombonId == 0)
            {
                string cadenaComando = "SELECT * FROM Bombones WHERE  NombreBombon=@nombre";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nombre", bombon.NombreBombon);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;
            }
            else
            {

                string cadenaComando = "SELECT * FROM Bombones WHERE  NombreBombon=@nombre AND BombonId<>@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@nombre", bombon.NombreBombon);
                comando.Parameters.AddWithValue("@id", bombon.BombonId);
                SqlDataReader reader = comando.ExecuteReader();
                return reader.HasRows;

            }
        }

        public BombonEditDto GetBombonPorId(int bombonId)
        {
            BombonEditDto bombon = null;
            try
            {

                string cadenaComando = "SELECT BombonId, NombreBombon, TipoChocolateId, TipoDeNuezId, TipoRellenoId, Descripcion, Costo, CantidadEnExistencia FROM Bombones WHERE BombonId=@id";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                comando.Parameters.AddWithValue("@id", bombonId);
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    bombon = ConstruirBombonEditDto(reader);
                }

                reader.Close();
                return bombon;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private BombonEditDto ConstruirBombonEditDto(SqlDataReader reader)
        {
            _repositorioTipoDeNuez = new RepositorioTipoDeNuez(_conexion);
            _repositorioTipoDeChocolate = new RepositorioTiposDeChocolate(_conexion);
            _repositorioTipodeRelleno = new RepositorioTipodeRelleno(_conexion);

            return new BombonEditDto
            {
                BombonId = reader.GetInt32(0),
                NombreBombon = reader.GetString(1),
                tipoChocolate = _repositorioTipoDeChocolate.GetTipoChocolatePorId(reader.GetInt32(2)),
                tipodeNuez = _repositorioTipoDeNuez.GetTipoDeNuezPorId(reader.GetInt32(3)),
                tipodeRelleno = _repositorioTipodeRelleno.GetTipoRellenoPorId(reader.GetInt32(4)),
                Descripcion = reader.GetString(5),
                Costo = reader.GetDecimal(6),
                CantidadEnExistencia = reader.GetInt32(7)
            };
        }

        public List<BombonListDto> GetLista()
        {
            List<BombonListDto> lista = new List<BombonListDto>();
            try
            {
                string cadenaComando = "SELECT BombonId, NombreBombon, NombreTipoChocolate, NombreTipoDeNuez," +
                    " NombreTipoRelleno, Costo, CantidadEnExistencia  FROM Bombones B INNER JOIN TiposDeRelleno " +
                    "TR ON B.TipoRellenoId = TR.TipoRellenoId INNER JOIN TiposDEChocolate" +
                    " TC ON B.TipoChocolateId = TC.TipoChocolateId INNER JOIN TipoDeNuez TN on B.TipoDeNuezId=TN.TipoDeNuezId ";
                SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    var bombonDto = ConstruirBombonListDto(reader);
                    lista.Add(bombonDto);
                }

                reader.Close();
                return lista;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        private BombonListDto ConstruirBombonListDto(SqlDataReader reader)
        {
            BombonListDto bombonListDto = new BombonListDto();
            bombonListDto.BombonId = reader.GetInt32(0);
            bombonListDto.NombreBombon = reader.GetString(1);
            bombonListDto.NombreTipoChocolate = reader.GetString(2);
            bombonListDto.NombreTipoDeNuez = reader.GetString(3);
            bombonListDto.NombreTipoRelleno = reader.GetString(4);
            bombonListDto.Costo = reader.GetDecimal(5);
            bombonListDto.CantidadEnExistencia = reader.GetInt32(6);
            return bombonListDto;
        }

        public void Guardar(Bombon bombon)
        {
            if (bombon.BombonId == 0)
            {

                try
                {
                    string cadenaComando = "INSERT INTO Bombones ( NombreBombon, TipoChocolateId, TipoDeNuezId, TipoRellenoId, Descripcion, Costo, CantidadEnExistencia) VALUES(@nombre,@tipochoc, @tiponuez, @tiporelleno,@descripcion, @costo, @cantidad)";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", bombon.NombreBombon);
                    comando.Parameters.AddWithValue("@tipochoc", bombon.TipoChocolateId);
                    comando.Parameters.AddWithValue("@tiponuez", bombon.TipodeNuezId);
                    comando.Parameters.AddWithValue("@tiporelleno", bombon.TipodeRellenoId);
                    comando.Parameters.AddWithValue("@descripcion", bombon.Descripcion);
                    comando.Parameters.AddWithValue("@costo", bombon.Costo);
                    comando.Parameters.AddWithValue("@cantidad", bombon.CantidadEnExistencia);
                    comando.ExecuteNonQuery();
                    cadenaComando = "SELECT @@IDENTITY";
                    comando = new SqlCommand(cadenaComando, _conexion);
                    bombon.BombonId = (int)(decimal)comando.ExecuteScalar();

                }
                catch (Exception e)
                {
                    if (e.Message.Contains("IX_"))
                    {
                        throw new Exception("Registro duplicado...");
                    }
                    throw new Exception("Error");
                }

            }
            else
            {

                try
                {
                    string cadenaComando = "UPDATE Bombones SET NombreBombon=@nombre,TipoChocolateId=@tipochoc,TipodeNuezId= @tiponuez,TipoRellenoId= @tiporelleno,Descripcion=@descripcion,Costo= @costo,CantidadEnExistencia= @cantidad WHERE BombonId = @id";
                    SqlCommand comando = new SqlCommand(cadenaComando, _conexion);
                    comando.Parameters.AddWithValue("@nombre", bombon.NombreBombon);
                    comando.Parameters.AddWithValue("@tipochoc", bombon.TipoChocolateId);
                    comando.Parameters.AddWithValue("@tiponuez", bombon.TipodeNuezId);
                    comando.Parameters.AddWithValue("@tiporelleno", bombon.TipodeRellenoId);
                    comando.Parameters.AddWithValue("@descripcion", bombon.Descripcion);
                    comando.Parameters.AddWithValue("@costo", bombon.Costo);
                    comando.Parameters.AddWithValue("@cantidad", bombon.CantidadEnExistencia);
                    comando.Parameters.AddWithValue("@id", bombon.BombonId);
                    comando.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    if (e.Message.Contains("IX_"))
                    {
                        throw new Exception("Registro duplicado...");
                    }
                    throw new Exception("Error");
                }

            }
        }

        public void ActualizarStock(Bombon bombon, int v)
        {
            try
            {
                string cadenaComando = "UPDATE Bombones SET CantidadEnExistencia=CantidadEnExistencia+@cant WHERE BombonId=@id";
                var comando = new SqlCommand(cadenaComando, _conexion, _tran);
                comando.Parameters.AddWithValue("@cant", bombon.CantidadEnExistencia);
                comando.Parameters.AddWithValue("@id", bombon.BombonId);
                comando.ExecuteNonQuery();
            }
            catch (Exception e)
            {

                throw new Exception("Error al actualizar el stock de bombones");
            }
        }
    }
}
