using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public GameManager gameMainScene;

    public int TowerHealth;
    public int wood, stone;
    public bool playerInRange;
    void Start()
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            gameMainScene.ValidateStationObject();
        }
    }

    public void GainResource(string id, int value)
    {
        switch (id)
        {
            case "wood":
                wood += value;
                break;
            case "stone":
                stone += value;
                break;
        }
    }
    public void Build(string id)
    {
        if (wood - 15 > 0 || stone - 15 > 0)
        {
            wood -= 15;
            stone -= 15;
            Debug.Log("ok");
        }
        else
        {
            Debug.Log("cant");
        }
    }
    public void ChangeHealth(int value)
    {
        TowerHealth += value;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<MainCharacter>())
        {
            playerInRange = true;
            Debug.Log("player enter castle: ");
        }
    }


    private void OnTriggerExit(Collider other) 
    {
        if(other.GetComponent<MainCharacter>())
        {
            playerInRange = false;
            Debug.Log("player exit castle: ");
        }
    }
}
