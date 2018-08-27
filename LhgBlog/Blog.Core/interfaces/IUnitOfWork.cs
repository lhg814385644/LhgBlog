using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsync();
    }
}
