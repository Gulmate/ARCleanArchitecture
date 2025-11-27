using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;

public class DocumentationLogger
{
    private string zipPath = null;
    DateTime localDate;

    public void setZipPath(string path)
    {
        zipPath = path;
        var jsonLog = JsonUtility.ToJson(new LogEntry
        {
            timestamp = localDate.ToString("yyyy-MM-dd HH:mm:ss"),
            message = "tutorial loaded",
            attachments = null,
        }, true);
    }

    public void LogToJSON(string message, Dictionary<string, string> addedAttachments=null)
    {
        localDate = DateTime.Now;
        string jsonLog = JsonConvert.SerializeObject(new LogEntry
        {
            timestamp = localDate.ToString("yyyy-MM-dd HH:mm:ss"),
            message = message,
            attachments = addedAttachments,
        }, Formatting.Indented);

        if (File.Exists(zipPath) == false)
        {
            using (FileStream zipToCreate = new FileStream(zipPath, FileMode.Create))
            {
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create))
                {
                    ZipArchiveEntry logEntry = archive.CreateEntry("Logs/log.json");
                    jsonLog = "[\n" + jsonLog + "\n]";
                    using (StreamWriter writer = new StreamWriter(logEntry.Open()))
                    {
                        writer.WriteLine(jsonLog);
                    }
                }
            }
        }
        else
        {
            using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
            {
                using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
                {

                    ZipArchiveEntry logEntry;

                    logEntry = archive.GetEntry("Logs/log.json");
                    string existingContent;
                    using (StreamReader reader = new StreamReader(logEntry.Open()))
                    {
                        existingContent = reader.ReadToEnd();
                    }


                    existingContent = existingContent.TrimEnd('\n', '\r', ' ', ']');


                    jsonLog = existingContent + ",\n" + jsonLog + "\n]";


                    using (StreamWriter writer = new StreamWriter(logEntry.Open()))
                    {
                        writer.WriteLine(jsonLog);
                    }
                }
            }
        }
    }

}
