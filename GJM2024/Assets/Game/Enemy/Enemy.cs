using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public string id;
    public Transform target;
    public NavMeshAgent agent;
    public int heatlhEnemy;
    public int damageTaken;
    public GameObject drop;
    public GameManager gameManager;
    
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        gameManager.enemyList.Add(this.gameObject);
        target = gameManager.castle.transform;
        agent.destination = target.position;
        switch (id)
        {
            case "beetle":
                damageTaken = 50;
                break;
            case "slime":
                agent.speed /= 2;
                damageTaken /= 2;
                break;
            case "ghost":
                
                break;
            
        }
    }


    private void Update() 
    {
        if(heatlhEnemy < 1)
        {
            GameObject _drop = drop;
            _drop.GetComponent<Drop>().id = this.id;
            Instantiate(_drop,  this.transform.position, transform.rotation);
            Debug.Log("enemy dead");

            gameManager.castle.gold += 5;
            gameManager.enemyList.Remove(this.gameObject);
            gameManager.VerifyWave();
            Destroy(this.gameObject);
        } 
        
    }
    
    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<Castle>())
        {
            gameManager.castle.ChangeHealth(-25);
        }
        
    }
    
}
