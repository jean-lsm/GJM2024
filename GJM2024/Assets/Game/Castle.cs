using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public GameManager gameManager;

    public int CastleHealth;
    // public int wood, stone;
    public int gold, resource;
    public bool playerInRange;
    public TMP_Text goldText;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(_GainGold());
    }

    // Update is called once per frame
    void Update()
    {
        // if(playerInRange && Input.GetKeyDown(KeyCode.E))
        // {
        //     gameMainScene.ValidateStationObject();
        // }
    }

    IEnumerator _GainGold()
    {
        while(CastleHealth > 0)
        {
            Debug.Log("gain gold");
            gold += 25;
            goldText.text = "Gold: " + gold + "\n" + "R: " + resource;
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
    // public void GainResource(string id, int value)
    // {
    //     switch (id)
    //     {
    //         case "wood":
    //             wood += value;
    //             break;
    //         case "stone":
    //             stone += value;
    //             break;
    //     }
    // }
    public void Build(string id)
    {
        
    }
    public void ChangeHealth(int value)
    {
        CastleHealth += value;
    }

    public void ChangeResource(int value)
    {
        if(resource - value < 0)
        {
            Debug.Log("cant");
            return;
        }
        resource += value;
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
