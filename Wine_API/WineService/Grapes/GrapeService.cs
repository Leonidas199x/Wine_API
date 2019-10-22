using DataContract.Grape;
using System.Collections.Generic;
using System.Threading.Tasks;
using Repository.Grapes;

namespace WineService.Grapes
{
    public class GrapeService : IGrapeService
    {
        private IGrapesRepository _grapeRepository;

        public GrapeService(IGrapesRepository grapeRepository)
        {
            _grapeRepository = grapeRepository;
        }

        public async Task<IEnumerable<Grape>> Get(int grapeId)
        {
            var country = await _grapeRepository.Get(grapeId).ConfigureAwait(false);

            return (country != null) ? country : null;
        }
    }
}
