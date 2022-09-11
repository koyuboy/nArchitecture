using Core.Persistence.Repositories;
using RentACar.Application.Services.Repositories;
using RentACar.Domain.Entities;
using RentACar.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories
{
    public class ModelRepository : EfRepositoryBase<Model, BaseDbContext>, IModelRepository
    {
        public ModelRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
