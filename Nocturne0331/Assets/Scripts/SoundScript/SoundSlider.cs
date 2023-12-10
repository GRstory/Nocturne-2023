using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundSlider : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterSilder;
    public Slider bgmSlider;
    public Slider sfxSlider;

    public void SetMaster()
    {
        audioMixer.SetFloat("Master", Mathf.Log10(masterSilder.value) * 20);
    }

    public void SetBGM()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(bgmSlider.value) * 20);
    }

    public void SetSFX()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(sfxSlider.value) * 20);
    }

}
