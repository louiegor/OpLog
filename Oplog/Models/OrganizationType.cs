using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Oplog.Models
{
    public class OrganizationType
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
      
        public int? FileId { get; set; }
        
        public virtual File File { get; set; }
    }
}
//Marine
//Pirate
//RevolutionArmy
//WorldGovernment
//Shichibukai