using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;
using Task.Core.DTOs.Views;
using Task.Core.Interfaces;
using Task.Core.Interfaces.Services;
using Task.Infrastructure.Data;
using Entities = Task.Core.Entities;

namespace Task.Services.Data
{
    public class CityService : ICityService
    {
        private readonly TaskDBContext _context;
        private IMapper _mapper;

        public CityService(TaskDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult> CreateAsync(City entityToCreate)
        {
            entityToCreate.CreatedAt = DateTime.Now;
            entityToCreate.ModifiedAt = DateTime.Now;

            var newCity = _mapper.Map<Entities.City>(entityToCreate);
            await _context.Cities.AddAsync(newCity);
            await _context.SaveChangesAsync();
            return OperationResult.Succeeded();
        }

        public async Task<OperationResult> DeleteAsync(int key)
        {
            var selectedCity = await _context.Cities.FindAsync(key);
            if (selectedCity != null)
            {
                _context.Cities.Remove(selectedCity);
                await _context.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();
        }

        public async Task<City> FindAsync(int key)
        {
            var selectedCity = await _context.Cities.FindAsync(key);
            return selectedCity != null ? _mapper.Map<City>(selectedCity) : null;
        }

        public IQueryable<City> GetAll()
        {
            var result = _context.Cities
                .ProjectTo<City>(_mapper.ConfigurationProvider);
            return result;
        }

        public IQueryable<CityView> GetAllView()
        {
            var result = (from city in _context.Cities
                         join area in _context.Areas
                         on city.AreaId equals area.Id
                         select new CityView()
                         {
                             Id = city.Id,
                             Area = area.Name,
                             Name = city.Name
                         }).AsQueryable();

            return result;
        }

        public IQueryable<CityView> GetAllViewByArea(int id)
        {
            var result = (from city in _context.Cities
                          join area in _context.Areas
                          on city.AreaId equals area.Id
                          where area.Id == id
                          select new CityView()
                          {
                              Id = city.Id,
                              Area = area.Name,
                              Name = city.Name
                          }).AsQueryable();

            return result;
        }

        public async Task<OperationResult> UpdateAsync(int key, City entityToUpdate)
        {
            var selectedCity = await _context.Cities.FindAsync(key);
            if (selectedCity != null)
            {
                var updatedCity = _mapper.Map<Entities.City>(entityToUpdate);
                updatedCity.Id = key;
                updatedCity.ModifiedAt = DateTime.Now;
                _context.Entry(updatedCity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();

        }
    }
}
