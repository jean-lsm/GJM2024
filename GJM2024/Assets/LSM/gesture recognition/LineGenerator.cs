using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineGenerator : MonoBehaviour
{
    public GameObject linePrefab;
    MouseDraw activeLine;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetMouseButton(0))
        // {
        //     GameObject newLine = Instantiate(linePrefab);
        //     activeLine = newLine.GetComponent<MouseDraw>();
        // }

        // if(Input.GetMouseButton(0))
        // {
        //     activeLine = null;
        // }

        // if(activeLine != null)
        // {
        //     Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     activeLine.UpdateLine(mousePosition);
        // }

         if (Input.GetMouseButton(0))
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Debug.Log(mousePosition);
        }

        
    }
}
