using AutoMapper;
using ForYou.Application.Command.Post;
using ForYou.Application.Command.Post.CreatePost;
using ForYou.Application.Contracts;
using ForYou.Application.Features.Authentication.Register;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Interfaces;
using ForYou.Application.Services.Interfaces.ActiveDirectory;
using ForYou.Domain.Contracts;
using ForYou.Domain.Entities;
using ForYou.SharedServices.Interfaces;
using ForYou.SharedServices.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ForYou.Application.Features.Authentication.Login
{
    public class LoginHandler : IRequestHandler<LoginCommend, TResponse<LoginResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticatService _authenticatService;
        private readonly IUnitOfWork _unitOfWork;


        public LoginHandler(IConfiguration configuration, IMapper mapper,IAuthenticatService authenticatService, IUnitOfWork unitOfWork)
        {
            _configuration = configuration;
            _authenticatService = authenticatService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<TResponse<LoginResponse>> Handle(LoginCommend request, CancellationToken cancellationToken)
        {
           await _authenticatService.IsAuthenticated(request.Email, request.Password);
           var user = await _unitOfWork.users.GetUserByUsername(request.Email);
            user.


        }

    }
}
