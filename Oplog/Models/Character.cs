using System;
using System.Collections.Generic;
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
        public int OrganizationId { get; set; }
        public int? LevelUpCharacterId { get; set; }

        public string DefaultIcon
        {
            get
            {
                var charFiles = DbClass.Db().Files.Where(x => x.CharacterId == Id);
                if (!charFiles.Any())
                    return "Images/anon.png";

                var defaultCharfile = charFiles.FirstOrDefault(x => x.IsDefault);
                
                if (defaultCharfile != null)
                    return defaultCharfile.FullPath;

                return charFiles.First().FullPath;
            }
        }

        public virtual ICollection<File> Images { get; set; }

        public virtual Character LevelUpCharacter { get; set; }
        public virtual Organization Organization { get; set; }
    }
}