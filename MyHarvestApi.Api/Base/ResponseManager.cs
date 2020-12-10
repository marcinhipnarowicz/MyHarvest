using MyHarvestApi.Api.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyHarvestApi.Api
{
    public class ResponseManager
    {
        public static ResponseActionResult GenerateResponse(string message, int meesageType, object returnedObject)
        {
            return new ResponseActionResult
            {
                Message = message,
                MessageType = meesageType,
                ReturnedObject = returnedObject,
            };
        }
    }
}