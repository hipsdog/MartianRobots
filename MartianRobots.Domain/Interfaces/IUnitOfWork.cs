using System;

namespace MartianRobots.Domain.Interfaces
{
    /// <summary>
    /// Unit of work interface
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// interface of the martial world repository
        /// </summary>
        IMartianWorldRepository MartianWorlds { get; }

        /// <summary>
        /// Call to save changes to db
        /// </summary>
        /// <returns></returns>
        int Complete();
    }
}
