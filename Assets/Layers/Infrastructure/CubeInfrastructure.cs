using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class CubeInfrastructure: ICubeInfrastructure
{
    private readonly CubeSize cubeSize=new CubeSize();
    private readonly CubeColor cubeColor= new CubeColor();
    private readonly CubeRotation cubeRotation= new CubeRotation();

    string saveFilePath = Application.dataPath + "/Saves/Cube.json";

    public void Rotate(Vector3 angles)
    {
        cubeRotation.angles = angles;
    }
    public Vector3 GetRotation()
    {

        return cubeRotation.angles;
    }

    public void ReColor(Color newColor)
    {
        cubeColor.color = newColor;
    }

    public Color GetColor()
    {
        return cubeColor.color;
    }

    public void Resize(float newSize)
    {
        cubeSize.size = newSize;
    }

    public float GetSize()
    {
        return cubeSize.size;
    }

    public void Save()
    {
        SaveCube saveCube=new SaveCube(cubeSize.size, new List<float> { cubeColor.color.r, cubeColor.color.g, cubeColor.color.b, cubeColor.color.a }, new List<float> { cubeRotation.angles.x, cubeRotation.angles.y, cubeRotation.angles.z });
        Debug.Log(saveCube._size);
        string json= JsonUtility.ToJson(saveCube);
        File.WriteAllText(saveFilePath, json);
    }

    public void Load()
    {
        string json = File.ReadAllText(saveFilePath);
        SaveCube saveCube = JsonUtility.FromJson<SaveCube>(json);
        cubeSize.size = saveCube._size;
        cubeColor.color = new Color(saveCube._colorCords[0], saveCube._colorCords[1], saveCube._colorCords[2], saveCube._colorCords[3]);
        cubeRotation.angles = new Vector3(saveCube._rotationCords[0], saveCube._rotationCords[1], saveCube._rotationCords[2]);
    }
}
