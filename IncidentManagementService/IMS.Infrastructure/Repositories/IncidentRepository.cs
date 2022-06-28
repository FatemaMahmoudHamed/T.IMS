using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using IMS.Core.Interfaces.Repositories;
using IMS.Infrastructure.DbContexts;
using IMS.Core.Dtos;
using IMS.Infrastructure.Entities;
using IMS.Core.Entities;
using IMS.Infrastructure.Extensions;

namespace IMS.Infrastructure.Repositories
{
    public class IncidentRepository : RepositoryBase, IIncidentRepository
    {
        public IncidentRepository(CommandDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            : base(context, mapper, httpContextAccessor)
        {
        }

        public async Task<IncidentDto> GetAsync(int incidentId)
        {
            var user = await commandDb.Incidents
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == incidentId);

            return mapper.Map<IncidentDto>(user);

        }
        public async Task<QueryResultDto<IncidentDto>> GetAllAsync(IncidentQueryObject queryObject)
        {
            var result = new QueryResult<Incident>();

            var query = commandDb.Incidents
                //.Where(x => x.Id == queryObject.Id)
                .AsNoTracking()
                .AsQueryable();

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObject);

            result.Items = await query.ToListAsync();

            return mapper.Map<QueryResult<Incident>, QueryResultDto<IncidentDto>>(result);
        }
        public async Task AddAsync(IncidentDto incidentDto)
        {
            var incidentToAdd = mapper.Map<Incident>(incidentDto);
            incidentToAdd.Customer = null;
            incidentToAdd.Id = (await commandDb.Incidents.IgnoreQueryFilters().MaxAsync(c => (int?)c.Id) ?? 0) + 1;
            await commandDb.Incidents.AddAsync(incidentToAdd);
            await commandDb.SaveChangesAsync();
        }
    }
}