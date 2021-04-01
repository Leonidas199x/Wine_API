using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public interface IGrapesRepository
    {
        Task<IEnumerable<GrapeLookup>> GetGrapeLookup();

        Task<Grape> Get(int grapeId);

        Task<IEnumerable<Grape>> GetAll();

        Task<IEnumerable<GrapeColour>> GetAllColours();

        Task<GrapeColour> GetGrapeColour(int Id);

        Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour);
    }
}
