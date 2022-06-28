using IMS.Core.Dtos;
using IMS.Core.Enums;
using IMS.Core.Interfaces.Repositories;
using IMS.Core.Interfaces.Services;
using IMS.Core.Models;
using IMS.Infrastructure.Entities;
using IMS.ServiceInterface.Validators.Others;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IMS.ServiceInterface
{
    public class IncidentService : IIncidentService
    {
        private readonly IIncidentRepository _IncidentRepository;

        public IncidentService(IIncidentRepository IncidentRepository
            )
        {
            _IncidentRepository = IncidentRepository;
        }

        public async Task<ReturnResult<IncidentDto>> GetAsync(int id)
        {
            try
            {
                var entitiy = await _IncidentRepository.GetAsync(id);

                return new ReturnResult<IncidentDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entitiy
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult<IncidentDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }


                };
            }
        }
        public async Task<ReturnResult<QueryResultDto<IncidentDto>>> GetAllAsync(IncidentQueryObject queryObject)
        {
            try
            {
                var entities = await _IncidentRepository.GetAllAsync(queryObject);

                return new ReturnResult<QueryResultDto<IncidentDto>>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status200OK,
                    Data = entities
                };
            }
            catch (Exception ex)
            {
                return new ReturnResult<QueryResultDto<IncidentDto>>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }

        public async Task<ReturnResult<IncidentDto>> AddAsync(IncidentDto model)
        {
            try
            {
                var errors = new List<string>();
                var validationResult = ValidationResult.CheckModelValidation(new IncidentValidator(), model);
                if (!validationResult.IsValid)
                {
                    errors.AddRange(validationResult.Errors);
                    if (errors.Any())
                    {
                        return new ReturnResult<IncidentDto>
                        {
                            IsSuccess = false,
                            StatusCode = HttpStatuses.Status400BadRequest,
                            ErrorList = errors,
                            Data = null
                        };
                    }
                }

                else
                {
                    await _IncidentRepository.AddAsync(model);
                }

                return new ReturnResult<IncidentDto>
                {
                    IsSuccess = true,
                    StatusCode = HttpStatuses.Status201Created,
                    Data = model
                };
            }
            catch (Exception ex)
            {

                return new ReturnResult<IncidentDto>
                {
                    IsSuccess = false,
                    StatusCode = HttpStatuses.Status500InternalServerError,
                    ErrorList = new List<string> { "Failed to add data" }

                };
            }
        }


    }
}
