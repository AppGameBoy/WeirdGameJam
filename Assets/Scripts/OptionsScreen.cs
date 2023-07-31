using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScreen : MonoBehaviour
{
    public AudioMixer mixer;

    public TMP_Text mastLabel, musicLabel, sfxLabel;
    public Slider mastSlider , musicSlider, sfxSlider;
    // Start is called before the first frame update
    void Start()
    {
        float vol = 0f;
        mixer.GetFloat("MasterVol", out vol);
        mastSlider.value = vol;
        
        mixer.GetFloat("MusicVol", out vol);
        musicSlider.value = vol;
        
        mixer.GetFloat("SFXVol", out vol);
        sfxSlider.value = vol;

        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();



    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetMasterVolume()
    {
        mastLabel.text = Mathf.RoundToInt(mastSlider.value + 80).ToString();
        mixer.SetFloat("MasterVol",mastSlider.value);
        PlayerPrefs.SetFloat("MasterVol", mastSlider.value);
    }
    public void SetMusicVolume()
    {
        musicLabel.text = Mathf.RoundToInt(musicSlider.value + 80).ToString();
        mixer.SetFloat("MusicVol", musicSlider.value);
        PlayerPrefs.SetFloat("MusicVol", musicSlider.value);

    }
    public void SetSFXVolume()
    {
        sfxLabel.text = Mathf.RoundToInt(sfxSlider.value + 80).ToString();
        mixer.SetFloat("SFXVol", sfxSlider.value);
        PlayerPrefs.SetFloat("SFXVol", sfxSlider.value);

    }
}
