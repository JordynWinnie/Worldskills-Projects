﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace KazanP1_7_31_2020_Mobile.Models
{
    internal class DepartmentAssetGenericModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        internal class DepartmentLocation
        {
            public string DepartmentName { get; set; }
            public string LocationName { get; set; }
        }
    }
}