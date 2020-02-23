using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;

namespace Task.Core.Interfaces
{
    public interface IDeleteForAsync<TKey>
    {
        Task<OperationResult> DeleteAsync(TKey key);
    }
}
