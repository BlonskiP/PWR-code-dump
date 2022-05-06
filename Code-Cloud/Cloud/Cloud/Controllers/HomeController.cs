using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure; //Namespace for CloudConfigurationManager

using CodeAndCloud.ViewModel;
using Microsoft.AspNetCore.Mvc;
using CodeAndCloud.Services;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;

namespace Cloud.Controllers
{
    public class HomeController : Controller
    {
        private IContactService _service;
        public HomeController(IContactService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Contact(AddContactViewModel model)
        { 
            _service.Add(model);
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
            CloudConfigurationManager.GetSetting("DefaultEndpointsProtocol=https;AccountName=warsztatycodeandcloud4;AccountKey=hklvuMnksQiAfviw90DxUo+QZw8NrUUrbJVi8bVZRVfWW4yQqKkXo8hEpGsfoMpzLNl59KPs8aAZrjFXz8QkOA==;EndpointSuffix=core.windows.net"));
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("myqueue");
            queue.CreateIfNotExistsAsync();
            


            return View();
        }
        
    }
}
