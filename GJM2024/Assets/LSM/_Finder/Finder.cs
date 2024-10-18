using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class Finder
{
    public GameObject gameObjectToFind;
    public void FindObjectByName(string Path)
    {
        gameObjectToFind = GameObject.Find("43");
            //exemplo
        //gameObjectToFind = GameObject.Find("43");
        //gameObjectToFind = GameObject.Find("2/32/43");
    }

    // void FindObjectByComponent(Component teste)
    // {
    //     gameObjectToFind = GetComponent<teste>();
    // }
    
}
