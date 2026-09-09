using Microsoft.AspNetCore.Mvc;
using StudentTaskManagementSystem.Services;

namespace StudentTaskManagementSystem.Controllers
{
    public class AzureTableController : Controller
    {
        private readonly AzureTableStorageService _storageService;
        public AzureTableController(AzureTableStorageService storageService)
        {
            _storageService = storageService;
        }
        [HttpGet]
        public async Task<IActionResult> AddLog()
        {
            await _storageService.AddLogAsync("1", "TestLog");
            return Content("Table storage log added successfully!");
        }
    }
}
