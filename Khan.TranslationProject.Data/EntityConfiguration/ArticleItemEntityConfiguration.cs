using Khan.TranslationProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.EntityConfiguration
{
    public class ArticleItemEntityConfiguration : EntityConfiguration<ArticleItem>
    {
        public ArticleItemEntityConfiguration()
        {
            ToTable("ArticleItem");
            HasKey(x => x.Id);
        }
    }
}
