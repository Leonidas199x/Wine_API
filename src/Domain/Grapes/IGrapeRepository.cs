using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public interface IGrapeRepository
    {
        Task<IEnumerable<GrapeLookup>> GetGrapeLookup();

        Task<Grape> Get(int grapeId);

        Task<IEnumerable<Grape>> GetAll();

        Task<IEnumerable<GrapeColour>> GetAllColours();

        Task<GrapeColour> GetGrapeColour(int Id);

        Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour);

        Task DeleteGrapeColour(int grapeColourId);

        Task<ValidationResult> UpdateGrapeColour(GrapeColour grapeColour);

        Task<IEnumerable<GrapeColour>> GetByColour(string colour);
    }
}
