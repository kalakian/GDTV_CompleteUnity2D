using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float firingRate = 0.2f;

    bool isFiring;
    Coroutine firingCoroutine;

    public void SetShooting(bool value)
    {
        isFiring = value;
    }

    void Start()
    {

    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if(!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while(true)
        {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab,
                                                            transform.position,
                                                            Quaternion.identity);
            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            if(rb2d)
            {
                rb2d.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);

            yield return new WaitForSeconds(firingRate);
        }
    }
}
