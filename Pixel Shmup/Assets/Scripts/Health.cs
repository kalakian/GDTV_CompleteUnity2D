using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();
        if(damageDealer)
        {
            TakeDamage(damageDealer.GetDamage());
            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    void TakeDamage(int damageTaken)
    {
        health -= damageTaken;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    void PlayHitEffect()
    {
        if(hitEffect)
        {
            ParticleSystem instance = Instantiate<ParticleSystem>(hitEffect,
                                                                    transform.position,
                                                                    Quaternion.identity);
            audioPlayer.PlayDamageClip();
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake && applyCameraShake)
        {
            cameraShake.Play();
        }
    }
}
