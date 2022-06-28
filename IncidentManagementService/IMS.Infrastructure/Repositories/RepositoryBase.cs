using AutoMapper;
using Microsoft.AspNetCore.Http;
using IMS.Infrastructure.DbContexts;

namespace IMS.Infrastructure.Repositories
{
    public abstract class RepositoryBase
    {
        protected IMapper mapper;
        protected CommandDbContext commandDb;

        public RepositoryBase(CommandDbContext context, IMapper mapperConfig, IHttpContextAccessor httpContextAccessor)
        {
            commandDb = context;
            mapper = mapperConfig;
        }
    }

}
