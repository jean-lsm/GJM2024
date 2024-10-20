using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool playerInRange;
    public GameManager gameMainScene;
    public MainCharacter mainCharacter;
    public string objectId;
    public Sprite sprite;
    public int amount;

    private void Start() 
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
        // gameMainScene.objects.Add(this);
    }

    private void Update() 
    {
         if(playerInRange && Input.GetKeyDown(KeyCode.Q))
        {
            mainCharacter.objectSelected = this;
            // gameMainScene.playerCurrentObject = this;
            Debug.Log("player collect object: " + objectId);
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.GetComponent<MainCharacter>())
        {
            playerInRange = true;
            Debug.Log("player range in object: " + objectId);
            mainCharacter = other.GetComponent<MainCharacter>();
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.GetComponent<MainCharacter>())
        {
            playerInRange = false;
            mainCharacter = null;
            Debug.Log("player range out object: " + objectId);
        }
    }
}
