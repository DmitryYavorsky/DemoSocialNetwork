using System.Threading.Tasks;

namespace DSN.Common
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
