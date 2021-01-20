using AutoMapper;

namespace MozaeekCore.Mapper.Request
{
    public class MapperWrapper
    {
        private readonly IMapper _mapper;
        public MapperWrapper(IMapper mapper)
        {
            _mapper = mapper;
        }


    }
}