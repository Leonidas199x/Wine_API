using FluentValidation.Results;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Grapes
{
    public interface IGrapeRepository
    {
        Task<Grape> Get(int grapeId);

        Task<PagedList<IEnumerable<Grape>>> GetAll(int page, int pageSize)

        Task<ValidationResult> InsertGrape(Grape grape);

        Task<IEnumerable<Grape>> GetByName(string name);

        Task<ValidationResult> UpdateGrape(Grape grape);

        Task<ValidationResult> DeleteGrape(int grapeId);

        Task<PagedList<IEnumerable<GrapeColour>>> GetAllColours(int page, int pageSize);

        Task<GrapeColour> GetGrapeColour(int Id);

        Task<ValidationResult> InsertGrapeColour(GrapeColour grapeColour);

        Task DeleteGrapeColour(int grapeColourId);

        Task<ValidationResult> UpdateGrapeColour(GrapeColour grapeColour);

        Task<IEnumerable<GrapeColour>> GetByColour(string colour);
    }
}
