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
using Task.Core.Interfaces.Services;
using Task.Infrastructure.Data;
using Entities = Task.Core.Entities;

namespace Task.Services.Data
{
    public class DistrictService : IDistrictService
    {
        private readonly TaskDBContext _context;
        private IMapper _mapper;

        public DistrictService(TaskDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult> CreateAsync(District entityToCreate)
        {
            entityToCreate.CreatedAt = DateTime.Now;
            entityToCreate.ModifiedAt = DateTime.Now;

            var newDistrict = _mapper.Map<Entities.District>(entityToCreate);
            await _context.Districts.AddAsync(newDistrict);
            await _context.SaveChangesAsync();
            return OperationResult.Succeeded();
        }

        public async Task<OperationResult> DeleteAsync(int key)
        {
            var selectedDistrict = await _context.Districts.FindAsync(key);
            if (selectedDistrict != null)
            {
                _context.Districts.Remove(selectedDistrict);
                await _context.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();
        }

        public async Task<District> FindAsync(int key)
        {
            var selectedDistrict = await _context.Districts.FindAsync(key);
            return selectedDistrict != null ? _mapper.Map<District>(selectedDistrict) : null;
        }

        public IQueryable<District> GetAll()
        {
            var result = _context.Districts
                .ProjectTo<District>(_mapper.ConfigurationProvider);
            return result;
        }

        public IQueryable<DistrictView> GetAllView()
        {
            var result = (from district in _context.Districts
                          join city in _context.Cities
                          on district.CityId equals city.Id
                          join area in _context.Areas
                          on district.AreaId equals area.Id
                          select new DistrictView()
                          {
                              Id = district.Id,
                              Area = area.Name,
                              Name = district.Name,
                              City = city.Name

                          }).AsQueryable();

            return result;
        }

        public async Task<OperationResult> UpdateAsync(int key, District entityToUpdate)
        {
            var selectedDistrict = await _context.Districts.FindAsync(key);
            if (selectedDistrict != null)
            {
                var updatedDistrict = _mapper.Map<Entities.District>(entityToUpdate);
                updatedDistrict.Id = key;
                updatedDistrict.ModifiedAt = DateTime.Now;
                _context.Entry(updatedDistrict).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();

        }
    }
}
