using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class raycaster : MonoBehaviour
{
    public RaycastHit RaycastHit;
    public Vector3 position, destiny;
    void FixedUpdate()
    {
        Physics.Raycast(position, destiny);
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);

        //if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit, Mathf.Infinity, layerMask))
        { }
    }
}
