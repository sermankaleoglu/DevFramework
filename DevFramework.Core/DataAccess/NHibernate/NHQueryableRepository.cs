using DevFramework.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public class NHQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nHibernateHelper;
        
        IQueryable<T> _entities;

        public NHQueryableRepository(NHibernateHelper _nHibernateHelper)
        {
            _nHibernateHelper = _nHibernateHelper;
        }

        public IQueryable<T> Table => this.Entities; 

        public virtual IQueryable<T> Entities { 
            get { return _entities ?? (_entities = _nHibernateHelper.OpenSession().Query<T>()); }
            
        }
    }
}
