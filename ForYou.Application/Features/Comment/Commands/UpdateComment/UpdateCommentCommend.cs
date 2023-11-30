﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Command.Commands.UpdateComment
{
    public class UpdateCommentCommend :IRequest
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
    }
}
