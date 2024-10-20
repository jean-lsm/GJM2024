using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BuildNode : MonoBehaviour
{
    public Castle castle;
    public bool playerInRange, built;
    public GameManager gameMainScene;
    public GameObject BuildButton, UpgradeButton;
    public Tower tower;

    void Start()
    {
        gameMainScene = FindAnyObjectByType<GameManager>();
        castle = FindAnyObjectByType<Castle>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BuildTower(string towerId)
    {
        if (castle.gold - 36 > 0)
        {
            castle.gold -= 36;
            BuildButton.SetActive(false);
            built = true;
            tower.gameObject.SetActive(true);
            Debug.Log("ok");
        }
        else
        {
            Debug.Log("cant build");
        }


    }

    public void UpgradeTower(string id)
    {
        switch (id)
        {
            case "resourceBettle":
                if ((castle.gold - 12 > 0) && (castle.resourceBettle - 20 > 0))
                {
                    castle.resourceBettle -= 20;
                    castle.gold -= 12;
                    UpgradeButton.SetActive(false);
                    tower.tripleShot = true;
                    Debug.Log("comprou triple shot");
                }
                else
                {
                    Debug.Log("sem resourceBettle");
                }
                break;
            case "resourceSlime":
                if ((castle.gold - 12 > 0) && (castle.resourceSlime - 20 > 0))
                {
                    castle.resourceSlime -= 20;
                    castle.gold -= 12;
                    UpgradeButton.SetActive(false);
                    tower.tripleShot = true;
                    Debug.Log("comprou triple shot");
                }
                else
                {
                    Debug.Log("sem resourceBettle");
                }
                break;
            case "resourceGhost":
                if ((castle.gold - 12 > 0) && (castle.resourceGhost - 20 > 0))
                {
                    castle.resourceBettle -= 20;
                    castle.gold -= 12;
                    UpgradeButton.SetActive(false);
                    tower.tripleShot = true;
                    Debug.Log("comprou triple shot");
                }
                else
                {
                    Debug.Log("sem resourceBettle");
                }
                break;
        }
        Debug.Log(id);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<MainCharacter>())
        {
            playerInRange = true;
            if (!built)
            {
                BuildButton.SetActive(playerInRange);
            }
            else
            {
                UpgradeButton.SetActive(playerInRange);
            }
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Debug.Log("player range in buildNode: " + this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MainCharacter>())
        {
            playerInRange = false;
            if (!built)
            {
                BuildButton.SetActive(playerInRange);
            }
            else
            {
                UpgradeButton.SetActive(playerInRange);
            }
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            BuildButton.SetActive(false);
            Debug.Log("player range out buildNode: " + this);
        }
    }
}

