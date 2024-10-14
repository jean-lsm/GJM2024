using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MouseDraw : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public Vector3 mousePosition;
    public Vector3 mousePreviousPosition;
    public List<Vector2> points;

    public float minDist = 0.1f;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        // mousePreviousPosition = transform.position;
        // lineRenderer.positionCount = 1;
        
    }


    void SetPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count -1, point);
    }

    public void UpdateLine(Vector2 posiition)
    {
        if(points == null)
        {
            points = new List<Vector2>();
            SetPoint(posiition);
            return;
        }
        if(Vector2.Distance(points.Last(), posiition) > minDist)
        {
            SetPoint(posiition);
        }
    }
    void Update()
    {



        // if (Input.GetMouseButtonDown(0))
        // {
        //     lineRenderer.positionCount = 0;
        // }

        // if (Input.GetMouseButton(0))
        // {
        //     mousePosition = Input.mousePosition;
        //     mousePosition.z = -1;
        //     if (Vector3.Distance(mousePosition, mousePreviousPosition) > minDist)
        //     {
        //         if(mousePreviousPosition == transform.position)
        //         {
        //             lineRenderer.SetPosition(0, mousePosition);
        //         }
        //         lineRenderer.positionCount++;
        //         lineRenderer.SetPosition(lineRenderer.positionCount - 1, mousePosition);
        //         mousePreviousPosition = mousePosition;
        //     }
        // }
        // mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        // Debug.Log(Input.mousePosition);


    }
}
