using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Oplog.Models;

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

        [ForeignKey("Organization")]
        public int OrganizationId { get; set; }

        [ForeignKey("LevelUpCharacter")]
        public int? LevelUpCharacterId { get; set; }
 

        public string DefaultIcon
        {
            get
            {
                var charFiles = Images.FirstOrDefault(x => x.IsDefault);
                if (charFiles == null)
                    return "Images/anon.png";

                return charFiles.FullPath;
            }
        }

        public string DefaultPic
        {
            get
            {
                var charFiles = Images.FirstOrDefault(x => x.IsDefaultPic);
                if (charFiles == null)
                    return "Images/Not_available_icon.jpg";

                return charFiles.FullPath;
            }
        }

        public virtual ICollection<File> Images { get; set; }

        public virtual Character LevelUpCharacter { get; set; }
        public virtual Organization Organization { get; set; }
     
    }
}