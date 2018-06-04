using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.EntityConfiguration
{
    public abstract class EntityConfiguration<TEntity> : EntityTypeConfiguration<TEntity> where TEntity : class
    {
    }
}
