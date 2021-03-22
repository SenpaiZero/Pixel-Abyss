using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuSFX : MonoBehaviour
{
    public AudioSource sfx;
    public AudioClip AC;

    public void menuSound()
    {
        sfx.PlayOneShot(AC);
    }
}
