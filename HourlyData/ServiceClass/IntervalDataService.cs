// <copyright file="IntervalDataService.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace HourlyData.ServiceClass
{
    using HourlyData.Models;
    using HourlyData.ServiceInterface;
    using Newtonsoft.Json;
    using System.Linq;

    /// <summary>
    /// IntervalDataService implements the interface IIntervalDataService 
    /// </summary>
    public class IntervalDataService : IIntervalDataService
    {
         /// <summary>
        /// IntervalData method returns jsonstring.
        /// </summary>
        public string IntervalData()
        {
            // Create an DB Context Object
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
    }
}

