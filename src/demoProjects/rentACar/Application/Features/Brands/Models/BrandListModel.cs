using Core.Persistence.Paging;
using RentACar.Application.Features.Brands.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Brands.Models
{
    public class BrandListModel:BasePageableModel
    {
        public IList<BrandListDto> Items { get; set; }
    }
}
