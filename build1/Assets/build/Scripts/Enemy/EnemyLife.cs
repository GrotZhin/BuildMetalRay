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
        public static int multiplier;

        public GameObject deathEffect;

        public ParticleSystem vfxhit;

        DropRate dropRate;



        void Start()
        {
            dropRate = GetComponent<DropRate>();
            
        }

        public void TakeDamage(int damage)
        {

            life -= damage;
            if (life <= 0)
            {
                Die();
                Score.killCounterValue += 1;
                Score.counter += 1;
                
                if (Score.killCounterValue <= 10)
                {   
                    multiplier = 1;
                    Score.killTimer = 0;
                    Score.scoreValue += 10 * multiplier;
                }
                else if (Score.killCounterValue > 10 && Score.killCounterValue <= 20)
                {   
                     multiplier = 2;
                    Score.killTimer = 0;
                    Score.scoreValue += 10 * multiplier;
                }
                else if (Score.killCounterValue > 20 && Score.killCounterValue <= 30)
                {
                    multiplier = 3;
                    Score.killTimer = 0;
                    Score.scoreValue += 10*multiplier;
                }
                else if (Score.killCounterValue > 30 && Score.killCounterValue <= 40)
                {   
                    multiplier = 4;
                    Score.killTimer = 0;
                    Score.scoreValue += 10*multiplier;
                }
                
                else if (Score.killCounterValue > 40)
                {   multiplier = 4;
                    Score.killTimer = 0;
                    Score.scoreValue += 10*multiplier;
                }

                dropRate.DropPowerUp();
            }


        }
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("enemyDestroy"))
            {
                Delete();
            }


        }

        public void Delete()
        {
            Destroy(gameObject);
        }
        public void Die()
        {
            soundManager.PlaySound(SoundType.ENEMYBOOM);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(vfxhit, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
    }
}
