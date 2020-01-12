// <copyright file="HomeController.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace HourlyData.Controllers
{
    using HourlyData.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// HomeController with set of Action methods
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// private property for logger
        /// </summary>
        private readonly ILogger<HomeController> logger;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> struct.
        /// </summary>
        /// <param name="logger">logger to log</param>
        public HomeController(ILogger<HomeController> logger)
        {
            this.logger = logger;
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
            AssignmentDbContext dbContext = new AssignmentDbContext();

            /* The below Linq code groups the data on TimSlot Hour 
             * and selects the required column data to generate the response object*/

            var intervalData = dbContext.IntervalData
                .AsEnumerable()
                .GroupBy(row => row.TimeSlot.Hours)
                .Select(grp => new
                {
                    TimeSlot = grp.Key,
                    SlotValue = grp.Select(u => u.SlotVal).Sum() / 2,
                    DeliveryPoint = grp.Select(u => u.DeliveryPoint).FirstOrDefault(),
                    Date = grp.Select(u => u.Date).FirstOrDefault(),
                    Id = grp.Select(u => u.Id).FirstOrDefault()
                });

            return JsonConvert.SerializeObject(intervalData.ToArray());
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
