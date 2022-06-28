using AutoMapper;
using IMS.Infrastructure.DbContexts;
using IMS.Infrastructure.Repositories;
using IMS.ServiceInterface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IMS.UnitTests
{
    public class ServiceHelper
    {
        public ServiceHelper(CommandDbContext commandDbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            CommadDbContext = commandDbContext;
            Mapper = mapper;
            HttpContextAccessor = httpContextAccessor;
        }

        public CommandDbContext CommadDbContext { get; private set; }

        public IMapper Mapper { get; private set; }

        public IHttpContextAccessor HttpContextAccessor { get; private set; }


        public CustomerService CreateCustomerService(Guid userId = default)
        {
            UpdateLoggedInUser(userId);

            var partyRepository = new CustomerRepository(CommadDbContext, Mapper, HttpContextAccessor);
            return new CustomerService(partyRepository);
        }
        public IncidentService CreateIncidentService(Guid userId = default)
        {
            UpdateLoggedInUser(userId);

            var incidentRepository = new IncidentRepository(CommadDbContext, Mapper, HttpContextAccessor);
            return new IncidentService(incidentRepository);
        }


        private void UpdateLoggedInUser(Guid userId)
        {
            if (userId == Guid.Empty)
            {
                return;
            }

            var httpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", userId.ToString()),
                }, JwtBearerDefaults.AuthenticationScheme))
            };

            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(m => m.HttpContext).Returns(httpContext);
            HttpContextAccessor = httpContextAccessor.Object;
        }
    }
}
