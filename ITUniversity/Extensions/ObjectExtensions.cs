using System.Linq;

namespace ITUniversity.Extensions
{
    public static class ObjectExtensions
    {
        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }
    }
}