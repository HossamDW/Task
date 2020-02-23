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
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        // GET: api/City
        [HttpGet]
        public async Task<IActionResult> Get(int currentPage = 0)
        {
            var result = _districtService.GetAll();
            return await GetPagedData(result, currentPage);
        }

        [HttpGet("GetAllView")]
        public async Task<IActionResult> GetAllView()
        {
            var result = _districtService.GetAllView();
            return Ok(new { Success = true, Data = result.ToList() });
        }

        private async Task<IActionResult> GetPagedData(IQueryable<District> data, int currentPage = 0)
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

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            var selectedDistrict = await _districtService.FindAsync(id);
            return Ok(new { success = true, data = selectedDistrict });
        }

        // POST: api/City
        [HttpPost]
        public async Task<IActionResult> Post(District value)
        {
            if (ModelState.IsValid)
            {
                var result = await _districtService.CreateAsync(value);
                return Ok(result);
            }
            return Ok(new { Success = false, Message = getErrorMessages() });
        }

        private string getErrorMessages()
        {
            var msg = string.Join(',', ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)));
            return msg;
        }

        // PUT: api/City/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, District value)
        {
            if (ModelState.IsValid)
            {
                var result = await _districtService.UpdateAsync(id, value);
                return Ok(result);
            }
            return Ok(new { Success = false, Message = getErrorMessages() });
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _districtService.DeleteAsync(id);
            return Ok(result);
        }
    }
}