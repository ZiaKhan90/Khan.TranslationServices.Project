using Khan.TranslationProject.Data.EntityConfiguration;
using Khan.TranslationProject.Model.Entities;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;

namespace Khan.TranslationProject.Data.Context
{
    public class TranslationDbContext : DbContext, ITranslationDbContext
    {
        public TranslationDbContext()
            : base("name=TranslationServicesProject")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public IDbSet<Author> Authors { get; set; }
        public IDbSet<Article> Articles { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<Address> Addresses { get; set; }
        public IDbSet<Comment> Comments { get; set; }
        public IDbSet<ArticleItem> ArticleItems { get; set; }
        public IDbSet<Department> Departments { get; set; }
        public IDbSet<RequestedOrder> RequestedOrders { get; set; }
        public IDbSet<Employee> Employees { get; set; }
        public IDbSet<Rating> Ratings { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new AuthorEntityConfiguration());
            modelBuilder.Configurations.Add(new ArticleEntityConfiguration());
            modelBuilder.Configurations.Add(new CategoryEntityConfiguration());
            modelBuilder.Configurations.Add(new AddressEntityConfiguration());
            modelBuilder.Configurations.Add(new ArticleItemEntityConfiguration());
            modelBuilder.Configurations.Add(new CommentEntityConfiguration());
            modelBuilder.Configurations.Add(new DepartmentEntityConfiguration());
            modelBuilder.Configurations.Add(new RequestedOrderEntityConfiguration());
            modelBuilder.Configurations.Add(new EmployeeEntityConfiguration());
            modelBuilder.Configurations.Add(new RatingEntityConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
