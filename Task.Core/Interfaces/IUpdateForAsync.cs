using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;

namespace Task.Core.Interfaces
{
    public interface IUpdateForAsync<T, TKey> where T : class
    {
        Task<OperationResult> UpdateAsync(TKey key, T entityToUpdate);
    }
}
