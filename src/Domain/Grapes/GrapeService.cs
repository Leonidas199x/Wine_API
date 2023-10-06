using FluentValidation;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public class GrapeService : IGrapeService
    {
        private readonly IGrapeRepository _grapeRepository;
        private readonly IValidator<GrapeColour> _grapeColourValidator;
        private readonly IValidator<Grape> _grapeValidator;

        public GrapeService(
            IGrapeRepository grapeRepository, 
            IValidator<GrapeColour> grapeColourValidator, 
            IValidator<Grape> grapeValidator)
        {
            _grapeRepository = grapeRepository;
            _grapeColourValidator = grapeColourValidator;
            _grapeValidator = grapeValidator;
        }

        #region Grape
        public async Task<PagedList<IEnumerable<Grape>>> GetAll(int page, int pageSize)
        {
            return await _grapeRepository.GetAll(page, pageSize).ConfigureAwait(false);
        }

        public async Task<Grape> Get(int grapeId)
        {
            return await _grapeRepository.Get(grapeId).ConfigureAwait(false);
        }

        public async Task<ValidationResult> InsertGrape(Grape grape)
        {
            var validationResult = await _grapeValidator.ValidateAsync(grape).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _grapeRepository.InsertGrape(grape).ConfigureAwait(false);
        }

        public async Task<ValidationResult> UpdateGrape(Grape grape)
        {
            var validationResult = await _grapeValidator.ValidateAsync(grape).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _grapeRepository.UpdateGrape(grape).ConfigureAwait(false);
        }

        public async Task<ValidationResult> DeleteGrape(int grapeId)
        {
            return await _grapeRepository.DeleteGrape(grapeId).ConfigureAwait(false);
        }

        #endregion
        public async Task<PagedList<IEnumerable<GrapeColour>>> GetAllColours(int page, int pageSize)
        {
            return await _grapeRepository.GetAllColours(page, pageSize).ConfigureAwait(false);
        }

        public async Task<GrapeColour> GetGrapeColour(int id)
        {
            return await _grapeRepository.GetGrapeColour(id).ConfigureAwait(false);
        }

        public async Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour)
        {
            var validationResult = await _grapeColourValidator.ValidateAsync(grapeColour).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _grapeRepository.InsertGrapeColour(grapeColour).ConfigureAwait(false);
        }

        public async Task DeleteGrapeColour(int grapeColourId)
        {
            await _grapeRepository.DeleteGrapeColour(grapeColourId).ConfigureAwait(false);
        }

        public async Task<ValidationResult> UpdateGrapeColour(GrapeColour grapeColour)
        {
            var validationResult = await _grapeColourValidator.ValidateAsync(grapeColour).ConfigureAwait(false);
            if (!validationResult.IsValid)
            {
                return validationResult;
            }

            return await _grapeRepository.UpdateGrapeColour(grapeColour).ConfigureAwait(false);
        }
    }
}
