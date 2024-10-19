using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target;
    public bool enemyInRange;
    public GameObject bullet, bulletSpawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<enemy>())
        {
            Debug.Log("enemy in range");
            enemyInRange = true;
            target = other.gameObject;
            StartCoroutine(_Shoot());
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.GetComponent<enemy>())
        {
            Debug.Log("enemy ou range");
            enemyInRange = false;
            target = null;
            StopCoroutine(_Shoot());
        }
    }

    IEnumerator _Shoot()
    {
        while(enemyInRange)
        {
            Debug.Log("shooting enemy");
            transform.LookAt(target.transform, Vector3.up);
            Vector3 teste = bulletSpawner.transform.position;
            Instantiate(bullet, teste, quaternion.identity);
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
