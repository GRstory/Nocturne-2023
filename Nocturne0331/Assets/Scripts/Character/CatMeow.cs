using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CatMeow : MonoBehaviour
{
    public AudioClip[] meows;
    public AudioMixerGroup mixerGroup;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = mixerGroup;
    }

    // Update is called once per frame
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)&&(!audioSource.isPlaying))
        {
            int randomMeow = Random.Range(0, meows.Length);
            audioSource.PlayOneShot(meows[randomMeow]);
            GameManager.Instance.TIME_MEOW += 1;
        }
    }
}
