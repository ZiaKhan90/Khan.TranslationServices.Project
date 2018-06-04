using Khan.TranslationProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.EntityConfiguration
{
    public class CommentEntityConfiguration : EntityConfiguration<Comment>
    {
        public CommentEntityConfiguration()
        {
            ToTable("Comment");
            HasKey(x => x.Id);
        }
    }
}
