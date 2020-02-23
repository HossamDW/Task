using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;

namespace Task.Core.Interfaces
{
    public interface ICreateForAsync<T> where T : class
    {
        Task<OperationResult> CreateAsync(T entityToCreate);
    }
}
