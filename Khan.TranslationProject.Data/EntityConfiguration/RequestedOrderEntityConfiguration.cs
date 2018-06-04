using Khan.TranslationProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.EntityConfiguration
{
    public class RequestedOrderEntityConfiguration : EntityConfiguration<RequestedOrder>
    {
        public RequestedOrderEntityConfiguration()
        {
            ToTable("RequestedOrder");
            HasKey(x => x.Id);
        }
    }
}
