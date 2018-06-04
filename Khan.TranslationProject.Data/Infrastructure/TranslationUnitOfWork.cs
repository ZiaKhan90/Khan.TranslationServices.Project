using Khan.TranslationProject.Data.Context;
using System;
using System.Linq;

namespace Khan.TranslationProject.Data.Infrastructure
{
    /// <summary>
    /// IUnitOfWork wraps a IDbContext
    /// The 'unit of work' refers to a database transaction
    /// </summary>
    public sealed class TranslationUnitOfWork : UnitOfWork, IDisposable, ITranslationUnitOfWork
    {
        public TranslationUnitOfWork(ITranslationDbContext context) : base(context)
        {
        }
    }
}
