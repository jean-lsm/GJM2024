using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public MainCharacter mc;
    public TMP_Text contador;
    public List<door> doors;

    public List<GameObject> tyles;

    public GameObject tyle1;
    public GameObject tyle2;
    public GameObject tyle3;
    public GameObject tyle4;
    public GameObject tyle5;
    public GameObject tyle6;
    public GameObject tyle7;
    public GameObject tyle8;
    public GameObject tyle9;
    public NavMeshSurface navMeshSurface;

    public GameObject spawnPoint;

    public GameObject tyleSelect;

    public CanvasGroup canvasGroup;

    public List<GameObject> elevators;

    public AudioSource audioSource;
    public AudioClip callElevator, openElevator;

    public bool elevatorCalled;
    public int random;


    void Start()
    {
        
        GenerateTyle();
        
    }

    // Update is called once per frame
    void Update()
    {
        //contador.text = mc.time.ToString();
        if(Input.GetKeyDown(KeyCode.J))
        {
            StartCoroutine(_FadeIn());
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartCoroutine(_FadeOut());
        }
    }





    public void GenerateTyle()
    {
        StartCoroutine(_FadeOut());
        mc.TeleportPlayer(spawnPoint);

        //tyleSelect = tyles[Random.Range(0, tyles.Count)];
        tyleSelect = tyles[0];
        Instantiate(tyleSelect, tyle1.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle2.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle3.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle4.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle5.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle6.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle7.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle8.transform);

        tyleSelect = tyles[Random.Range(0, tyles.Count)];
        Instantiate(tyleSelect, tyle9.transform);

        navMeshSurface = GetComponentInChildren<NavMeshSurface>();
        navMeshSurface.BuildNavMesh();
        Debug.Log("aqui");
        random = Random.Range(0, elevators.Count);
        elevators[random].SetActive(true);
       
    }
    

    //IEnumerator _Fade(string modo, Coroutine param)
    IEnumerator _FadeIn()
    {

        while (canvasGroup.alpha != 1)
            {
                Debug.Log("in");
                canvasGroup.alpha += 0.1f;
                yield return new WaitForSeconds(0.1f);
            }
            mc.TeleportPlayer(spawnPoint);
        StopCoroutine(_FadeIn());
    }
        
        
        

    IEnumerator _FadeOut()
    {
        while (canvasGroup.alpha != 0)
        {
            Debug.Log("out");
            canvasGroup.alpha -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
        StopCoroutine(_FadeOut());
    }

public void CallElevator()
    {
        StartCoroutine(_CallElevator());
    }

    IEnumerator _CallElevator()
    {
        if(!elevatorCalled)
        {
            elevatorCalled = true;
            elevators[random].GetComponent<AudioSource>().PlayOneShot(callElevator);
            elevators[random].SetActive(false);
            //yield return new WaitForSeconds(60f);
            yield return new WaitForSeconds(10f);
            random = Random.Range(0, elevators.Count);
            elevators[random].SetActive(true);
            yield return null;
            
        }
        else
        {
            StartCoroutine(_FadeIn());
            yield return new WaitForSeconds(3f);
            GenerateTyle();
            foreach (GameObject elevator in elevators)
            {
                elevator.SetActive(false);
            }
            foreach (door door in doors)
            {
                door.closed = true;
                door.opening = false;
                door.animator.Play("reset");
            }
        }
        
    }


}
