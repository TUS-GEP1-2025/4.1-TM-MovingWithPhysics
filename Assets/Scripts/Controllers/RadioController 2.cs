using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioController2 : MonoBehaviour
{
    public List<AudioClip> playList = new List<AudioClip>();
    private AudioSource theAudioSource;
    public Animator radioAnimator;

    public SwitchController theSwitchController;

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
        radioAnimator.SetBool("IsOn", true);

        if (songIndex >= playList.Count)
        {
            songIndex = 0;
        }
    }
    public void StopSong()
    {
        radioAnimator.SetBool("IsOn", false);
        theAudioSource.Stop();
    }
}
