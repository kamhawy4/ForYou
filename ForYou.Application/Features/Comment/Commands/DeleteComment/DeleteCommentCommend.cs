﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Command.Commands.DeleteComment
{
    public class DeleteCommentCommend :IRequest
    {
        public Guid Id { get; set; }
    }
}
