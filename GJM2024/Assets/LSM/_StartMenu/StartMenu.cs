using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{

    public GameObject NormalMenu, CreditMenu, StoryMenu, OptionsMenu;
    public TMP_Text StoryText;
    public TMP_Text version;
    public void StartGame() => SceneManager.LoadScene(1);
    public void CloseGame() => Application.Quit();

    public int PageStoryMenu;

    private void Start()
    {
        version.text = Application.version;
    }
    public void OpenCreditMenu()
    {
        CreditMenu.SetActive(true);
        NormalMenu.SetActive(false);
        StoryMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void OpenStoryMenu()
    {
        CreditMenu.SetActive(false);
        NormalMenu.SetActive(false);
        StoryMenu.SetActive(true);
        OptionsMenu.SetActive(false);
        NavigateStoryMenu(1);
    }

    public void OpenNormalMenu()
    {
        CreditMenu.SetActive(false);
        NormalMenu.SetActive(true);
        StoryMenu.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        CreditMenu.SetActive(false);
        NormalMenu.SetActive(false);
        StoryMenu.SetActive(false);
        OptionsMenu.SetActive(true);
    }

    public void NavigateStoryMenu(int i)
    {
        PageStoryMenu += i;
        DisplayStoryMenu();
    }
    public void DisplayStoryMenu()
    {
        switch (PageStoryMenu)
        {
            case 0:
                OpenNormalMenu();
                break;
            case 1:
                StoryText.text =
                "Eu sempre tive um sonho\n" +
                "de encontrar onde as estrelas se reunem, \n" +
                "e enfim descobrir o seu mais profundo segredo. \n" +
                "Sempre acreditei que era impossivel, \n" +
                "até que uma estrela me encontrou\n" +
                "e pediu minha ajuda...";
                break;
            case 2:
                StoryText.text =
                "Viajamos por algum tempo, \n" +
                "e em meus sonhos finalmente chegamos ao local. \n" +
                "Porem <color=red>FALTAVA POUCO TEMPO</color> para o dia raiar. \n" +
                "Logo eu despertaria desta jornada.";
                break;
            case 3:
                StoryText.text =
                 "<color=purple>NO CÉU</color> eu podia ver todas elas, \n" +
                 "e elas viajavam até o seu local de descanso. \n"  +
                 "Enquanto algumas iam embora, \n" +
                 "outras pareciam estar proximas. \n" +
                 "Estas tinham <color=Blue>CORES</color> <color=orange>DIFERENTES</color>, \n" +
                 "e minha estrela queria que eu as conhecesse. \n";
                break;
            case 4:
                StartGame();
                break;

                /*
                */
        }
    }

    IEnumerator _ShowHideMessage()
    {
        // while(canvasGroupMessage.alpha < 1)
        // {
        //     canvasGroupMessage.alpha += 0.2f;
        //     yield return new WaitForSeconds(0.1f);
        // }
        // yield return new WaitForSeconds(5f);
        // while(canvasGroupMessage.alpha > 0.1)
        // {
        //     canvasGroupMessage.alpha -= 0.2f;
        //     yield return new WaitForSeconds(0.1f);
        // }
        yield return null;
    }


}
