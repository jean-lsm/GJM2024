using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform target;
    public NavMeshAgent agent;
    public int heatlhEnemy;
    public GameObject drop;
    public GameManager gameManager;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.OnChangeNavMesh +=ChangeNavMesh;
        // gameManager.enemyList.Add(this.gameObject);
        target = gameManager.castle.transform;
        ChangeNavMesh();
        // StartCoroutine(Move());
    }

    private void ChangeNavMesh()
    {
        agent.destination = target.position;
        transform.LookAt(target);
        if(heatlhEnemy < 1)
        {
            Instantiate(drop);
            gameManager.enemyList.Remove(this.gameObject);
            gameManager.VerifyWave();
            Destroy(this.gameObject);
            
        } 
        //transform.LookAt(player);
    }
    public void RecalculatePath()
    {
        Debug.Log("aqui enemy");
        agent.isStopped = true;
        // agent.ResetPath();
        Invoke("outro", 3);
        
    }

    public void outro()
    {
        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }        
        
        // agent.CalculatePath(this.transform.position, target.transform.position, agent.areaMask, agent.path);
        
        
        // agent.CalculatePath(Vector3 sourcePosition, Vector3 targetPosition, int areaMask, AI.NavMeshPath path);
        // agent.CalculatePath()
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.CompareTag("aros"))
        {
            this.transform.SetParent(other.transform, true);
        }
        
    }
    
}
