using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForYou.Domain;
using ForYou.Domain.Entities;
using ForYou.Application.Features.Category.Queries.GetCategoryDetail;
using ForYou.Application.Features.Category.Queries.GetCategoryList;
using ForYou.Application.Features.Category.Commands.CreateCategory;
using ForYou.Application.Features.Category.Commands.DeleteCategory;
using ForYou.Application.Features.Category.Commands.UpdateCategory;
using ForYou.Application.Features.Comment.Queries.GetCommentsDetail;
using ForYou.Application.Features.Comment.Queries.GetCommentsList;
using ForYou.Application.Command.Commands.CreateComment;
using ForYou.Application.Command.Commands.DeleteComment;
using ForYou.Application.Command.Commands.UpdateComment;
using ForYou.Application.Features.Post.Queries.GetPostDetail;
using ForYou.Application.Command.Post;
using ForYou.Application.Features.Post.Queries.GetPostsList;
using ForYou.Application.Features.Tag.Queries.GetTagDetail;
using ForYou.Application.Features.Tag.Queries.GetTagList;
using ForYou.Application.Features.Tag.Commends.CreateTag;
using ForYou.Application.Features.Tag.Commends.DeleteTag;
using ForYou.Application.Features.Tag.Commends.UpdateTag;
using ForYou.Application.Features.Authentication.Register;
using ForYou.Application.Features.Authentication.RefreshToken;

namespace ForYou.Application.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {

            CreateMap<CategoryEntity, GetCategoryByIdQueryViewModel>().ReverseMap();
            CreateMap<CategoryEntity, GetCategoryListQueryViewModel>().ReverseMap();
            CreateMap<CategoryEntity, CreateCategoryCommend>().ReverseMap();
            CreateMap<CategoryEntity, DeleteCategoryCommend>().ReverseMap();
            CreateMap<CategoryEntity, UpdateCategoryCommend>().ReverseMap();

            CreateMap<TagEntity, GetTagByIdQueryViewModel>().ReverseMap();
            CreateMap<TagEntity, GetTagListQueryViewModel>().ReverseMap();
            CreateMap<TagEntity, CreateTagCommend>().ReverseMap();
            CreateMap<TagEntity, DeleteTagCommend>().ReverseMap();
            CreateMap<TagEntity, UpdateTagCommend>().ReverseMap();

            CreateMap<CommentEntity, GetCommentByIdQueryViewModel>().ReverseMap();
            CreateMap<CommentEntity, GetCommentListQueryViewModel>().ReverseMap();
            CreateMap<CommentEntity, CreateCommentCommend>().ReverseMap();
            CreateMap<CommentEntity, DeleteCommentCommend>().ReverseMap();
            CreateMap<CommentEntity, UpdateCommentCommend>().ReverseMap();

            CreateMap<PostEntity, GetPostByIdQueryViewModel>().ReverseMap();

            CreateMap<PostEntity, GetPostListQueryViewModel>()
                .ForMember(dest => dest.Tag, opt => opt.MapFrom(src => src.PostTag.Select(pt => pt.Tag.Title).ToList()));

            CreateMap<PostEntity, CreatePostCommend>().ReverseMap();
            CreateMap<PostEntity, DeletePostCommend>().ReverseMap();
            CreateMap<PostEntity, UpdatePostCommend>().ReverseMap();
            CreateMap<CategoryEntity, CategoryDto>().ReverseMap();
            CreateMap<UserEntity, UserDto>().ReverseMap();
            CreateMap<UserEntity, RegisterCommend>().ReverseMap();
            CreateMap<UserEntity, RefreshTokenResponce>().ReverseMap();


        }
    }
}
