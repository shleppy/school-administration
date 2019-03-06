using Assignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2.Persistence
{
    interface IRepository
    {
        /// <summary>
        /// Add an entity to a database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Add<T>(T entity) where T : IPersistableEntity;

        /// <summary>
        /// Delete an entity from the database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Delete<T>(int id) where T : IPersistableEntity;

        /// <summary>
        /// Update an entity from the database.
        /// </summary>
        /// <param name="entity">The generic entity</param>
        void Update<T>(T entity) where T : IPersistableEntity;

        /// <summary>
        /// Retrieve all entities of this type from the database.
        /// </summary>
        /// <returns>Returns an <code>IEnumerable</code> list of entities.</returns>
        IEnumerable<T> All<T>() where T : IPersistableEntity;

        /// <summary>
        /// Retrieve a single entity from the database.
        /// </summary>
        /// <param name="id">ID of the generic entity.</param>
        /// <returns>The found entity or null</returns>
        T Single<T>(int id) where T : IPersistableEntity;

        /// <summary>
        /// Generic Query to the database. Useful for passing lambda's as an expression.
        /// </summary>
        /// <param name="predicate">The query predicate expression</param>
        /// <returns>An IEnumerable list of entities matching the predicate</returns>
        IEnumerable<T> Query<T>(Expression<Func<T, bool>> predicate) where T : IPersistableEntity;
    }
}
