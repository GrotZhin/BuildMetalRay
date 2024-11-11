using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

namespace MetalRay
{
    public class EnemyLife : MonoBehaviour
    {
        public int life;

        public GameObject deathEffect;

        public TextMeshProUGUI scoreText;

        public ParticleSystem vfxhit;
        public int damage = 10;

        DropRate dropRate;
        Score score;
       

        void Start()
        {
            dropRate = GetComponent<DropRate>();
            score = GetComponent<Score>();
        }

        public void TakeDamage(int damage)
        {

            life -= damage;
            if (life <= 0)
            {
                Die();
                Score.killCounterValue += 1;
            if (Score.killCounterValue <= 10)
            {
                Score.scoreValue += 10;
            }    
            else if (Score.killCounterValue > 10 && Score.killCounterValue < 20)
            {
                Score.scoreValue += 20;
            }
            else if (Score.killCounterValue > 20 && Score.killCounterValue < 30) 
            {
                Score.scoreValue += 30;
            }
            else if (Score.killCounterValue > 30 && Score.killCounterValue < 40) 
            {
                Score.scoreValue += 4;
            }
            else if (Score.killCounterValue > 40 && Score.killCounterValue < 50) 
            {
                Score.scoreValue += 5;
            }    

                dropRate.DropPowerUp();
            }


        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("enemyDestroy")){
                Delete();
            }


        }

        public void Delete()
        {
            Destroy(gameObject);
        }
        public void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(vfxhit, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
