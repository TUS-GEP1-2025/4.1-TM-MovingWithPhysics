using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController2 : MonoBehaviour
{
    public List<AudioClip> playList = new List<AudioClip>();
    private AudioSource theAudioSource;

    private int songIndex = 0;

    void Awake()
    {
        theAudioSource = GetComponent<AudioSource>();
        if (theAudioSource == null)
        {
            theAudioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    public void PlayNextSong()
    {
        if (playList == null || playList.Count == 0)
            return;

        theAudioSource.clip = playList[songIndex];
        theAudioSource.Play();
        songIndex++;

        if (songIndex >= playList.Count)
        {
            songIndex = 0;
        }
    }
}
