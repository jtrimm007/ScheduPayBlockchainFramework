﻿//using System;
//using System.Collections.Generic;


//namespace ScheduPayBlockchainFramework
//{
//    public class ServiceDetails
//    {
//        public bool Mowed { get; set; }
//        public double MowingRate { get; set; }

//        /// <summary>
//        /// The frequency is measured in days.
//        /// </summary>
//        /// <value>
//        /// The frequency.
//        /// </value>
//        public int Frequency { get; set; }
//        public string RescheduledTimestamp { get; set; }
//        public string PropertyId { get; set; }
//        public List<Service> ListOfServices { get; set; }
//        public InvoiceDetails Invoice { get; set; }

//        public ServiceDetails(bool mowed, int frequency, string rescheduledTimestamp, string propertyId)
//        {
//            Mowed = mowed;
//            Frequency = frequency;
//            RescheduledTimestamp = rescheduledTimestamp;
//            PropertyId = propertyId;
//        }

//        public ServiceDetails(bool mowed, int frequency, string propertyId)
//        {
//            Mowed = mowed;
//            Frequency = frequency;
//            PropertyId = propertyId;
//        }

//        public ServiceDetails()
//        {
//        }

//        public ServiceDetails(bool mowed, string propertyId)
//        {
//            Mowed = mowed;
//            PropertyId = propertyId;
//        }
//    }
//}