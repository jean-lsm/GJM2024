using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable] 
public class GameManager : MonoBehaviour
{
    public MainCharacter mainCharacter;
    public HudManager hudManager;
    public GameObject objective;
    public Tower tower;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCharacter = FindAnyObjectByType<MainCharacter>();
        hudManager = FindAnyObjectByType<HudManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public List<Station> stations;
    public List<Object> objects;
    public Station playerCurrentStation;
    public Object playerCurrentObject;
    

    public void ValidateStationObject()
    {
            tower.GainResource(mainCharacter.objectSelected.objectId, mainCharacter.objectSelected.amount);
    }










    



    public void Endgame(bool status)
    {
        
    }

        public void CloseGame()
    {
        Application.Quit();
    }

    public void Restart()
    {
        string cena = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(cena);
    }


}
