using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Blog.Core.interfaces;

namespace Blog.Infrastructure.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _myDbContext;

        public UnitOfWork(MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }
        public async Task<bool> SaveAsync()
        {
            return await _myDbContext.SaveChangesAsync() > 0;
        }
    }
}
