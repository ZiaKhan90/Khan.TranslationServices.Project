using Khan.TranslationProject.Data.Context;
using System;
using System.Linq;

namespace Khan.TranslationProject.Data.Infrastructure
{
    
    public interface IUnitOfWork
    {

        bool SaveChanges();

        
        IDbContext Context { get; }
    }
}
