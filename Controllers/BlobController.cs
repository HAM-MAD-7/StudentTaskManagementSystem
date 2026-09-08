using Microsoft.AspNetCore.Mvc;
using StudentTaskManagementSystem.Data;
using StudentTaskManagementSystem.Models;
using StudentTaskManagementSystem.Services;

namespace StudentTaskManagementSystem.Controllers
{
    public class BlobController : Controller
    {
        private readonly BlobStorageService _blobStorageService;
        private readonly QueueStorageService _queueStorageService;
        private readonly ApplicationDbContext _context;
        public BlobController(BlobStorageService blobStorageService, ApplicationDbContext context, QueueStorageService queueStorageService)
        {
            _blobStorageService = blobStorageService;
            _context = context;
            _queueStorageService = queueStorageService;
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
                ViewBag.Message = "PLz select a file!";
                return View();
            }
            var blobUrl = await _blobStorageService.UploadAsync(file);
            var studentfile = new StudentFileModel
            {
                FileName = file.FileName,
                BlobName = blobUrl.BlobName,
                ContentType = file.ContentType,
                FileSize = file.Length,
                UploadedAt = DateTime.UtcNow,
                UserId = 1
            };
            _context.StudentFiles.Add(studentfile);
            await _context.SaveChangesAsync();
            string queueMessage = $"File uploaded: {studentfile.FileName} | Blob: {studentfile.BlobName} | UserId: {studentfile.UserId}";
            await _queueStorageService.SendMessageAsync(queueMessage);
            ViewBag.Message = "File uploaded successfully!";
            ViewBag.BlobUrl = blobUrl.BlobUrl;
            return View(); 
        }
        [HttpGet]
        public async Task<IActionResult> Download(string fileName)
        {
            var result = await _blobStorageService.DownloadAsync(fileName);
            return File(result.stream, result.ContentType, result.FileName);
        }
    }
}
