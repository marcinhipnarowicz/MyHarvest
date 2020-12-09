using System;
using System.Collections.Generic;
using System.Text;

namespace MyHarvest.ViewModels
{
    public class BaseVm
    {
        public int MessageType { get; set; }

        public string Message { get; set; }

        public Object ReturnedObject { get; set; }
    }
}