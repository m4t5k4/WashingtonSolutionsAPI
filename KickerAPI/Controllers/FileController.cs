using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using KickerAPI.Data;
using KickerAPI.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using File = KickerAPI.Models.File;

namespace KickerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private IWebHostEnvironment _hostingEnvironment;
        private readonly KickerContext _context;

        public FileController(IWebHostEnvironment environment, KickerContext context)
        {
            _hostingEnvironment = environment;
            _context = context;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            var uploads = Path.Combine(_hostingEnvironment.WebRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            if (file.Length > 0)
            {
                var filePath = Path.Combine(uploads, file.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }

            var fileModel = new File { Name = file.FileName, Path = "uploads/" + file.FileName };
            _context.Files.Add(fileModel);
            await _context.SaveChangesAsync();
            
            return Ok(fileModel.Path);
        }
    }
}