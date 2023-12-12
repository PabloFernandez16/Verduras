using AutoMapper;
using WS_VentaVerduras.Models;
using WS_VentaVerduras.Models.ViewModels;

namespace WS_VentaVerduras.Mappers
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<ClienteDTO, Cliente>(); 
        }
    }
    //https://www.youtube.com/watch?v=pr_pemcmVAs 
}
