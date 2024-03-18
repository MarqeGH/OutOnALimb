using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource musicSrc;
    public AudioSource sfxSrc;
    public AudioClip music, bullet, fireball, perry, hit, complete;
    // Start is called before the first frame update

    public void PlayClip(AudioClip clip)
    {
        sfxSrc.clip = clip;
        sfxSrc.Play();
    }
}
