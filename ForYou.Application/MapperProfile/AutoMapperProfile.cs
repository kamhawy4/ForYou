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
        }
    }
}
