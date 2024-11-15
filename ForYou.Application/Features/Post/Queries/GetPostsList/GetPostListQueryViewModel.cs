﻿using ForYou.Application.Features.Post.Queries.GetPostsList;
using ForYou.SharedServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Post.Queries.GetPostDetail
{
    public class GetPostListQueryViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Image { get; set; }
        public UserDto User { get; set; }
        public CategoryDto Category { get; set; }
        public List<string> Tag { get; set; }

    }
}
