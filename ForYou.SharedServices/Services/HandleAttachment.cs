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
                var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/uploads");

                var FileName = Guid.NewGuid().ToString() + Path.GetExtension(attachment.FileName);

                var filePath = Path.Combine(uploadPath, FileName);

                await  attachment.CopyToAsync(new FileStream(filePath, FileMode.Create));

                return uploadPath;

            }
            return "No file selected for upload.";
        }
    }
}
