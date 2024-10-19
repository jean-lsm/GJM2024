using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Station : MonoBehaviour
{

    public GameManager gameMainScene;
    public bool playerInRange;


    private void Start() 
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
        // gameMainScene.stations.Add(this);
    }

    private void Update() 
    {
        if(playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            gameMainScene.ValidateStationObject();
        }
    }

    
    private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<MainCharacter>())
        {
            // gameMainScene.playerCurrentStation = this;
            playerInRange = true;
            Debug.Log("player enter base: ");
        }
    }


    private void OnTriggerExit(Collider other) {
        if(other.GetComponent<MainCharacter>())
        {
            // gameMainScene.playerCurrentStation = null;
            playerInRange = false;
            Debug.Log("player exit base: ");
        }
    }



}
