using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;
using Unity.VisualScripting;
using UnityEditor;

namespace MetalRay
{
    public class volumeSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider geralSlider;
        [SerializeField] private Slider sfxSlider;
        public static volumeSettings volume;

        private void Start()
        {
            if (volume == null)
            {
                volume = this;
            }

            if (PlayerPrefs.HasKey("musicVolume"))
            {
                LoadVolume();
            }
            else
            {
                SetGeralVolume();
                SetMusicVolume();
                SetSfxVolume();
            }
        }

        public void SetMusicVolume()
        {
            float volume = musicSlider.value;

            mixer.SetFloat("music", Mathf.Log10(volume) * 20);

            PlayerPrefs.SetFloat("musicVolume", volume);
        }
        public void SetSfxVolume()
        {
            float volume = sfxSlider.value;

            mixer.SetFloat("sfx", Mathf.Log10(volume) * 20);

            PlayerPrefs.SetFloat("sfxVolume", volume);
        }

        public void SetGeralVolume()
        {

            float volume = geralSlider.value;

            mixer.SetFloat("geral", Mathf.Log10(volume) * 20);

            PlayerPrefs.SetFloat("geralVolume", volume);

        }
        public void DistorcionSongOn()
        {
            float volume = musicSlider.value;

            mixer.SetFloat("distorcion", Mathf.Log10(volume) * 20);
        }
        public void ReverbSongOn()
        {
            float volume = musicSlider.value;

            mixer.SetFloat("reverb", Mathf.Log10(volume) * 20);
        }

        public void DefaultSongOn()
        {
            float volume = musicSlider.value;

            mixer.SetFloat("default", Mathf.Log10(volume) * 20);
        }
        public void ChorusSongOn()
        {
            float volume = musicSlider.value;

            mixer.SetFloat("chorus", Mathf.Log10(volume) * 20);
        }
        
        public void DelayOn()
        {
            float volume = musicSlider.value;

            mixer.SetFloat("delay", Mathf.Log10(volume) * 20);
        }
        public void DistorcionSongOff()
        {
            mixer.SetFloat("distorcion", -80.0f);
        }
        public void ReverbSongOff()
        {
            mixer.SetFloat("reverb", -80.0f);
        }

        public void DefaultSongOff()
        {
            mixer.SetFloat("default", -80.0f);
        }
        public void ChorusSongOff()
        {
            mixer.SetFloat("chorus", -80f);
        }
        public void DelayOff()
        {
            mixer.SetFloat("delay", -80f);
        }
        private void LoadVolume()
        {

            geralSlider.value = PlayerPrefs.GetFloat("geralVolume");
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");

            SetGeralVolume();
            SetMusicVolume();
            SetSfxVolume();
        }

    }
}