using ForYou.Application.Contracts;
using ForYou.Domain.Entities;
using System;

namespace ForYou.Application.Contracts
{
	public interface IGategoryRepository : IAsyncRepository<CategoryEntity>
    {
	 
	}
}

