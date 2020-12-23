using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace qlogics.Kingdom_Ideas.Models
{
    [Table("qlogicsKingdom_Ideas")]
    public class Kingdom_Ideas : IAuditable
    {
        public int Kingdom_IdeasId { get; set; }
        public int ModuleId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
