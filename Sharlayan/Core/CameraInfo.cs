using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharlayan.Core
{
    using Sharlayan.Core.Interfaces;

    public class CameraInfo : ICameraInfo
    {
        public float Heading { get; set; }
        public float Elevation { get; set; }
        public byte Mode { get; set; }
        public bool IsValid { get; set; } = false;

    }
}
