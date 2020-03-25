using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Managers;
using ITUniversity.Tasks.Repositories;

namespace ITUniversity.Tasks.API.Services.Imps
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository userRepository;

        private readonly IUserManager userManager;

        private readonly IMapper mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="UserAppService"/>
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователей</param>
        /// <param name="userManager"></param>
        /// <param name="mapper">Маппер</param>
        public UserAppService(
            IUserRepository userRepository,
            IUserManager userManager,
            IMapper mapper)
        {
            this.userRepository = userRepository;
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