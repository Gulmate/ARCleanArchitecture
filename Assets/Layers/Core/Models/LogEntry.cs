using Newtonsoft.Json;
using System.Collections.Generic;

public class LogEntry
{
    public string timestamp;
    public string message;

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public Dictionary<string, string> attachments;
}
