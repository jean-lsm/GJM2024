using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainScene : MonoBehaviour
{
    public MainCharacter mainCharacter;
    public HudManager hudManager;
    public float timeSunrise = 600;
    public GameObject objective;

    void Start()
    {
        mainCharacter = FindAnyObjectByType<MainCharacter>();
        hudManager = FindAnyObjectByType<HudManager>();
        StartCoroutine(LoseAdrenalineContinuous());
    }

    // Update is called once per frame
    void Update()
    {
        CalculateTimeSunset();
        if(Input.GetKeyDown(KeyCode.Alpha2))    Time.timeScale = 40f;
        if(Input.GetKeyUp(KeyCode.Alpha2))    Time.timeScale = 1f;
    }

    public void CalculateTimeSunset()
    {
        if (timeSunrise < 2)
        {
            Endgame(false);
        }

        if(timeSunrise == 590) 
        {
            hudManager.ShowHideMessage("Talvez eu devesse <color=Green>APERTAR E</color> para observar melhor as estrelas...");
        }

        if(timeSunrise == 300) 
        {
            hudManager.ShowHideMessage("Estou quase ficando sem tempo!");
        }
    }
    

    public void Endgame(bool status)
    {
        hudManager.EndGame(status);
        mainCharacter.EndGame(status);
    }

    IEnumerator LoseAdrenalineContinuous()
    {
        while (timeSunrise > 0)
        {
            timeSunrise -= 1;
            if (timeSunrise <= 1) timeSunrise = 1;

            // hudManager.debugText.text = "adrenalina: " + timeSunrise;
            hudManager.SunsetBarManager();
            yield return new WaitForSeconds(1f);

        }
    }

    public void GainTime(int reward)
    {
        hudManager.ShowHideMessage("De algum jeito, parece que tenho mais tempo...");
        timeSunrise += reward;
        if (timeSunrise > 600)
        {
            timeSunrise = 600;
        }
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
