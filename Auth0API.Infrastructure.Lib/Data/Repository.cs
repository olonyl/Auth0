using Auth0API.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Auth0API.Domain.Seedwork;

namespace Auth0API.Infrastructure.Data
{
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        #region Members

        private readonly IQueryableUnitOfWork _unitOfWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Create a new instance of repository
        /// </summary>
        /// <param name="unitOfWork">Associated Unit Of Work</param>
        public Repository(IQueryableUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        #endregion

        #region IRepository Members

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _unitOfWork;
            }
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        public virtual void Add(TEntity item)
        {

            if (item != null)
                GetSet().Add(item); // add new item in this set
            else
            {
                //LoggerFactory.CreateLog()
                //          .LogInfo(Messages.info_CannotAddNullEntity, typeof(TEntity).ToString());

            }

        }
        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        public virtual void Remove(TEntity item)
        {
            //if (item != null)
            //{
            //    //attach item if not exist
            //    _unitOfWork.Attach(item);

            //    //set as "removed"
            //    GetSet().Remove(item);
            //}
            //else
            //{
            //    //LoggerFactory.CreateLog()
            //    //          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            //}
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="item"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        public virtual void Modify(TEntity item)
        {
            //if (item != null)
            //    _unitOfWork.SetModified(item);
            //else
            //{
            //    //LoggerFactory.CreateLog()
            //    //          .LogInfo(Messages.info_CannotRemoveNullEntity, typeof(TEntity).ToString());
            //}
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="id"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></returns>
        public virtual TEntity Get(Guid id)
        {
            if (id != Guid.Empty)
                return GetSet().Find(id);
            else
                return null;
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <returns><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> GetAll()
        {
            return GetSet();
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="specification"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> AllMatching(Domain.Specification<TEntity> specification)
        {
            return GetSet().Where(specification);
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <typeparam name="S"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></typeparam>
        /// <param name="pageIndex"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <param name="pageCount"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <param name="orderByExpression"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <param name="ascending"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> GetPaged<KProperty>(int pageIndex, int pageCount, System.Linq.Expressions.Expression<Func<TEntity, KProperty>> orderByExpression, bool ascending)
        {
            var set = GetSet();

            if (ascending)
            {
                return set.OrderBy(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
            else
            {
                return set.OrderByDescending(orderByExpression)
                          .Skip(pageCount * pageIndex)
                          .Take(pageCount);
            }
        }

        /// <summary>
        /// <see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/>
        /// </summary>
        /// <param name="filter"><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></param>
        /// <returns><see cref="Contollo.LoanSystem.Domain.Seedwork.IRepository{TValueObject}"/></returns>
        public virtual IEnumerable<TEntity> GetFiltered(System.Linq.Expressions.Expression<Func<TEntity, bool>> filter)
        {
            return GetSet().Where(filter);
        }

        #endregion

        #region IDisposable Members

        /// <summary>
        /// <see cref="M:System.IDisposable.Dispose"/>
        /// </summary>
        public void Dispose()
        {
            if (_unitOfWork != null)
                _unitOfWork.Dispose();
        }

        #endregion

        #region Private Methods

        private DbSet<TEntity> GetSet()
        {
            return _unitOfWork.CreateSet<TEntity>();
        }
        #endregion
    }
}