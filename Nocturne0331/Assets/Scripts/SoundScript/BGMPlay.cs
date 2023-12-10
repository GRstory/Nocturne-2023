using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class BGMPlay : MonoBehaviour
{
    public AudioClip[] BGMs;
    public AudioMixerGroup bgmGroup;
    private AudioSource audioSource;
    private int thisbgmInex = -1;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.outputAudioMixerGroup = bgmGroup;
        audioSource.loop = true;
    }

    // Update is called once per frame
    void Update()
    {
        int currentBgmIndex = GameManager.Instance.BGM_INDEX;

        if(currentBgmIndex != thisbgmInex)
        {
            if(currentBgmIndex >= 0 && currentBgmIndex < BGMs.Length)
            {
                audioSource.clip = BGMs[currentBgmIndex];
                audioSource.Play();
                thisbgmInex = currentBgmIndex;
            }
            else
            {
                audioSource.Stop();
                Debug.Log("유효하지 않은 Index 입력");
                Debug.Log(BGMs.Length);
            }
        }

    }
}
