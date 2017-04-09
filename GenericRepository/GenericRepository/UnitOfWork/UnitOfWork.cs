using Microsoft.EntityFrameworkCore;
using System;
using GenericRepository.Repositories;

namespace GenericRepository.UnitOfWork
{
    public class UnitOfWork<TC, T> where T : class where TC : DbContext, IDisposable, new()
    {
        private readonly TC _context = new TC();
        private bool _disposed = false;
        private GenericRepository<TC, T> _repository;

        public UnitOfWork(GenericRepository<TC, T> repository)
        {
            _repository = repository;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }

        /// <summary>
        /// SuppressFinalize should only be called by a class that has a finalizer.
        /// It's informing the Garbage Collector (GC) that this object was cleaned up fully.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}