using AutoMapper;
using DataAccess.Entidades;
using Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionApi.App_Start
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Cliente, ClienteModel>().ReverseMap();
                config.CreateMap<Producto, ProductoModel>().ReverseMap();
                config.CreateMap<Venta, VentaModel>().ReverseMap();

                config.CreateMap<Factura, FacturaModel>()
                .ForMember(x => x.NombreCliente, m => m.MapFrom(a => a.Cliente.Nombre))
                .ReverseMap();

            });
        }
    }
}