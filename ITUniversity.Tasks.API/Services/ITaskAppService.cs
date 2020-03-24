using ITUniversity.Application.Services;
using ITUniversity.Tasks.API.Services.Dto;

namespace ITUniversity.Tasks.API.Services
{
    public interface ITaskAppService : IApplicationService
    {
        TaskDto Create(TaskCreateDto task);

        TaskDto Update(TaskUpdateDto task);

        void Delete(long id);

        TaskDto Get(long id);
    }
}