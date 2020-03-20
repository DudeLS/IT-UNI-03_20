using ITUniversity.Application.Services;

namespace ITUniversity.Tasks.Application.Services
{
    public interface ITaskAppService : IApplicationService
    {
        void Test();

        string GetTest();

        void TestString(string str);

        string GetTestString(string str);

        void Class(Test test);

        Test GetClass(Test test);
    }

    public class Test
    {
        public string Name { get; set; }

        public long Age { get; set; }
    }
}