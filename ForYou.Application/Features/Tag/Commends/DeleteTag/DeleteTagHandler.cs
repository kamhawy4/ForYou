using ForYou.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.Application.Features.Tag.Commends.DeleteTag
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagCommend>
    {

        private readonly IUnitOfWork _unitOfWork;

        public DeleteTagHandler(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteTagCommend request,CancellationToken cancellationToken)
        {
            var result = await _unitOfWork.tags.GetByIdAsync(request.Id);

            await _unitOfWork.tags.DeleteAsync(result);

        }
    }
}
