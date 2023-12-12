using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForYou.SharedServices.Models;

public abstract class BaseResponse
{
    public bool Success => !Errors.Any();

    public string[] Errors { get; set; }
}
