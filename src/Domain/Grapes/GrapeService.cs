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
            var grapes = await _grapeRepository.GetAll().ConfigureAwait(false);

            return grapes;
        }

        public async Task<IEnumerable<Grape>> Get(int grapeId)
        {
            var country = await _grapeRepository.Get(grapeId).ConfigureAwait(false);

            return country;
        }
    }
}
