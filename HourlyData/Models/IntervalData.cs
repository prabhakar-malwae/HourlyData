// <copyright file="IntervalData.cs" company="Company">
// Copyright (c) Company. All rights reserved.
// </copyright>

namespace HourlyData.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// IntervalData Entity Model class 
    /// </summary>
    public partial class IntervalData
    {
        /// <summary>
        /// ID column
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// DeliveryPoint column
        /// </summary>
        public long DeliveryPoint { get; set; }

        /// <summary>
        /// Date column
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// TimeSlot column
        /// </summary>
        public TimeSpan TimeSlot { get; set; }

        /// <summary>
        /// SlotVal column
        /// </summary>
        public decimal? SlotVal { get; set; }
    }
}
