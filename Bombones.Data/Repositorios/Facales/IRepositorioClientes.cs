using Bombones.BL;
using Bombones.BL.Dtos.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Data.Repositorios.Facales
{
    public interface IRepositorioClientes
    {
        List<ClienteListDto> GetLista();
        void Guardar(Cliente cliente);
        bool Existe(Cliente cliente);
        void Borrar(int clienteId);
        ClienteEditDto GetClientePorId(int clienteid);
        bool EstaRelacionado(ClienteListDto clienteListDto);
    }
}
