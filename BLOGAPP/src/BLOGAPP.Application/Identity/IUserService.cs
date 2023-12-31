﻿using BLOGAPP.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BLOGAPP.Application.Contracts.Identity;

public interface IUserService
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string userId);
}

