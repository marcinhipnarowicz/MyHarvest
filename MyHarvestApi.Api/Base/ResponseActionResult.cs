using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api.Base
{
    public class ResponseActionResult
    {
        public int MessageType { get; set; }

        public string Message { get; set; }

        public object ReturnedObject { get; set; }
    }
}