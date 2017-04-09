using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericRepository.Repositories;

namespace GenericRepository.UnitOfWork
{
    public class UnitOfWork<C, T> where T : class where C : DbContext, IDisposable, new()
    {
        private C context = new C();
        private bool _disposed = false;
        private GenericRepository<C, T> _repository;

        public UnitOfWork(GenericRepository<C, T> repository)
        {
            _repository = repository;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                context.Dispose();
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}