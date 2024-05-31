using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10;
    [SerializeField] float projectileLifetime = 5;
    [SerializeField] float firingRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0;
    [SerializeField] float minimumFiringRate = 0.2f;

    bool isFiring;
    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;

    public void SetShooting(bool value)
    {
        isFiring = value;
    }

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        isFiring = useAI;
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
        while (true)
        {
            GameObject projectile = Instantiate<GameObject>(projectilePrefab,
                                                            transform.position,
                                                            Quaternion.identity);
            Rigidbody2D rb2d = projectile.GetComponent<Rigidbody2D>();
            if (rb2d)
            {
                rb2d.velocity = transform.up * projectileSpeed;
            }
            Destroy(projectile, projectileLifetime);

            float waitTime = Random.Range(firingRate - firingRateVariance,
                                             firingRate + firingRateVariance);

            waitTime = Mathf.Clamp(waitTime, minimumFiringRate, float.MaxValue);

            audioPlayer.PlayShootingClip();

            yield return new WaitForSeconds(waitTime);
        }
    }
}
