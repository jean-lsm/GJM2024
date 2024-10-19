using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public int heatlhEnemy;
    void Start()
    {
        //StartCoroutine(teste());
        
    }

    private void Update()
    {
        agent.destination = target.position;
        if(heatlhEnemy < 1) Destroy(this.gameObject);
        //transform.LookAt(player);
    }
    IEnumerator teste()
    {
        while(transform.position != target.position)
        {
            yield return new WaitForSeconds(0.001f);
            transform.LookAt(target);
            transform.Translate(0f,0f,0.01f);
        }
    } 
}
