﻿using Microsoft.AspNetCore.Mvc;
using MyFirstAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController: ControllerBase
    {
        private IAppUserService _service;

        public UsersController(IAppUserService service)
        {
            //Dependancy Injection
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<AppUser>> GetAsync()
        {
            return await _service.GetUsers();
        }
        [HttpGet("{id}")]
        public async Task<AppUser> GetUserAsync(int id)
        {
            return await _service.GetUser(id);
        }
        [HttpPost]
        public async Task PostAsync(AppUser user)
        {
            await _service.AddUser(user);
        }
        [HttpPut]
        public async Task PutAsync(AppUser user)
        {
            await _service.UpdateUser(user);
        }
        [HttpDelete("{id}")]
        public async Task DeleteAsync(int id)
        {
            await _service.DeleteUser(id);
        }
    }
}