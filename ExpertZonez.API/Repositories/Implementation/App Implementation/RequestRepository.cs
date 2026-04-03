using ExpertZonez.API.Data;
using ExpertZonez.API.Models.DTOs;
using ExpertZonez.API.Models.Enums;
using ExpertZonez.API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpertZonez.API.Repositories.Implementation
{
    public class RequestRepository : IRequestRepository
    {
        private readonly AppDbContext _dbContext;
        public RequestRepository(AppDbContext dbContext )
        {
            _dbContext = dbContext; 
        }


        public async Task<(ServiceRequest requestData, string serviceInfo)> CustSubmitRequest(CreateRequestDto dto)
        {
            var serviceExists = await _dbContext.Services.AnyAsync(s => s.serviceId == dto.serviceId);
            if (!serviceExists)
            {
                return (null, "service Not Available");
            }
            else
            {
                var newRequest = new ServiceRequest
                {
                    serviceId = dto.serviceId,
                    custName = dto.custName,
                    custPhoneNumber = dto.custPhoneNumber,
                    custLocation = dto.custLocation,
                    serviceDateAndTIme = dto.serviceDateAndTIme,
                    requestStatus = AssignmentStatus.Pending
                };

                _dbContext.ServiceRequests.Add(newRequest);
                await _dbContext.SaveChangesAsync();

                return (newRequest, "Service Requested");
            }

        }
    }
}
