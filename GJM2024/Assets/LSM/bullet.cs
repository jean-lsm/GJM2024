using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnEnable()
    {
        // GetComponent<Rigidbody>().AddForce(0, 0, 10000);
        // transform.Translate(100, 0, 0);
        StartCoroutine(DestroyAfterTime());
    }

    private void Update() 
    {
        transform.Translate(Vector3.forward * 10f);
    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        Debug.Log("auto destruct");
        yield return null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<enemy>())
        {
            other.gameObject.GetComponent<enemy>().heatlhEnemy -= other.gameObject.GetComponent<enemy>().damageTaken;
            Debug.Log("enemy health: " + other.gameObject.GetComponent<enemy>().heatlhEnemy);
            Destroy(this.gameObject);
        }
    }
}
