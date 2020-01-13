// <copyright file="HomeController.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace HourlyData.Controllers
{
    using HourlyData.ServiceInterface;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// HomeController with set of Action methods
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// private property for IInterrvalDataService
        /// </summary>
        private readonly IIntervalDataService intervalDataService;


        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> struct.
        /// </summary>      
        public HomeController(IIntervalDataService intervalDataService)
        {
            this.intervalDataService = intervalDataService;
        }

        /// <summary>
        /// Index Action method 
        /// </summary>
        /// <returns>Returns the ActionResult</returns>
        public IActionResult Index()
        {
            return this.View();
        }

        /// <summary>
        /// To to get IntervalData as Json string.
        /// </summary>      
        /// <returns>Json String</returns>
        [HttpGet]
        public string GetIntervalData()
        {
            //Returns Interval Data
            return this.intervalDataService.IntervalData();
        }

        /// <summary>
        /// To to get the tenant information from Ajax function for Update Tenant
        /// </summary>     
        /// <returns>Returns ActionResult</returns>
        public IActionResult Privacy()
        {
            return this.View();
        }
    }
}
