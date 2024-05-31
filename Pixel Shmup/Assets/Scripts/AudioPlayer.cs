using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0, 1)] float shootingVolume = 1;

    [Header("Damage")]
    [SerializeField] AudioClip damageClip;
    [SerializeField] [Range(0, 1)] float damageVolume = 1;

    public void PlayShootingClip()
    {
        PlayClip(shootingClip, shootingVolume);
    }

    public void PlayDamageClip()
    {
        PlayClip(damageClip, damageVolume);
    }

    void PlayClip(AudioClip clip, float volume)
    {
        AudioSource.PlayClipAtPoint(clip,
                                    Camera.main.transform.position,
                                    volume);
    }
}
