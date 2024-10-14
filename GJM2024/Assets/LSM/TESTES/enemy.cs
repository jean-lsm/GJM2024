using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{

    public Transform player;
    public NavMeshAgent agent;
    void Start()
    {
        //StartCoroutine(teste());
        
    }

    private void Update()
    {
        agent.destination = player.position;
        //transform.LookAt(player);
    }
    IEnumerator teste()
    {
        while(transform.position != player.position)
        {
            yield return new WaitForSeconds(0.001f);
            transform.LookAt(player);
            transform.Translate(0f,0f,0.01f);
        }
        
    }
}
