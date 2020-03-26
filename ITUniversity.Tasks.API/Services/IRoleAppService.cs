using System.Collections.Generic;

using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;

namespace ITUniversity.Tasks.API.Services
{
    public interface IRoleAppService : IApplicationService
    {
        ICollection<RoleDto> GetAll();
    }
}