using AspNetCore.ServiceRegistration.Dynamic;
using ForYou.Application.Contracts;
using ForYou.Domain.Entities;
using System;
namespace ForYou.Application.Interfaces
{
	public interface IPostRepository : IAsyncRepository<PostEntity> , IScopedService
    {
	  	
	}
}

