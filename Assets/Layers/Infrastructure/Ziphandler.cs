using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using UnityEngine;
public class Ziphandler
{

    public List<PicData> loadZipPics(string zipPath)
    {
        List<PicData> picDatas = new List<PicData>();
        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                List<Texture2D> textures = new List<Texture2D>();
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        entry.FullName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                    {
                        using (var stream = entry.Open())
                        {
                            byte[] imageData;
                            using (var memoryStream = new MemoryStream())
                            {
                                stream.CopyTo(memoryStream);
                                imageData = memoryStream.ToArray();
                            }
                            picDatas.Add(new PicData { data = imageData });
                            /*Texture2D texture = new Texture2D(2, 2);
                            texture.LoadImage(imageData);
                            textures.Add(texture);*/
                        }
                    }
                }
                return picDatas;
            }
        }
    }

    public void saveScreenshotToZip(string zipPath, byte[] imageBytes, string fileName)
    {
        
        using (FileStream zipToOpen = new FileStream(zipPath, FileMode.Open))
        {
            using (ZipArchive archive = new ZipArchive(zipToOpen, ZipArchiveMode.Update))
            {
                ZipArchiveEntry imageEntry = archive.CreateEntry(fileName);
                using (var entryStream = imageEntry.Open())
                {
                    entryStream.Write(imageBytes, 0, imageBytes.Length);
                }
            }
        }
    }
}
