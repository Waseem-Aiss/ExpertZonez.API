using ExpertZonez.API.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ExpertZonez.API.Repositories.Interfaces
{
    public interface IRequestRepository
    {
        // Order Service
        Task<(ServiceRequest requestData, string serviceInfo)> CustSubmitRequest(CreateRequestDto dto);
       
    }
}

