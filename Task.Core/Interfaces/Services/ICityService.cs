using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.Core.DTOs;
using Task.Core.DTOs.Views;

namespace Task.Core.Interfaces.Services
{
    public interface ICityService :
        ICreateForAsync<City>,
        IUpdateForAsync<City, int>,
        IDeleteForAsync<int>,
        IGetAllFor<City>,
        IFindForAsync<City, int>
    {
        IQueryable<CityView> GetAllViewByArea(int id);
        IQueryable<CityView> GetAllView();
    }
}
