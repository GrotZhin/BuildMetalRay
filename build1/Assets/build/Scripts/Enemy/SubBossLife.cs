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
    

        public void TakeDamage(int damage)
        {

            life -= damage;
            if (life <= 0)
            {
                Die();
                Score.scoreValue += 2000;
                SceneManager.LoadScene("win");
               
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
