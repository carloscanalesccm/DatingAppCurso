using System;
using System.Collections.Generic; //Para IEnumerable
using System.Linq; //Para ToList()
using System.Threading.Tasks; //Para TaskActionRe...
using API.Data;
using Microsoft.AspNetCore.Mvc;
using API.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using API.Interfaces;  //IUserRepository
using API.DTOS;
using AutoMapper;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        private readonly IUserRepository _UserRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository UserRepository, IMapper mapper)
        {
            _mapper = mapper;
            _UserRepository = UserRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers()
        {
            var users = await _UserRepository.GetMembersAsync();

            return Ok(users);

        }

        // api/users/3
        [HttpGet("{username}")]
        public async Task<ActionResult<MemberDto>> GetUser(string username)
        {
            return await _UserRepository.GetMemberAsync(username);

        }
    }
}