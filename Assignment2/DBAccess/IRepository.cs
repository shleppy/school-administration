using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.DBAccess
{
    interface IRepository<T>
    {
        /// <summary>
        /// Add an entity to a database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Add(T entity);

        /// <summary>
        /// Delete an entity from the database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Delete(int id);

        /// <summary>
        /// Update an entity from the database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Update(T entity);

        /// <summary>
        /// Retrieve all entities of this type from the database.
        /// </summary>
        /// <returns>Returns an <code>IEnumerable</code> list of entities.</returns>
        IEnumerable<T> All();

        /// <summary>
        /// Retrieve a single entity from the database.
        /// </summary>
        /// <param name="id">ID of the generic entity.</param>
        /// <returns>The found entity or null</returns>
        T Single(int id);

        /// <summary>
        /// Generic Query to the database. Useful for passing lambda's as an expression.
        /// </summary>
        /// <param name="predicate">The query predicate expression</param>
        /// <returns>An IEnumerable list of entities matching the predicate</returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
