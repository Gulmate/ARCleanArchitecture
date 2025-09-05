using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CubeFileHandler
{

    string saveFilePath = Application.dataPath + "/Saves/Cube.json";
    public void Save(Color cubeColor, float cubeSize, Vector3 cubeRotation)
    {
        SaveCube saveCube = new SaveCube(cubeSize, new List<float> { cubeColor.r, cubeColor.g, cubeColor.b, cubeColor.a }, new List<float> { cubeRotation.x, cubeRotation.y, cubeRotation.z });
        Debug.Log(saveCube._size);
        string json = JsonUtility.ToJson(saveCube);
        File.WriteAllText(saveFilePath, json);
    }

    public SaveCube Load()
    {
        string json = File.ReadAllText(saveFilePath);
        SaveCube saveCube = JsonUtility.FromJson<SaveCube>(json);
        /*cubeSize.size = saveCube._size;
        cubeColor.color = new Color(saveCube._colorCords[0], saveCube._colorCords[1], saveCube._colorCords[2], saveCube._colorCords[3]);
        cubeRotation.angles = new Vector3(saveCube._rotationCords[0], saveCube._rotationCords[1], saveCube._rotationCords[2]);*/
        return saveCube;
    }
}
