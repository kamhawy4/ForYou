using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Contracts;
using ForYou.Application.Interfaces;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommend>
    {

        private readonly IMapper _mapper;

        private readonly IGategoryRepository _gategoryRepository;

        public UpdateCategoryHandler(IGategoryRepository gategoryRepository, IMapper mapper)
        {
            _gategoryRepository = gategoryRepository;
            _mapper = mapper;
        }

        public async Task Handle(UpdateCategoryCommend request, CancellationToken cancellationToken)
        {

            var Category = await _gategoryRepository.GetByIdAsync(request.Id);

            Category.Name = request.Name;

            await _gategoryRepository.UpdateAsync(Category);

        }

    }
}
