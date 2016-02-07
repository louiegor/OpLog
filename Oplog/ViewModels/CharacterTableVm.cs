using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Oplog.Models;

namespace Oplog.ViewModels
{
    public class CharacterTableVm
    {
        private readonly Character character;
        public int Id { get { return character.Id; } }
        public string Name { get { return character.Name; } }
        public string IconPath { get { return character.DefaultIcon; } }
        public string DefaultPicPath { get { return character.DefaultPic; } }
        public string OrgName { get { return character.Organization.Name; } }
        public string OrgType { get { return character.Organization.OrgType.Name; } }
        public int OrgId { get { return character.OrganizationId; } }
        public string OrgIconPath { get { return character.Organization.GetLogo().FullPath; } }
        public string Description { get { return character.Description; } }
        public int Stats { get { return character.Stat; } }

        public CharacterTableVm(Character character)
        {
            this.character = character;
        }

    }
}