using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildNode : MonoBehaviour
{
    public Castle castle;
    public bool playerInRange, built;
    public GameManager gameMainScene;
    public GameObject BuildButton, UpgradeButton;


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
        castle.Build(towerId);
        BuildButton.SetActive(false);
        built = true;
    }

    public void UpgradeTower(string id)
    {
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

