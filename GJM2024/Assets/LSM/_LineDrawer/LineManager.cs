using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LineManager : MonoBehaviour
{

    public Camera camera;
    public LineRenderer lineRenderer;
    public GameObject brush;
    public Vector2 mousePosition, lastPosition ;

    void Awake()
    {
        camera = Camera.main;

    }

    void Update()
    {
        mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
        Debug.Log(lineRenderer.positionCount);
        
            Drawing();
    }


    void Drawing()
    {
        if(Input.GetMouseButtonDown(0))
        {
            CreateBrush();
        }
            

        if(Input.GetMouseButton(0))
        {
            Vector2 mousePosition = camera.ScreenToWorldPoint(Input.mousePosition);
            if(mousePosition != lastPosition)
            {
                AddPoint(mousePosition);
                lastPosition = mousePosition;
            }
        }
            
            

        if(Input.GetMouseButtonUp(0))
        {
            
        }



        
    }

    public void CreateBrush()
    {
        lineRenderer.positionCount = 0;
        GameObject brushInstance = Instantiate(brush);
        lineRenderer = brushInstance.GetComponent<LineRenderer>();
        lineRenderer.SetPosition(0, mousePosition);
        lineRenderer.SetPosition(1, mousePosition);
    }

    public void AddPoint(Vector2 pointerPosition)
    {
        lineRenderer.positionCount++;
        int positionIndex = lineRenderer.positionCount - 1;
        lineRenderer.SetPosition(positionIndex, pointerPosition);
    }
}
