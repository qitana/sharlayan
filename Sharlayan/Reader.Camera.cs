namespace Sharlayan
{
    using System;
    using Sharlayan.Models.ReadResults;

    static partial class Reader
    {
        public static bool CanGetCameraInfo()
        {
            var canRead = Scanner.Instance.Locations.ContainsKey(Signatures.CameraKey);
            if (canRead)
            {
                // OTHER STUFF?
            }

            return canRead;
        }

        public static CameraResult GetCameraInfo()
        {
            var result = new CameraResult();

            if (!CanGetCameraInfo() || !MemoryHandler.Instance.IsAttached)
            {
                return result;
            }

            try
            {
                var cameraAddress = (IntPtr)Scanner.Instance.Locations[Signatures.CameraKey];

                if (cameraAddress.ToInt64() > 0)
                {
                    var heading = MemoryHandler.Instance.GetSingle(cameraAddress, MemoryHandler.Instance.Structures.CameraInfo.Heading);
                    var elevation = MemoryHandler.Instance.GetSingle(cameraAddress, MemoryHandler.Instance.Structures.CameraInfo.Elevation);
                    var mode = MemoryHandler.Instance.GetByte(cameraAddress, MemoryHandler.Instance.Structures.CameraInfo.Mode);

                    result.CameraInfo.Heading = heading;
                    result.CameraInfo.Elevation = elevation;
                    result.CameraInfo.Mode = mode;

                    if (Math.Abs(heading) <= Math.PI && Math.Abs(elevation) <= Math.PI)
                    {
                        result.CameraInfo.IsValid = true;
                    }
                }
            }
            catch (Exception ex)
            {
                MemoryHandler.Instance.RaiseException(Logger, ex, true);
            }

            return result;
        }

    }
}
