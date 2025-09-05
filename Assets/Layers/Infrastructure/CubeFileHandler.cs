using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CubeFileHandler
{
    private readonly string saveFilePath = Application.dataPath + "/Saves/Cube.json";

    public void Save(Color cubeColor, float cubeSize, Vector3 cubeRotation)
    {
        SaveCube saveCube = new SaveCube(cubeSize, new List<float> { cubeColor.r, cubeColor.g, cubeColor.b, cubeColor.a }, new List<float> { cubeRotation.x, cubeRotation.y, cubeRotation.z });
        string json = JsonUtility.ToJson(saveCube);
        File.WriteAllText(saveFilePath, json);
    }

    public SaveCube Load()
    {
        string json = File.ReadAllText(saveFilePath);
        SaveCube saveCube = JsonUtility.FromJson<SaveCube>(json);
        return saveCube;
    }
}
