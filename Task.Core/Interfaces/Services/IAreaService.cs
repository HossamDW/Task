using System;
using System.Collections.Generic;
using System.Text;
using Task.Core.DTOs;

namespace Task.Core.Interfaces.Services
{
    public interface IAreaService :
        ICreateForAsync<Area>,
        IUpdateForAsync<Area, int>,
        IDeleteForAsync<int>,
        IGetAllFor<Area>,
        IFindForAsync<Area, int>
    {

    }
}
