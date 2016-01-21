using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Oplog.Models;

namespace Oplog.Models
{
    public class Organization
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int OrgTypeId { get; set; }
        public int? ImageId { get; set; }
        
        public File GetLogo()
        {
            if (ImageId != null)
                return Image;

            return Helper.NotAvailablePicture();
        }

        public virtual OrganizationType OrgType { get; set; }
        public virtual File Image { get; set; }

        public virtual ICollection<Character> Characters { get; set; }
    }
}