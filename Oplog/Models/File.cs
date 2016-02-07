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
        public bool IsDefaultPic { get; set; }
        public int CharacterId { get; set; }

        public string FullPath { get { return Path + Name; } }

        
        public virtual ICollection<Organization> Organizations { get; set; }
        public virtual ICollection<OrganizationType> OrganizationTypes { get; set; }
       
    }
}