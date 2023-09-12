using System.Threading.Tasks;

namespace Domain.Wine
{
    public interface IWineService
    {
        Task<Wine> Get(int Id);
    }
}