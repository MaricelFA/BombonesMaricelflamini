using Bombones.BL;
using Bombones.BL.Dtos.Bombon;
using Bombones.BL.Dtos.Cliente;
using Bombones.BL.Dtos.DetalleVenta;
using Bombones.BL.Dtos.Localidad;
using Bombones.BL.Dtos.Provincia;
using Bombones.Servicios.Servicios;
using Bombones.Servicios.Servicios.Facales;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bombones.Windows.Helpers
{
    public class Helper

    {


        public static void CargarDatosComboProvincias(ref ComboBox combo)
        {
            IServiciosProvincias servicioProvincias = new Serviciosprovincias();
            var lista = servicioProvincias.GetLista();
            var defaultProvincia = new ProvinciaListDto
            {
                ProvinciaId = 0,
                NombreProvincia = "<Seleccionar Provincia>"
            };
            lista.Insert(0, defaultProvincia);
            combo.DisplayMember = "NombreProvincia";
            combo.ValueMember = "ProvinciaId";
            combo.DataSource = lista;
            combo.SelectedIndex = 0;
        }

        internal static void CargarDatosComboBombones(ref ComboBox cbBombon)
        {
            IServiciosBombones serviciosBombones = new ServiciosBombones();
            var lista = serviciosBombones.GetLista();
            var defaultBombon = new BombonListDto
            {
                BombonId = 0,
                NombreBombon = "<Seleccionar Bombón>"
            };
            lista.Insert(0, defaultBombon);
            cbBombon.DisplayMember = "NombreBombon";
            cbBombon.ValueMember = "BombonId";
            cbBombon.DataSource = lista;
            cbBombon.SelectedIndex = 0;
        }

        internal static void CargarDatosComboClientes(ref ComboBox cboCliente)
        {
            IServiciosClientes serviciosClientes = new ServiciosClientes();
            var lista = serviciosClientes.GetLista();
            var defaultCliente = new ClienteListDto
            {
                ClienteId = 0,
                NombreCompleto = "<Seleccionar Cliente>"
            };
            lista.Insert(0, defaultCliente);
            cboCliente.DisplayMember = "NombreCompleto";
            cboCliente.ValueMember = "ClienteId";
            cboCliente.DataSource = lista;
            cboCliente.SelectedIndex = 0;
        }

        internal static void CargarDatosComboTipoChocolate(ref ComboBox cbTipoChocolate)
        {
            IServiciosTiposDeChocolate serviciosTiposDeChocolate = new ServiciosTiposDeChocolate();
            var lista = serviciosTiposDeChocolate.GetLista();
            var defaultTipoChocolate = new TipoChocolate
            {
                TipoChocolateId = 0,
                NombreTipoChocolate = "<Seleccionar Tipo de Chocolate>"
            };
            lista.Insert(0, defaultTipoChocolate);
            cbTipoChocolate.DisplayMember = "NombreTipoChocolate";
            cbTipoChocolate.ValueMember = "TipoChocolateId";
            cbTipoChocolate.DataSource = lista;
            cbTipoChocolate.SelectedIndex = 0;
        }

        internal static void CargarDatosComboTipoRelleno(ref ComboBox cbTipoRelleno)
        {
            IServiciosTipodeRelleno serviciosTipodeRelleno = new ServiciosTipodeRelleno();
            var lista = serviciosTipodeRelleno.GetLista();
            var defaultTipoRelleno = new TipodeRelleno
            {
                TipoRellenoId = 0,
                NombreTipoRelleno = "<Seleccionar Tipo de Relleno>"
            };
            lista.Insert(0, defaultTipoRelleno);
            cbTipoRelleno.DisplayMember = "NombreTipoRelleno";
            cbTipoRelleno.ValueMember = "TipoRellenoId";
            cbTipoRelleno.DataSource = lista;
            cbTipoRelleno.SelectedIndex = 0;
        }

        internal static void CargarDatosComboTipoNuez(ref ComboBox cbTipoNuez)
        {
            IServiciosTipodeNuez serviciosTiposdeNuez = new ServiciosTipodeNuez();
            var lista = serviciosTiposdeNuez.GetLista();
            var defaultTipoNuez = new TipodeNuez
            {
                TipoDeNuezId = 0,
                NombreTipoDeNuez = "<Seleccionar Tipo de Nuez>"
            };
            lista.Insert(0, defaultTipoNuez);
            cbTipoNuez.DisplayMember = "NombreTipoDeNuez";
            cbTipoNuez.ValueMember = "TipoDeNuezId";
            cbTipoNuez.DataSource = lista;
            cbTipoNuez.SelectedIndex = 0;
        }

        internal static List<DetalleVentaListDto> ConstruirListaItemsListDto(List<DetalleVentaEditDto> detalleVentas)
        {
            var listaDto = new List<DetalleVentaListDto>();
            foreach (var item in detalleVentas)
            {
                var itemDto = new DetalleVentaListDto()
                {
                    DetalleVentaId = item.DetalleVentaId,
                    NombreBombon = item.bombon.NombreBombon,
                    Precio = item.Costo,
                    Cantidad = item.Cantidad
                };
                listaDto.Add(itemDto);
            }

            return listaDto;
        }

        internal static void CargarDatosComboLocalidad(ref ComboBox combo, ProvinciaListDto provincia)
        {
            IServiciosLocalidades serviciosLocalidades = new ServiciosLocalidades();
            var lista = serviciosLocalidades.GetLista(provincia);
            var defaultLocalidad = new LocalidadListDto
            {
                LocalidadId = 0,
                NombreLocalidad = "<Seleccionar Localidad>"
            };
            lista.Insert(0, defaultLocalidad);
            combo.DisplayMember = "NombreLocalidad";
            combo.ValueMember = "LocalidadId";
            combo.DataSource = lista;
            combo.SelectedIndex = 0;
        }

        internal static void CargarDatosComboTipoDni(ref ComboBox comboBoxTipoDeDni)
        {
            IServiciosTiposDedocumentos serviciosTiposDedocumentos = new ServiciosTiposDeDocumentos();
            var lista = serviciosTiposDedocumentos.GetLista();
            var defaultTipoDoc = new TipoDeDocumento
            {
                TipoDeDocumentoId = 0,
                Descripcion = "<Seleccionar Tipo de Documento>"
            };
            lista.Insert(0, defaultTipoDoc);
            comboBoxTipoDeDni.DisplayMember = "Descripcion";
            comboBoxTipoDeDni.ValueMember = "TipoDeDocuemntoId";
            comboBoxTipoDeDni.DataSource = lista;
            comboBoxTipoDeDni.SelectedIndex = 0;
        }
    }
}

