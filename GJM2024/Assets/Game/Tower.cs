using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target;
    public bool enemyInRange, isShooting;
    public GameObject bulletProjectile, bulletSpawner;
    public bool tripleShot;
    void Update()
    {
        if (target != null)
        {
            enemyDirection = target.transform.position - transform.position;
            enemyDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(enemyDirection);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<enemy>())
        {
            Debug.Log("enemy in range");
            enemyInRange = true;
            target = other.gameObject;
            if (!isShooting) StartCoroutine(_Shoot());
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<enemy>())
        {
            Debug.Log("enemy stay range");
            enemyInRange = true;
            target = other.gameObject;
            if (!isShooting) StartCoroutine(_Shoot());
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<enemy>())
        {
            Debug.Log("enemy out range");
            enemyInRange = false;
            target = null;
            StopCoroutine(_Shoot());
        }
    }

    public Vector3 enemyDirection;
    IEnumerator _Shoot()
    {
        while (enemyInRange)
        {
            isShooting = true;
            Debug.Log("shooting enemy");


            GameObject _bulletProjectile = Instantiate(bulletProjectile, bulletSpawner.transform.position, transform.rotation);
            _bulletProjectile.transform.LookAt(target.transform);
            if (tripleShot)
            {
                yield return new WaitForSeconds(0.5f);
                GameObject _bulletProjectile2 = Instantiate(bulletProjectile, bulletSpawner.transform.position, transform.rotation);
                _bulletProjectile2.transform.LookAt(target.transform);

                yield return new WaitForSeconds(0.5f);
                GameObject _bulletProjectile3 = Instantiate(bulletProjectile, bulletSpawner.transform.position, transform.rotation);
                _bulletProjectile3.transform.LookAt(target.transform);
            }
            yield return new WaitForSeconds(2f);
        }
        isShooting = false;
        yield return null;
    }


}
