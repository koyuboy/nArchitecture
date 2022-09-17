using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.Technologies.Models;
using Kodlama.io.Devs.Application.Services.Repositories;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery: IRequest<TechnologyListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyListModel>
        {
            private readonly IMapper _mapper;
            private readonly ITechnologyRepository _technologyRepository;

            public GetListTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository)
            {
                _mapper = mapper;
                _technologyRepository = technologyRepository;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
                var technologies = await _technologyRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                var technologyListModel = _mapper.Map<TechnologyListModel>(technologies);

                return technologyListModel;
            }
        }
    }
}
