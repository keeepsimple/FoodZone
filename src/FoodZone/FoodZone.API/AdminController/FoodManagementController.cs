using AutoMapper;
using FoodZone.Models.Common;
using FoodZone.Services.DTO;
using FoodZone.Services.IServices;
using FoodZone.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodZone.API.AdminController
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodManagementController : ControllerBase
    {
        private readonly IFoodServices _foodServices;
        private readonly IMapper _mapper;

        public FoodManagementController(IFoodServices foodServices, IMapper mapper)
        {
            _foodServices = foodServices;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var food = await _foodServices.GetAllAsync();
            return Ok(food);
        }

        [HttpGet("{id:int}", Name = "GetFood")]
        public async Task<IActionResult> GetFood(int id)
        {
            var food = await _foodServices.GetByIdAsync(id);
            var result = _mapper.Map<FoodDTO>(food);
            return Ok(result);
        }

        [HttpPost]
        [Route("Createfood")]
        public async Task<IActionResult> Createfood([FromBody] FoodDTO foodDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var food = _mapper.Map<Food>(foodDTO);
            await _foodServices.AddAsync(food);

            return Ok(food);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Updatefood(int id, [FromBody] FoodDTO foodDTO)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }

            var food = await _foodServices.GetByIdAsync(id);
            if (food == null)
            {
                return BadRequest(food);
            }

            _mapper.Map(foodDTO, food);
            await _foodServices.UpdateAsync(food);

            return Ok(food);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Deletefood(int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }

            var food = await _foodServices.GetByIdAsync(id);
            if (food == null)
            {
                return BadRequest(food);
            }

            await _foodServices.DeleteAsync(food);
            return Ok();
        }
    }
}
