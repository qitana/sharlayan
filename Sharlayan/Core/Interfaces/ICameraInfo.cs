namespace Sharlayan.Core.Interfaces
{
    public interface ICameraInfo
    {
        float Heading { get; set; }
        float Elevation { get; set; }
        byte Mode { get; set; }
        bool IsValid { get; set; }
    }
}
