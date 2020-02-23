using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Core.DTOs;
using Task.Core.DTOs.Views;

namespace Task.Core.Interfaces.Services
{
    public interface IDistrictService :
        ICreateForAsync<District>,
        IUpdateForAsync<District, int>,
        IDeleteForAsync<int>,
        IGetAllFor<District>,
        IFindForAsync<District, int>
    {
        IQueryable<DistrictView> GetAllView();
    }
}
