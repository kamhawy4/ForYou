using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedServices.Interfaces
{
    public interface IHandleAttachment
    {
        void Upload(IHandleAttachment attachment);
    }
}
