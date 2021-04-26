using System.Threading.Tasks;

namespace Domain.Wine
{
    public class WineService : IWineService
    {
        private readonly IWineRepository _wineRepository;

        public WineService(IWineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public async Task<Wine> Get(int Id)
        {
            return await _wineRepository.Get(Id).ConfigureAwait(false);
        }
    }
}
