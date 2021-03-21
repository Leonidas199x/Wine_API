using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public class GrapeService : IGrapeService
    {
        private IGrapesRepository _grapeRepository;

        public GrapeService(IGrapesRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;
        }

        public async Task<IEnumerable<Grape>> GetAll()
        {
            return await _grapeRepository.GetAll().ConfigureAwait(false);
        }

        public async Task<Grape> Get(int grapeId)
        {
            return await _grapeRepository.Get(grapeId).ConfigureAwait(false);
        }
    }
}
