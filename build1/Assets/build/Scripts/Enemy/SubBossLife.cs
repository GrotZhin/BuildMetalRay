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
        public int life = 2000;

        public GameObject deathEffect;

        public ParticleSystem vfxhit;
        int i = 0;
        Scene scene;
       public GameObject model;

        public void TakeDamage(int damage)
        {
            scene = SceneManager.GetActiveScene();    
            life -= damage;
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
            Destroy(gameObject);

        }
    }
}
