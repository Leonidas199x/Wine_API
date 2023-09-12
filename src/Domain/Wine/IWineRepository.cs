using System.Threading.Tasks;

namespace Domain.Wine
{
    public interface IWineRepository
    {
        Task<Wine> Get(int Id);
    }
}