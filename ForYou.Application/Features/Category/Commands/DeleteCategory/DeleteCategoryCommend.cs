using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ForYou.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommend : IRequest
    {
        public  Guid Id { get; set; }
    }
}
