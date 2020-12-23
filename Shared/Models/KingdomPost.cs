using System;
using System.ComponentModel.DataAnnotations.Schema;
using Oqtane.Models;

namespace qlogics.Kingdom_Ideas.Models
{
    [Table("KingdomPosts")]
    //public partial class KingdomPost
    public class KingdomPost  : IAuditable
    {
       /**public KingdomPost()
        {
            KingdomComments = new HashSet<KingdomComment>();
        }*/

        public int PostId { get; set; }
        public string CreatedBy { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string IsDeleted { get; set; }
        public string PostPublished { get; set; }
        public string PostApproved { get; set; }
        public int ModuleId { get; set; }
        public string ModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /*public virtual User User { get; set; }
        public string UserId { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string ModifiedBy { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }*/
        //DateTime IAuditable.ModifiedOn { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        /*public virtual ICollection<KingdomComment> KingdomComments { get; set; }*/
    }
}
