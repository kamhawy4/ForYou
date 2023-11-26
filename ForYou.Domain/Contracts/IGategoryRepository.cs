﻿using AspNetCore.ServiceRegistration.Dynamic;
using ForYou.Application.Contracts;
using ForYou.Domain.Entities;
using System;

namespace ForYou.Domain.Contracts
{
    public interface IGategoryRepository : IAsyncRepository<CategoryEntity>, IScopedService
    {

    }
}

