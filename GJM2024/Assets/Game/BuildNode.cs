using System.Collections;
using System.Collections.Generic;
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
        if (castle.gold - 160 > 0)
        {
            castle.gold -= 160;
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
        Debug.Log(id);
        if (castle.resource - 20 > 0)
        {
            switch (id)
            {
                case "tripleShot":
                    castle.resource -= 20;
                    UpgradeButton.SetActive(false);
                    tower.tripleShot = true;
                    Debug.Log("ok");
                break;
                case "fastShot":
                    castle.resource -= 20;
                    UpgradeButton.SetActive(false);
                    tower.timeToShoot = 0.75f;
                    Debug.Log("ok");
                break;
                
            }
            
        }
        else
        {
            Debug.Log("cant upgrade");
        }
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

