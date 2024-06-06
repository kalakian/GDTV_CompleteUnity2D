using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int maxHealth = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    [SerializeField] int scoreForDestroying = 0;

    CameraShake cameraShake;
    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;
    LevelManager levelManager;

    int remainingHealth;
    bool isPlayer;

    public int GetRemainingHealth()
    {
        return remainingHealth;
    }

    public float GetHealthFraction()
    {
        float fraction = 0;

        if(remainingHealth > 0 && maxHealth > 0)
        {
            fraction = remainingHealth / (float)maxHealth;
        }

        return fraction;
    }

    void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        remainingHealth = maxHealth;
        levelManager = FindObjectOfType<LevelManager>();
        isPlayer =  GetComponent<Player>() != null;
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
        remainingHealth -= damageTaken;
        if(remainingHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (scoreKeeper)
        {
            scoreKeeper.AddToScore(scoreForDestroying);
        }
        if(isPlayer)
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
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
