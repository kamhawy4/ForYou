using AutoMapper;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using MediatR;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.CreateTag
{
    public class CreatTagHandler : IRequestHandler<CreateTagCommend, Guid>
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreatTagHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public  async Task<Guid> Handle(CreateTagCommend request, CancellationToken cancellationToken)
        {

             CreateTagVaildator vaildator =  new CreateTagVaildator();

             var result =  await vaildator.ValidateAsync(request, cancellationToken);

             if (result.Errors.Any()) throw new Exception("all input is requierd");

            TagEntity tag =  _mapper.Map<TagEntity>(request);

            await _unitOfWork.tags.AddAsync(tag);

            return tag.TagId;
        }
    }
}
