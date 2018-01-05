using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorldTravelBlog.Models
{
    [Table("Locations")]
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string City { get; set; }
        public virtual IEnumerable<Experience> Experiences { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}