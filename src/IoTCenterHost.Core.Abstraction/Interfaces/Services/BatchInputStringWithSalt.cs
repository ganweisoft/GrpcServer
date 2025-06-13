using System.Collections.Generic;

namespace IoTCenterHost.Core.Abstraction.Interfaces.Services
{
    public class BatchInputStringWithSalt
    {
        public List<InputStringItem> PlainTexts { get; set; }

        public string SecurityStamp { get; set; }
    }
}
