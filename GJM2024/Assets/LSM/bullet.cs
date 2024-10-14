using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private void OnEnable()
    {
        GetComponent<Rigidbody>().AddForce(0, 0, 1000);
        StartCoroutine(DestroyAfterTime());
    }
    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
        Debug.Log("se foi");
        yield return null;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("scenario"))
        {
            // collision.gameObject.GetComponent<character>().health -= 10;
            // collision.gameObject.GetComponent<character>().checkHealth();
            //            Destroy(collision.gameObject);
            Destroy(this.gameObject);
        }
    }
}
