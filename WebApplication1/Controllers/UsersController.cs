using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Dtos;

namespace WebApplication1.Controllers
{
   // [Authorize]  // it makes sure we are authorised before we can use any of the functions
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IDatingRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(IDatingRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var user = await _repo.GetUsers();

            var userToReturn = _mapper.Map<IEnumerable<UserForListDto>>(user);


            return Ok(userToReturn);
        }


        [HttpGet("{id}")]

        public async Task<IActionResult> GetUser(int id)
        {
            var user = await _repo.GetUser(id);

             var userToReturn = _mapper.Map<UserForDetailsDto>(user);


            return Ok(userToReturn);
        }


    }
}