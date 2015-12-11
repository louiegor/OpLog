using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oplog.Models
{
    public class Character
    {
        public Character()
        {
             
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stat { get; set; }
        public int OrganizationId { get; set; }
        public virtual ICollection<File> Images { get; set; }


        public virtual Organization Organization { get; set; }
    }
}