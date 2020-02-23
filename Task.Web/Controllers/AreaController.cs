using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Core.DTOs;
using Task.Core.Interfaces.Services;

namespace Task.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly IAreaService _areaService;

        public AreaController(IAreaService areaService)
        {
            _areaService = areaService;
        }

        // GET: api/Area
        [HttpGet]
        public async Task<IActionResult> Get(int currentPage = 0)
        {
            var result = _areaService.GetAll();
            return await GetPagedData(result, currentPage);
        }

        private async Task<IActionResult> GetPagedData(IQueryable<Area> data, int currentPage = 0)
        {
            var pageSize = 20;
            currentPage = currentPage >= 0 ? currentPage : 0;
            var startIndex = pageSize * currentPage;
            var pagedData = data
                .Skip(startIndex)
                .Take(pageSize)
                .ToList();

            if (currentPage <= 1)
            {
                var pagesCount = Math.Ceiling(Convert.ToDecimal(data.Count()) / Convert.ToDecimal(pageSize));
                return Ok(new { Success = true, Data = pagedData, pagesCount });
            }
            return Ok(new { Success = true, Data = pagedData });
        }

        // GET: api/Area/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var selectedArea = await _areaService.FindAsync(id);
            return Ok(new { success = true, data = selectedArea });
        }

        // POST: api/Area
        [HttpPost]
        public async Task<IActionResult> Post(Area value)
        {
            if (ModelState.IsValid)
            {
                var result = await _areaService.CreateAsync(value);
                return Ok(result);
            }
            return Ok(new { Success = false, Message = getErrorMessages() });
        }

        private string getErrorMessages()
        {
            var msg = string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
            return msg;
        }

        // PUT: api/Area/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Area value)
        {
            if (ModelState.IsValid)
            {
                var result = await _areaService.UpdateAsync(id, value);
                return Ok(result);
            }
            return Ok(new { Success = false, Message = getErrorMessages() });
        }

        // DELETE: api/Area/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _areaService.DeleteAsync(id);
            return Ok(result);
        }
    }
}