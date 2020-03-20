using ITUniversity.Application.Services;

namespace ITUniversity.Tasks.API.Services
{
    public interface ITaskAppService : IApplicationService
    {
        void Test();

        string GetTest();

        void TestString(string str);

        string GetTestString(string str);

        void Class(Test test);

        Test GetClass(Test test);

        Test1 GetClass2(Test1 test);
    }

    public class Test
    {
        public string Name { get; set; }

        public long Age { get; set; }
    }

    public class Test1
    {
        public string Name { get; set; }

        public long Age { get; set; }
    }
}