using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using ITUniversity.Application.Services;
using ITUniversity.Runtime.Session;
using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.Repositories;

namespace ITUniversity.Tasks.API.Services.Imps
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public class UserAppService : ApplicationService, IUserAppService
    {
        private readonly IUserRepository userRepository;

        private readonly IRoleRepository roleRepository;

        private readonly IUserManager userManager;

        private readonly IMapper mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="UserAppService"/>
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователей</param>
        /// <param name="roleRepository"></param>
        /// <param name="userManager"></param>
        /// <param name="mapper">Маппер</param>
        public UserAppService(
            IUserRepository userRepository,
            IRoleRepository roleRepository,
            IUserManager userManager,
            IMapper mapper,
            IAppSession session)
            : base(session)
        {
            this.userRepository = userRepository;
            this.roleRepository = roleRepository;
            this.userManager = userManager;
            this.mapper = mapper;
        }

        /// <inheritdoc/>
        public UserDto Create(CreateUserDto dto)
        {
            var entity = mapper.Map<User>(dto);
            userRepository.Save(entity);
            return mapper.Map<UserDto>(entity);
        }

        /// <inheritdoc/>
        public UserDto Update(UpdateUserDto dto)
        {
            var user = userRepository.Get(dto.Id);
            user.Email = dto.Email;
            if (dto.RoleId.HasValue)
            {
                var role = roleRepository.Get(dto.RoleId.Value);
                user.Role = role;
            }
            return mapper.Map<UserDto>(user);
        }

        /// <inheritdoc/>
        public UserDto Get(int id)
        {
            var entity = userRepository.Get(id);
            return mapper.Map<UserDto>(entity);
        }

        /// <inheritdoc/>
        public UserDto Get(string login)
        {
            var entity = userRepository.FirstOrDefault(e => e.Login == login);
            return mapper.Map<UserDto>(entity);
        }

        /// <inheritdoc/>
        public UserDto Get(string login, string password)
        {
            var entity = userRepository.FirstOrDefault(e => e.Login == login && e.Password == password);
            return mapper.Map<UserDto>(entity);
        }

        /// <inheritdoc/>
        public ICollection<UserDto> GetAll()
        {
            var entities = userRepository.GetAllList();
            return mapper.Map<ICollection<UserDto>>(entities);
        }

        /// <inheritdoc/>
        public bool IsValidPassword(UserDto dto, string password)
        {
            var entity = userRepository.Get(dto.Id);
            return entity.Password == password;
        }

        /// <inheritdoc/>
        public async Task<bool> Block(int id)
        {
            return await userManager.Block(id);
        }

        /// <inheritdoc/>
        public async Task<bool> FreeLogin(string login)
        {
            return await userManager.FreeLogin(login);
        }
    }
}