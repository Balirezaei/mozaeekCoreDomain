using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Domain;

namespace MozaeekCore.Mapper.Request
{
  
    public static class UnProcessedRequestMapping
    {
        public static UnProcessedRequestDto GetOperatorsSelectList(this UnProcessedRequest domain)
        {
            var mapper = new AutoMapper.Mapper(new MapperConfiguration(v => { }));
            return mapper.Map<UnProcessedRequestDto>(domain);
        }
    }
}