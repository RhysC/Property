using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Property.Web.Models.Landlord
{
    public class Portfolio
    {
        public int Id { get; set; }
        [Required]
        public virtual UserProfile Owner { get; set; }
        public virtual string Name { get; set; }
        public virtual ICollection<PropertyDescription> Properties { get; set; }
    }
}