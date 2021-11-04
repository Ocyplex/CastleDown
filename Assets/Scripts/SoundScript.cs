using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundScript : MonoBehaviour
{
    public AudioClip menuMusic;
    public AudioClip playMusic;
    private AudioSource myAudioSource;
    private GameMaster myGameMaster;
    private bool reset = true;

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
        myGameMaster = GetComponent<GameMaster>();
    }


    void Update()
    {
        if(reset)
        {
            if(myGameMaster.gameON)
            {
                myAudioSource.clip = playMusic;
            }
            else
            {
                myAudioSource.clip = menuMusic;
            }
            myAudioSource.Play();
            reset = false;
        }
    }

    public void MakeReset()
    {
        reset = true;
    }
}
