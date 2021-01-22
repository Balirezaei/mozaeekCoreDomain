using MozaeekCore.ApplicationService.Contract;
using MozaeekCore.Domain.BasicInfo;

namespace MozaeekCore.Mapper
{
    public static class BasicInfoProfile
    {
        public static LableDto GetLableDto(this Lable domain)
        {
            return new LableDto()
            {
                Title = domain.Title
            };
        }

        public static RequestActDto GetRequestActDto(this RequestAct domain)
        {
            return new RequestActDto()
            {
                Title = domain.Title
            };
        }
        public static RequestOrgDto GetRequestOrgDto(this RequestOrg domain)
        {
            return new RequestOrgDto()
            {
                Title = domain.Title
            };
        }
        public static RequestTargetDto GetRequestTargetDto(this RequestTarget domain)
        {
            return new RequestTargetDto()
            {
                Title = domain.Title
            };
        }
        public static PointDto GetPointDto(this Point domain)
        {
            return new PointDto()
            {
                Title = domain.Title
            };
        }
        public static SubjectDto GetSubjectDto(this Subject domain)
        {
            return new SubjectDto()
            {
                Title = domain.Title
            };
        }
    }
}