using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Compression;
using UnityEngine;

internal class LogEntry
{
    public string timestamp;
    public string message;

    [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
    public string screenshot;
}

public class MyLogger
{
    private string zipPath = null;
    DateTime localDate;

    public void setZipPath(string path)
    {
        zipPath = path;
        var jsonLog = JsonUtility.ToJson(new LogEntry
        {
            timestamp = localDate.ToString("yyyy-MM-dd HH:mm:ss"),
            message = "kavefozo tutorial loaded",
            screenshot = null,
        }, true);
    }

    public void LogToJSON(string message, string screenshot = null)
    {
        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                if (archive.GetEntry("Logs/") == null)
                {
                    ZipArchiveEntry logDir = archive.CreateEntry("Logs/");
                }

                localDate = DateTime.Now;

                string jsonLog = JsonConvert.SerializeObject(new LogEntry
                {
                    timestamp = localDate.ToString("yyyy-MM-dd HH:mm:ss"),
                    message = message,
                    screenshot = screenshot
                }, Formatting.Indented);

                ZipArchiveEntry logEntry;
                if (archive.GetEntry("Logs/log.json") == null)
                {
                    logEntry = archive.CreateEntry("Logs/log.json");
                    jsonLog = "[\n" + jsonLog + "\n]";
                }
                else
                {
                    logEntry = archive.GetEntry("Logs/log.json");
                    string existingContent;
                    using (StreamReader reader = new StreamReader(logEntry.Open()))
                    {
                        existingContent = reader.ReadToEnd();
                    }


                    existingContent = existingContent.TrimEnd('\n', '\r', ' ', ']');


                    jsonLog = existingContent + ",\n" + jsonLog + "\n]";
                }

                using (StreamWriter writer = new StreamWriter(logEntry.Open()))
                {
                    writer.WriteLine(jsonLog);
                }
            }
        }

    }

}
