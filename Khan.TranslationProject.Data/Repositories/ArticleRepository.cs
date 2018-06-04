using Khan.TranslationProject.Data.Infrastructure;
using Khan.TranslationProject.Data.Infrastructure.EntityRepository;
using Khan.TranslationProject.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khan.TranslationProject.Data.Repositories
{
    public class ArticleRepository : RepositoryBase<Article>, IArticleRepository
    {
        private ITranslationUnitOfWork unitOfWork;
        public ArticleRepository(ITranslationUnitOfWork _unitOfWork) : base(_unitOfWork)
        {
            this.unitOfWork = _unitOfWork;
        }
    }
}
