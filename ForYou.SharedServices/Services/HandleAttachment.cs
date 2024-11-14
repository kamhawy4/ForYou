using ForYou.SharedServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace ForYou.SharedServices.Services
{
    public class HandleAttachment : IHandleAttachment
    {
        public async Task<string> Upload(IFormFile attachment)
        {
            if (attachment != null && attachment.Length > 0)
            {

;               var uploadpath =  Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                var filename =   Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);

                var filePath = Path.Combine(uploadpath, filename);

                await attachment.CopyToAsync(new FileStream(filePath,FileMode.Create));

                return uploadpath;

            }
            return "No file selected for upload.";
        }
    }
}
