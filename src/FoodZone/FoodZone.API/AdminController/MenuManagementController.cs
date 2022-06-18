using AutoMapper;
using FoodZone.Models.Common;
using FoodZone.Services.DTO;
using FoodZone.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace FoodZone.API.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuManagementController : ControllerBase
    {
        private readonly IMenuServices _menuServices;
        private readonly IMapper _mapper;

        public MenuManagementController(IMenuServices menuServices, IMapper mapper)
        {
            _menuServices = menuServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var menu = await _menuServices.GetAllAsync();
            return Ok(menu);
        }

        [HttpGet("{id:int}", Name = "GetMenu")]
        public async Task<IActionResult> GetMenu(int id)
        {
            var menu = await _menuServices.GetByIdAsync(id);
            var result = _mapper.Map<MenuDTO>(menu);
            return Ok(result);
        }

        [HttpPost]
        [Route("CreateMenu")]
        public async Task<IActionResult> CreateMenu([FromBody] MenuDTO menuDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var menu = _mapper.Map<Menu>(menuDTO);
            await _menuServices.AddAsync(menu);

            return Ok(menu);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateMenu(int id, [FromBody] MenuDTO menuDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }

            var menu = await _menuServices.GetByIdAsync(id);
            if(menu == null)
            {
                return BadRequest(menu);
            }

            _mapper.Map(menuDTO, menu);
            await _menuServices.UpdateAsync(menu);

            return Ok(menu);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            if(id < 1)
            {
                return BadRequest();
            }

            var menu = await _menuServices.GetByIdAsync(id);
            if (menu == null)
            {
                return BadRequest(menu);
            }

            await _menuServices.DeleteAsync(menu);
            return Ok();
        }
    }
}
