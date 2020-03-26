using System.Collections.Generic;

using AutoMapper;

using ITUniversity.Application.Services;
using ITUniversity.Runtime.Session;
using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Repositories;

namespace ITUniversity.Tasks.API.Services.Imps
{
    public class RoleAppService : ApplicationService, IRoleAppService
    {
        private readonly IRoleRepository roleRepository;

        private readonly IMapper mapper;

        public RoleAppService(IRoleRepository roleRepository, IMapper mapper, IAppSession session)
            : base(session)
        {
            this.mapper = mapper;
            this.roleRepository = roleRepository;
        }

        public ICollection<RoleDto> GetAll()
        {
            var entities = roleRepository.GetAllList();
            return mapper.Map<ICollection<RoleDto>>(entities);
        }
    }
}