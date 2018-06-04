using Khan.TranslationProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.EntityConfiguration
{
    public class AddressEntityConfiguration : EntityConfiguration<Address>
    {
        public AddressEntityConfiguration()
        {
            ToTable("Address");
            HasKey(x => x.Id);
        }
    }
}
