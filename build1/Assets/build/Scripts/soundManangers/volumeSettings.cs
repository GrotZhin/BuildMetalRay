using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;

namespace MetalRay
{
    public class volumeSettings : MonoBehaviour
    {
        [SerializeField] private AudioMixer mixer;
        [SerializeField] private Slider musicSlider;
        [SerializeField] private Slider geralSlider;
        [SerializeField] private Slider sfxSlider;

        private void Start()
        {

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