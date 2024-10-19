using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class HudManager : MonoBehaviour
{
    public MainScene mainScene;
    public Scrollbar adrenalineBar;

    public GameObject pauseMenu, gameEndMenu;
    public Image gameEndGood, gameEndBad;
    public TMP_Text endText;
    public CanvasGroup canvasGroupMessage;
    public TMP_Text messageText;
    public TMP_Text DEBUGTEXT;

    private void Start()
    {
        mainScene = FindObjectOfType<MainScene>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
           OpenCloseMenu();
        }
        

    }





    public void OpenCloseMenu()
    {
        pauseMenu.SetActive(!pauseMenu.activeSelf);
        Cursor.visible = !Cursor.visible;
        if(pauseMenu.activeSelf) Time.timeScale = 0;
        else Time.timeScale = 1;            
        Debug.Log(Time.timeScale);
    }



    // public void SunsetBarManager()
    // {
    //     adrenalineBar.size = mainScene.timeSunrise / 600;
    //     // Debug.Log(mainScene.timeSunrise / 600);
    // }

    public void EndGame(bool status)
    {
        gameEndMenu.SetActive(true);
        Cursor.visible = true;
        if (status)
        {
            gameEndGood.gameObject.SetActive(true);
            endText.text =
                "Minha jornada chegou ao fim\n" +
                "e juntos conseguimos reunir as estrelas. \n" +
                "Minha estrela me mostrou muitas maravilhas, \n" +
                "mas agora tenho que acordar...?";
        }
        else
        {
            gameEndBad.gameObject.SetActive(true);
                endText.text =
                "Infelizmente minha jornada chegou ao fim \n" +
                "e não consegui encontrar as estrelas. \n" +
                "Talvez na proxima vez \n" +
                "eu tenha sucesso.";

        }
    }


    public void ShowHideMessage(string message)
    {
        canvasGroupMessage.gameObject.SetActive(true);
        messageText.text = message;
        StartCoroutine(_ShowHideMessage());
    }
    IEnumerator _ShowHideMessage()
    {
        
        while (canvasGroupMessage.alpha != 1f)
        {
            canvasGroupMessage.alpha += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(5f);
        while (canvasGroupMessage.alpha != 0f)
        {
            canvasGroupMessage.alpha -= 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        canvasGroupMessage.gameObject.SetActive(false);
        yield return null;
        StopCoroutine(_ShowHideMessage());
    }


}
