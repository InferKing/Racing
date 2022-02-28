using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField] private GameObject[] gObjs;
    public static GameObject[] gameObjects;

    private void Start()
    {
        gameObjects = new GameObject[gObjs.Length];
        for (int i = 0; i < gObjs.Length; i++)
        {
            gameObjects[i] = gObjs[i];
        }
    }
}
