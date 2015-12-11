using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oplog.Models
{
    public class File
    {
        public int Id { get; set; }
        public string Name { get; set; } //this is the file name
        public string Path { get; set; }
        public bool IsDefault { get; set; }
        public int CharacterId { get; set; }

        //public virtual ICollection<Character> Characters { get; set; }
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<OrganizationType> OrganizationTypes { get; set; }
    }
}