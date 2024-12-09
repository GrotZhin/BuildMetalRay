using System.Collections;
using System.Collections.Generic;
using TMPro;

using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MetalRay
{
    public class SubBossLife : MonoBehaviour
    {
        public int life;

        public GameObject deathEffect;

        public ParticleSystem vfxhit;
    
        Scene scene;
       public GameObject model;

        [SerializeField] private GameObject flashEffect ;

        
        bool flashonoff = true;
        int flashstop ;

        public void TakeDamage(int damage)
        {
            scene = SceneManager.GetActiveScene();    
            life -= damage;
            FlashEffect();
            if (life <= 0)
            {
                WinCondition.i +=1;
               
                Score.scoreValue += 2000 * EnemyLife.multiplier;
                Die();
                 
            }
           

        }
        

        public void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(vfxhit, transform.position, Quaternion.identity);
            SpawnEnemyLevel2.bossInScreen = null;
            Destroy(gameObject);

        }

         void FlashEffect()
        {

           InvokeRepeating("Flash",0f,0.02f);

        }

          void Flash(){

            if (flashonoff)
            {
            flashEffect.SetActive(false);
            flashonoff= false;
            flashstop ++;
            }
            else 
            { 
            flashEffect.SetActive(true);
            flashonoff= true;
            
            }
            if (flashstop >= 2f)
            {

            CancelInvoke("Flash");
            flashEffect.SetActive(false);
            flashstop = 0;

            }
        

        }
    }
}
