using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class GameManager : MonoBehaviour
{
    public MainCharacter mainCharacter;
    public HudManager hudManager;
    public Castle castle;
    public GameObject currentAro;
    public List<GameObject> aros;
    public int arosIndex;
    public GameObject enemy, enemySpawnPoint;
    public List<GameObject> enemyList;
    public enum Wave { wave1, wave2, wave3 };
    public Wave wave;
    public NavMeshSurface navMeshSurface;
    public NavMeshData data;

    public event Action OnChangeNavMesh;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        mainCharacter = FindAnyObjectByType<MainCharacter>();
        hudManager = FindAnyObjectByType<HudManager>();
        castle = FindAnyObjectByType<Castle>();
        StartCoroutine(_SpawnEnemies());
        wave = Wave.wave1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arosIndex++;
            if(arosIndex > aros.Count) arosIndex = 0;
            currentAro = aros[arosIndex];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arosIndex--;
            if(arosIndex < 0) arosIndex = aros.Count;
            currentAro = aros[arosIndex];
        }





        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            currentAro.transform.Rotate(0, 0, +30);
            navMeshSurface.UpdateNavMesh(data);
            OnChangeNavMesh?.Invoke();
            // Invoke("testenavAgente", 2);
        }



        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            currentAro.transform.Rotate(0, 0, -30);
            
            // Invoke("testenavAgente", 2);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            navMeshSurface.BuildNavMesh();
            foreach (GameObject enemy in enemyList)
        {
            enemy.GetComponent<enemy>().RecalculatePath();
        }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            enemyList.Add(Instantiate(enemy, enemySpawnPoint.transform.position, Quaternion.identity));
        }
    }

    public void testenavAgente()
    {
        Debug.Log("aqui");
        // navMeshSurface.BuildNavMesh();
        Invoke("teste2", 5);
                

    }

    public void teste2()
    {
        foreach (GameObject enemy in enemyList)
        {
            enemy.GetComponent<enemy>().RecalculatePath();
        }
    }



    // public NavMeshAgent navMeshAgent;

    // IEnumerator _RotateAros()
    // {
    //     yield return new WaitForSeconds(5);
    //     Debug.Log("aqui");
    //     navMeshSurface.BuildNavMesh();
    // }
    IEnumerator _SpawnEnemies()
    {
        yield return new WaitForSeconds(0);
        SpawnEnemies();
        yield return null;
    }

    public void SpawnEnemies()
    {
        if (wave == Wave.wave1)
        {
            for (int i = 0; i < 4; i++)
            {
                enemyList.Add(Instantiate(enemy, enemySpawnPoint.transform.position, Quaternion.identity));
            }
        }
        if (wave == Wave.wave2)
        {
            for (int i = 0; i < 6; i++)
            {
                enemyList.Add(Instantiate(enemy, enemySpawnPoint.transform.position, Quaternion.identity));
            }
        }
        if (wave == Wave.wave3)
        {
            for (int i = 0; i < 8; i++)
            {
                enemyList.Add(Instantiate(enemy, enemySpawnPoint.transform.position, Quaternion.identity));
            }
        }
    }

    public void VerifyWave()
    {
        Debug.Log("verify wave:" + wave.ToString());
        if (wave == Wave.wave1)
        {
            if (enemyList.Count == 0)
            {
                wave = Wave.wave2;
                SpawnEnemies();
            }
        }
        if (wave == Wave.wave2)
        {
            if (enemyList.Count == 0)
            {
                wave = Wave.wave3;
                SpawnEnemies();
            }
        }
        if (wave == Wave.wave2)
        {
            if (enemyList.Count == 0)
            {
                hudManager.ShowHideMessage("Finalizou!", 5);
            }
        }
    }

    // public List<Object> objects;

    // public Object playerCurrentObject;
    // public BuildNode playerCurrentBuildNode;


    // public void ValidateStationObject()
    // {
    //         tower.GainResource(mainCharacter.objectSelected.objectId, mainCharacter.objectSelected.amount);
    // }














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
