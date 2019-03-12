using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Assignment2.Persistence
{
    internal interface IRepository<T> where T : IPersistableEntity
    {
        /// <summary>
        /// Insert an entity to a database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Insert(T entity);

        /// <summary>
        /// Update an entity from the database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Update(int id, T entity);

        /// <summary>
        /// Delete an entity from the database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Delete(int id);

        /// <summary>
        /// Retrieve a single entity from the database.
        /// </summary>
        /// <param name="id">ID of the generic entity.</param>
        /// <returns>The found entity or null</returns>
        T Read(int id);

        /// <summary>
        /// Retrieve all entities of this type from the database.
        /// </summary>
        /// <returns>Returns an <code>IEnumerable</code> list of entities.</returns>
        IEnumerable<T> ReadAll();

        /// <summary>
        /// Generic Query to the database. Useful for passing lambda's as an expression.
        /// </summary>
        /// <param name="predicate">The query predicate expression</param>
        /// <returns>An IEnumerable list of entities matching the predicate</returns>
        IEnumerable<T> Query(Expression<Func<T, bool>> predicate);
    }
}
