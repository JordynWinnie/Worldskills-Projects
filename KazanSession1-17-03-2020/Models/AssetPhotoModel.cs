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

namespace KazanSession1_17_02_2020.Models
{
    public class AssetPhotoModel
    {
        public long ID { get; set; }
        public long AssetID { get; set; }
        public byte[] AssetPhoto1 { get; set; }
    }
}