using Khan.TranslationProject.Model.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace Khan.TranslationProject.Data.Context
{
    public interface ITranslationDbContext : IDbContext
    {
        IDbSet<Author> Authors { get; set; }
        IDbSet<Article> Articles { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Address> Addresses { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<ArticleItem> ArticleItems { get; set; }
        IDbSet<Department> Departments { get; set; }
        IDbSet<RequestedOrder> RequestedOrders { get; set; }
        IDbSet<Employee> Employees { get; set; }
        IDbSet<Rating> Ratings { get; set; }
    }
}
