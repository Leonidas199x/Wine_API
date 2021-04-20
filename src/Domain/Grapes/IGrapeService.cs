using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public interface IGrapeService
    {
        #region grape
        Task<Grape> Get(int grapeId);

        Task<IEnumerable<Grape>> GetAll();

        Task<ValidationResult> InsertGrape(Grape grape);

        Task<ValidationResult> UpdateGrape(Grape grape);

        Task<ValidationResult> DeleteGrape(int grapeId);
        #endregion

        #region GrapeColour
        Task<IEnumerable<GrapeColour>> GetAllColours();

        Task<GrapeColour> GetGrapeColour(int id);

        Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour);

        Task DeleteGrapeColour(int grapeColourId);

        Task<ValidationResult> UpdateGrapeColour(GrapeColour grapeColour);
        #endregion
    }
}
