public class DTOMessageWrapper
{
    public int Type { get; set; } = 999;
    public string Message { get; set; } = "";
#nullable enable
    public DTOMessageWrapper? Payload { get; set; } = null;
}