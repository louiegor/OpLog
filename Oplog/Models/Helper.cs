﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oplog.Models
{
    public static class Helper
    {
        public static File NotAvailablePicture()
        {
            var na = new File
                {
                    Name = "Not_available_icon.jpg",
                    Path = @"~\Images\"
                };
            return na;
        }
    }
}