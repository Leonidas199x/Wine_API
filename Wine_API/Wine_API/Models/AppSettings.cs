using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wine_API.Models
{
    public class AppSettings
    {
        public string Environment { get; set; }

        public string ConnectionString { get; set; }
    }
}
