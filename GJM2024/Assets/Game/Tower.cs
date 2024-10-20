using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject target;
    public bool enemyInRange, isShooting;
    public GameObject bulletProjectile, bulletSpawner;
    public float timeToShoot = 1.5f;
    public bool tripleShot;
    void Start()
    {

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
            enemyDirection = target.transform.position - transform.position;
            enemyDirection.y = 0;
            transform.rotation = Quaternion.LookRotation(enemyDirection);

            GameObject _bulletProjectile = Instantiate(bulletProjectile, bulletSpawner.transform.position, transform.rotation);
            _bulletProjectile.transform.LookAt(target.transform);
            if (tripleShot)
            {
                GameObject _bulletProjectile2 = Instantiate(bulletProjectile, bulletSpawner.transform.position, transform.rotation);
                _bulletProjectile2.transform.LookAt(target.transform);

                GameObject _bulletProjectile3 = Instantiate(bulletProjectile, bulletSpawner.transform.position, transform.rotation);
                _bulletProjectile3.transform.LookAt(target.transform);
            }
            yield return new WaitForSeconds(timeToShoot);
        }
        isShooting = false;
        yield return null;
    }
}
