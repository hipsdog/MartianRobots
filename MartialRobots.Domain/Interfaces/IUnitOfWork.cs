using System;

namespace MartialRobots.Domain.Interfaces
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// interface of the martial world repository
        /// </summary>
        IMartialWorldRepository MartialWorlds { get; }

        /// <summary>
        /// Call to save changes to db
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
