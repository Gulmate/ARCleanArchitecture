using System;
using System.IO;
using UnityEngine;

public class LoggerService:ILoggerService
{
    DateTime localDate;
    private readonly string path= Application.dataPath + "/Logs/log";
    public void Log(string message)
    {
        localDate = DateTime.Now;
        string savePath = path + localDate.ToString("yyyy-MM-dd") + ".txt";
        message= DateTime.Now.ToString("HH:mm:ss")+ " - " + message;
        if (File.Exists(savePath))
        {
            File.AppendAllText(savePath, message + "\n");
        }
        else
        {
            File.WriteAllText(savePath, message+ "\n");
        }
            
    }

    public void LoadLogs()
    {
        if (Directory.Exists(Application.dataPath + "/Logs"))
        {
            DirectoryInfo dir = new DirectoryInfo(Application.dataPath + "/Logs");
            FileInfo[] info = dir.GetFiles("*.txt");
            foreach (FileInfo f in info)
            {
                Debug.Log(f.Name);
            }
        }
        else
        {
            Debug.Log("No log files found.");
        }
    }
}
