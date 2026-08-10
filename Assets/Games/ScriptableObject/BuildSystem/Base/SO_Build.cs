using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SO_Build", menuName = "Scriptable Objects/Build")]
public class SO_Build : ScriptableObject
{
    public string dame;
    public string description;
    public int price;
    public GameObject buildGameObject;
}
