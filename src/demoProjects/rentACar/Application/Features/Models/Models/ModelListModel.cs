using Core.Persistence.Paging;
using RentACar.Application.Features.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Models.Models
{
    public class ModelListModel: BasePageableModel
    {
        public IList<ModelListDto> Items { get; set; }
    }
}
