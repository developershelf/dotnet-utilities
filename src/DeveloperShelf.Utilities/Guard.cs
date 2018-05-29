using System;

namespace DeveloperShelf.Utilities
{
    public static class Guard
    {
        /// <summary>
        /// Helper to check if an object is null
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public static void Inspect<TEntity>(TEntity entity)
        {
            if (entity != null)
            {
                return;
            }
            throw new ArgumentNullException(nameof(entity));
        }

        /// <summary>
        /// Helper to check if a string is null or empty
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public static void InspectNullOrEmpty<TEntity>(TEntity entity) where TEntity : class
        {
            var type = entity as string;

            if (type == null)
            {
                throw new ArgumentException("entity is not a string");
            }

            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException($"{entity} cannot be null or empty");
            }
        }

        /// <summary>
        /// Helper to check if a string is null or empty
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity"></param>
        public static void InspectNullOrWhitespace<TEntity>(TEntity entity) where TEntity : class
        {
            var type = entity as string;

            if (type == null)
            {
                throw new ArgumentException("entity is not a string");
            }   

            if (string.IsNullOrWhiteSpace(type))
            {
                throw new ArgumentException($"{entity} cannot be null or empty");
            }
        }
    }
}
