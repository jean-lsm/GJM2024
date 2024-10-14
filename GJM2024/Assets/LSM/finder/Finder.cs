using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject gameObjectToFind;


    void FindObject()
    {
        //gameObjectToFind = GameObject.Find("43");
        //gameObjectToFind = GameObject.Find("2/32/43");
        //gameObjectToFind = this.GetComponent<GameObject>();
    }
}
