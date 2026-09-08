using Microsoft.AspNetCore.Mvc;
using StudentTaskManagementSystem.Services;

namespace StudentTaskManagementSystem.Controllers
{
    public class AzureFilesController : Controller
    {
        private readonly AzureFileStorageService _storageService;
        public AzureFilesController(AzureFileStorageService storageService)
        {
            _storageService = storageService;
        }
        [HttpGet]
        public IActionResult Upload()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                ViewBag.Message = "Please select a file";
                return View();
            }
            string fileName = await _storageService.UploadAsync(file);
            ViewBag.Message = $"File uploaded succesfully! file: {fileName}";
            return View();
        }
    }
}
