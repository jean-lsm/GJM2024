using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
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
    public GameObject aro3, aro4, aro5;
    public GameObject enemy, enemySpawnPoint;
    public List<GameObject> enemyList;
    public enum Wave { wave0, wave1, wave2, wave3, wave4, wave5, wave6 };
    public Wave wave;
    public NavMeshSurface navMeshSurface;
    public NavMeshData data;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        // Cursor.visible = false;
        RotateRings();
        navMeshSurface.UpdateNavMesh(data);
        mainCharacter = FindAnyObjectByType<MainCharacter>();
        hudManager = FindAnyObjectByType<HudManager>();
        castle = FindAnyObjectByType<Castle>();
        wave = Wave.wave0;
        // StartCoroutine(_SpawnEnemies());
        VerifyWave();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            arosIndex++;
            if (arosIndex > aros.Count) arosIndex = 0;
            currentAro = aros[arosIndex];
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            arosIndex--;
            if (arosIndex < 0) arosIndex = aros.Count;
            currentAro = aros[arosIndex];
        }

/*

4
10
22
39
62
93
*/



        // if (Input.GetKeyDown(KeyCode.RightArrow))
        // {
        //     currentAro.transform.Rotate(0, 0, +30);
        //     navMeshSurface.UpdateNavMesh(data);

        // }
        // if (Input.GetKeyDown(KeyCode.LeftArrow))
        // {
        //     currentAro.transform.Rotate(0, 0, -30);
        //     navMeshSurface.UpdateNavMesh(data);
        // // }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     RotateRings();
        //     navMeshSurface.UpdateNavMesh(data);
        // }
    }

    public bool prewave;
    IEnumerator _SpawnEnemies()
    {

        switch (wave)
        {
            case Wave.wave1:
                yield return new WaitForSeconds(30f);
                prewave = false;
                for (int i = 0; i < 4; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "beetle";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                break;


            case Wave.wave2:
                castle.ChangeHealth(15);
                yield return new WaitForSeconds(5f);
                prewave = false;
                for (int i = 0; i < 6; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "bettle";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                break;


            case Wave.wave3:
                RotateRings();
                yield return new WaitForSeconds(15f);
                prewave = false;
                
                for (int i = 0; i < 10; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "bettle";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                for (int i = 0; i < 2; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "slime";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                break;


            case Wave.wave4:
                yield return new WaitForSeconds(15f);
                prewave = false;
                for (int i = 0; i < 14; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "bettle";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                for (int i = 0; i < 3; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "slime";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                break;


            case Wave.wave5:
                RotateRings();
                yield return new WaitForSeconds(15f);
                prewave = false;
                
                for (int i = 0; i < 18; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "bettle";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                for (int i = 0; i < 5; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "slime";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                break;


            case Wave.wave6:
                yield return new WaitForSeconds(15f);
                prewave = false;
                for (int i = 0; i < 22; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "bettle";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                for (int i = 0; i < 8; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "slime";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                for (int i = 0; i < 1; i++)
                {
                    GameObject newEnemy = enemy;
                    newEnemy.GetComponent<enemy>().id = "ghost";
                    Instantiate(newEnemy, enemySpawnPoint.transform.position, Quaternion.identity);
                }
                break;
        }
    }

    public void VerifyWave()
    {
        StartCoroutine(_VerifyWave());
    }
    public IEnumerator _VerifyWave()
    {
        Debug.Log("verify wave:" + wave.ToString());
        if (enemyList.Count == 0)
        {
            prewave = true;
        }
        if(!prewave)
        {
            StopCoroutine(_VerifyWave());
        } 
        switch (wave)
        {
            case Wave.wave0:
                    wave = Wave.wave1;
                    StartCoroutine(_SpawnEnemies());
                    yield return null;
                break;
            case Wave.wave1:
                    wave = Wave.wave2;
                    StartCoroutine(_SpawnEnemies());
                    yield return null;
                break;
            case Wave.wave2:
                    wave = Wave.wave3;
                    StartCoroutine(_SpawnEnemies());
                    yield return null;
                break;
            case Wave.wave3:
                    wave = Wave.wave4;
                    StartCoroutine(_SpawnEnemies());
                    yield return null;
                break;
            case Wave.wave4:
                    wave = Wave.wave5;
                    StartCoroutine(_SpawnEnemies());
                    yield return null;
                break;
            case Wave.wave5:
                    wave = Wave.wave6;
                    StartCoroutine(_SpawnEnemies());
                    yield return null;
                break;
            case Wave.wave6:
                    hudManager.ShowHideMessage("Finalizou!", 5);
                break;
        }
    }

    public void RotateRings()
    {
        int leftRight = UnityEngine.Random.Range(0, 2);
        //0 = l, 1 = r
        int timesRotate = UnityEngine.Random.Range(0, 3);
        //0 = n roda, 1 = roda 1 vez, 2 = roda 2 vezes
        if (leftRight == 0)
        {
            aro3.transform.Rotate(0, 0, 60 * timesRotate);
        }
        if (leftRight == 1)
        {
            aro3.transform.Rotate(0, 0, -60 * timesRotate);
        }
        Debug.Log("lr:" + leftRight + " / timesRotate: " + timesRotate);
        leftRight = UnityEngine.Random.Range(0, 2);
        //0 = l, 1 = r
        timesRotate = UnityEngine.Random.Range(0, 3);
        //0 = n roda, 1 = roda 1 vez, 2 = roda 2 vezes
        if (leftRight == 0)
        {
            aro4.transform.Rotate(0, 0, 60 * timesRotate);
        }
        if (leftRight == 1)
        {
            aro4.transform.Rotate(0, 0, -60 * timesRotate);
        }
        Debug.Log("lr:" + leftRight + " / timesRotate: " + timesRotate);
        leftRight = UnityEngine.Random.Range(0, 2);
        //0 = l, 1 = r
        timesRotate = UnityEngine.Random.Range(0, 3);
        //0 = n roda, 1 = roda 1 vez, 2 = roda 2 vezes
        if (leftRight == 0)
        {
            aro5.transform.Rotate(0, 0, 60 * timesRotate);
        }
        if (leftRight == 1)
        {
            aro5.transform.Rotate(0, 0, -60 * timesRotate);
        }
        Debug.Log("lr:" + leftRight + " / timesRotate: " + timesRotate);
        navMeshSurface.UpdateNavMesh(data);
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
