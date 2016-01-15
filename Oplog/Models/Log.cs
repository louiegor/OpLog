using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oplog.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string LogDetail { get; set; }
        public DateTime LogTime { get; set; }
        
        public Log ()
        {
            LogTime = DateTime.Now;
        }
    }
}