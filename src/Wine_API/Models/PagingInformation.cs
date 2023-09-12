using System.ComponentModel.DataAnnotations;

namespace WineAPI.Models
{
    public class PagingInformation
    {
        [Required]
        public int Page { get; set; } = 1;

        [Required]
        public int PageSize { get; set; } = 10;
    }
}
