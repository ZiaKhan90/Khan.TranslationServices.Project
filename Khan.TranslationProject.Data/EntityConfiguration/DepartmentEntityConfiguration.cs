using Khan.TranslationProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.EntityConfiguration
{
    public class DepartmentEntityConfiguration : EntityConfiguration<Department>
    {
        public DepartmentEntityConfiguration()
        {
            ToTable("Department");
            HasKey(x => x.Id);
        }
    }
}
