using AutoMapper;
using IMS.Infrastructure;
using IMS.Infrastructure.DbContexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Security.Claims;

namespace IMS.UnitTests
{
    public abstract class BaseUnitTest
    {
        protected CommandDbContext Db { get; private set; }

        protected ServiceHelper ServiceHelper { get; private set; }

        public IDistributedCache _cache { get; private set; }

        private static string _dbName { get; set; }


        public BaseUnitTest(string dbName = "IMSDB")
        {
            _dbName = dbName;
            // Setup the required services.
            var options = Setup();

            // Create db context.
            Db = new CommandDbContext(options);

            //Setup();

            // Initialize db.
            SeedData.Initialize(Db, true);

            // Initialize service helper.
            InitializeServiceHelper();
        }

        private static DbContextOptions<CommandDbContext> Setup()
        {
            var services = new ServiceCollection();

            services
                .AddEntityFrameworkInMemoryDatabase()
                .AddDbContext<CommandDbContext>((sp, options) =>
                {
                    options.UseInMemoryDatabase(_dbName);
                    options.UseInternalServiceProvider(sp);
                }).AddLogging();

           
            var serviceProvider = services.BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<CommandDbContext>()
                .UseInMemoryDatabase(_dbName)
                .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        private void InitializeServiceHelper()
        {
            var mapper = new MapperConfiguration(m => m.AddMaps(typeof(   ).Assembly)).CreateMapper();
            //var mapper = //new Mock<IMapper>().Object;
            var httpContext = new DefaultHttpContext()
            {
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                {
                    new Claim("id", TestUsers.AdminId.ToString()),
                }, JwtBearerDefaults.AuthenticationScheme))
            };
            var httpContextAccessor = new Mock<IHttpContextAccessor>();
            httpContextAccessor.Setup(m => m.HttpContext).Returns(httpContext);

            ServiceHelper = new ServiceHelper(Db, mapper, httpContextAccessor.Object);
        }
    }
}
