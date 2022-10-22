using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Audi.DAL.Models
{
    public class AudiModel
    {
        public int Id { get; set; }
        public string? Brand { get; set; }
        public string? Model { get; set; }
        public int Price { get; set; }
        public string? Description { get; set; }
    }
}
