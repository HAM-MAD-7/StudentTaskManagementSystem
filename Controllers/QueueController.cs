using Azure.Storage.Queues.Models;
using Microsoft.AspNetCore.Mvc;
using StudentTaskManagementSystem.Services;

namespace StudentTaskManagementSystem.Controllers
{
    public class QueueController : Controller
    {
        private readonly QueueStorageService _queueStorageService;
        public QueueController(QueueStorageService queueStorageService)
        {
            _queueStorageService = queueStorageService;
        }
        [HttpGet]
        public async Task<IActionResult> Receive()
        {
            QueueMessage? message = await _queueStorageService.ReceiveMessageAsync();
            if(message == null)
            {
                ViewBag.Message = "No messages available";
                return View();
            }
            ViewBag.Message = message.MessageText;
            await _queueStorageService.DeleteMessageAsync(message.MessageId, message.PopReceipt);
            ViewBag.Status = "Message processed and deleted successfully";
            return View();
        }
    }
}
