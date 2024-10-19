using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
        public GameManager gameMainScene;

    public int TowerHealth;
    public int wood, stone;
    void Start()
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GainResource(string id, int value)
    {
        
    }
    public void ChangeResource(string id, int value)
    {
        if(wood - value < 0)
        {
            Debug.Log("cant");
        }
        else
        {
            Debug.Log("ok");
        }
    }
    public void ChangeHealth(int value)
    {
        TowerHealth += value;
    }
}
