using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Castle : MonoBehaviour
{
    public GameManager gameManager;

    public int CastleHealth;
    // public int wood, stone;
    public int gold, resourceBettle, resourceSlime, resourceGhost;
    public bool playerInRange;
    public TMP_Text goldText, beetleText, slimeText, ghostText;
    void Start()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        StartCoroutine(_GainGold());
    }

    // Update is called once per frame
    void Update()
    {
        beetleText.text = "" + resourceBettle;
        slimeText.text = "" + resourceSlime;
        ghostText.text = "" + resourceGhost;
    }

    IEnumerator _GainGold()
    {
        while (CastleHealth > 0)
        {
            Debug.Log("gain gold");
            gold += 5;
            goldText.text = "" + gold;
            yield return new WaitForSeconds(2);
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
    public void ChangeHealth(int value)
    {
        CastleHealth += value;
    }

    public void ChangeResource(int value, string id)
    {
        switch (id)
        {
            case "beetle":
                resourceBettle += value;
                break;
            case "slime":
                resourceSlime += value;
                break;
            case "ghost":
                resourceGhost += value;
                break;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MainCharacter>())
        {
            playerInRange = true;
            Debug.Log("player enter castle: ");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MainCharacter>())
        {
            playerInRange = false;
            Debug.Log("player exit castle: ");
        }
    }
}
