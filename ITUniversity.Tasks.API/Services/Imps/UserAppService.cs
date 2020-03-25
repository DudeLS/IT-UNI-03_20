using AutoMapper;

using ITUniversity.Tasks.API.Services.Dto;
using ITUniversity.Tasks.Entities;
using ITUniversity.Tasks.Repositories;

namespace ITUniversity.Tasks.API.Services.Imps
{
    /// <summary>
    /// Сервис для работы с пользователями
    /// </summary>
    public class UserAppService : IUserAppService
    {
        private readonly IUserRepository userRepository;

        private readonly IMapper mapper;

        /// <summary>
        /// Инициализировать экземпляр <see cref="UserAppService"/>
        /// </summary>
        /// <param name="userRepository">Репозиторий пользователей</param>
        /// <param name="mapper">Маппер</param>
        public UserAppService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
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
        public bool IsValidPassword(UserDto dto, string password)
        {
            var entity = userRepository.Get(dto.Id);
            return entity.Password == password;
        }
    }
}