using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Core.QueryHandler;
using MozaeekCore.Domain.ExecutiveTechs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MozaeekCore.ApplicationService.Query
{
    public class GetExecutiveTechnicianByIdQueryHandler : IBaseAsyncQueryHandler<FindByKey, ExecutiveTechnicianDto>
    {
        private readonly IExecutiveTechnicianRepository repository;

        public GetExecutiveTechnicianByIdQueryHandler(IExecutiveTechnicianRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ExecutiveTechnicianDto> HandleAsync(FindByKey query)
        {
            var res = await repository.Find(query.Id);
            return new ExecutiveTechnicianDto()
            {
                FirstName=res.FirstName,
                LastName=res.LastName,
                NationalCode=res.NationalCode,
                Id=res.Id
            };
        }
    }
}
