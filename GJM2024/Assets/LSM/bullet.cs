using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, 10000);
        StartCoroutine(DestroyAfterTime());
    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
        Debug.Log("se foi");
        yield return null;
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.GetComponent<enemy>())
        {
            Debug.Log("enemy hit");
            other.gameObject.GetComponent<enemy>().heatlhEnemy -= 25;
            Destroy(this.gameObject);
        }
    }
}
