using FluentValidation.Results;
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

        public async Task<IEnumerable<GrapeColour>> GetAllColours()
        {
            return await _grapeRepository.GetAllColours().ConfigureAwait(false);
        }

        public async Task<GrapeColour> GetGrapeColour(int id)
        {
            return await _grapeRepository.GetGrapeColour(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour)
        {
            return await _grapeRepository.InsertGrapeColour(grapeColour).ConfigureAwait(false);
        }
    }
}
