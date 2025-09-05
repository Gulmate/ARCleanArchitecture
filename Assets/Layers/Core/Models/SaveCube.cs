using System;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class SaveCube
{
    [SerializeField]
    private float size;
    public float _size { get => size; set => size = value; }

    [SerializeField]
    private List<float> colorCords = new List<float>();
    public List<float> _colorCords { get => colorCords; set => colorCords = value; }

    [SerializeField]
    private List<float> rotationCords = new List<float>();
    public List<float> _rotationCords { get => rotationCords; set => rotationCords = value; }

    public SaveCube(float newSize, List<float> newColorCords, List<float> newRotationCords)
    {
        size = newSize;
        colorCords = newColorCords;
        rotationCords = newRotationCords;
    }
}
