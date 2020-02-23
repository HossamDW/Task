using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task.Core.DTOs;
using Task.Core.Interfaces.Services;
using Task.Infrastructure.Data;
using Entities = Task.Core.Entities;

namespace Task.Services.Data
{
    public class AreaService : IAreaService
    {
        private readonly TaskDBContext _context;
        private IMapper _mapper;

        public AreaService(TaskDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<OperationResult> CreateAsync(Area entityToCreate)
        {
            entityToCreate.CreatedAt = DateTime.Now;
            entityToCreate.ModifiedAt = DateTime.Now;

            var newArea = _mapper.Map<Entities.Area>(entityToCreate);
            await _context.Areas.AddAsync(newArea);
            await _context.SaveChangesAsync();
            return OperationResult.Succeeded();
        }

        public async Task<OperationResult> DeleteAsync(int key)
        {
            var selectedArea = await _context.Areas.FindAsync(key);
            if (selectedArea != null)
            {
                _context.Areas.Remove(selectedArea);
                await _context.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();
        }

        public async Task<Area> FindAsync(int key)
        {
            var selectedArea = await _context.Areas.FindAsync(key);
            return selectedArea != null ? _mapper.Map<Area>(selectedArea) : null;
        }

        public IQueryable<Area> GetAll()
        {
            var result = _context.Areas
                .ProjectTo<Area>(_mapper.ConfigurationProvider);
            return result;
        }

        public async Task<OperationResult> UpdateAsync(int key, Area entityToUpdate)
        {
            var selectedArea = await _context.Areas.FindAsync(key);
            if (selectedArea != null)
            {
                var updatedArea = _mapper.Map<Entities.Area>(entityToUpdate);
                updatedArea.Id = key;
                updatedArea.ModifiedAt = DateTime.Now;
                _context.Entry(updatedArea).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return OperationResult.Succeeded();
            }
            return OperationResult.NotFound();

        }
    }
}
