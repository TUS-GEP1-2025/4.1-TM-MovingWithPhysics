using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController : MonoBehaviour
{
    public AudioClip[] audioClip;
    private AudioSource audioSource;

    void Awake()
    {
        // Get or add an AudioSource component
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayNextSong()
    {
        if (audioClip == null || audioClip.Length == 0)
            return;

        int randomIndex = Random.Range(0, audioClip.Length);
        audioSource.clip = audioClip[randomIndex];
        audioSource.Play();
    }
}
