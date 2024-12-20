using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.Video;


namespace MetalRay
{
    public class PlayerLife : MonoBehaviour
    {
        public static float life;
        public static PlayerLife playerLife;
        public float maxLife = 100;

        public int damage = 20;

        public UnityEngine.UI.Image fillBar;
        public UnityEngine.UI.Image halfBar;
        public GameObject lifeBar;
        public GameObject model;
        public GameObject hitSprite;
        public Transform respawn;

        public GameObject deathEffect;

        public ParticleSystem vfxdeath;
        float iframe = 0f;
        bool hitbool = false;

        [SerializeField] private GameObject flashEffect;
        [SerializeField] private GameObject Sakihit;
        [SerializeField] private GameObject Sakideath;
        public float hitcamtimer;
        public float hitcamdur;

        bool flashonoff = true;
        int flashstop;

        public TextMeshProUGUI textoVida;

        float killtimer = 0f;
        public static bool die;
        public static bool ignore;

        Scene scene;

        void Start()
        {
            life = maxLife;
            die = false;
            scene = SceneManager.GetActiveScene();
        }

        public void TakeDamage(int damage)
        {
            life -= damage;
            ignore = true;
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("enemyShoot"), true);
            hitbool = true;
            FlashEffect();

            soundManager.PlaySound(SoundType.PLAYERHIT);
            if (life <= 0)
            {
                Die();
            }


        }

        public void RestaureLife(int restaure)
        {
            life += restaure;
            if (life > maxLife)
            {
                life = maxLife;
            }
        }

        void OnCollisionEnter(Collision hitInfo)
        {
            EnemyLife enemyLife = hitInfo.collider.GetComponent<EnemyLife>();
            if (enemyLife != null)
            {
                enemyLife.Die();
                TakeDamage(damage);

            }
            SubBossLife subBossLife = hitInfo.collider.GetComponent<SubBossLife>();
            if (subBossLife != null)
            {

                TakeDamage(damage);
            }
            BossLife BossLife = hitInfo.collider.GetComponent<BossLife>();
            if (BossLife != null)
            {

                TakeDamage(damage);
            }

        }
        void Update()
        {
            if (ignore == true)
            {
                iframe += Time.deltaTime;
                if (iframe >= 1f)
                {
                    Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
                    Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("enemyShoot"), false);
                    iframe = 0;
                    ignore = false;
                }
            }





            if (fillBar.fillAmount <= 0.5)
            {
                lifeBar.SetActive(false);
            }
            else if (fillBar.fillAmount >= 0.5)
            {
                lifeBar.SetActive(true);
            }

            LifeBar();

            if (hitbool == true)
            {
                Hitcam();
            }
            if (Input.GetKeyDown(KeyCode.F3))
            {
                maxLife = 10000000;
                life = maxLife;
            }

        }

        public void LifeBar()
        {
            fillBar.fillAmount = life / maxLife;
            halfBar.fillAmount = life / maxLife;

        }

        void Die()
        {

            WinCondition.chances -= 1;
            halfBar.fillAmount = 0;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(vfxdeath, transform.position, Quaternion.identity);
            if (WinCondition.chances > 0)
            {
                Respawn();
            }
            else if (WinCondition.chances <= 0)
            {
                die = true;
                Sakideath.SetActive(true);
            }
           
            Destroy(gameObject);
        }
        void Respawn()
        {
            Instantiate(this.gameObject, respawn.position, Quaternion.identity);
            
            
            Score.killCounterValue = 0;


        }
        void FlashEffect()
        {

            InvokeRepeating("Flash", 0f, 0.06f);

        }
        void Flash()
        {

            if (flashonoff)
            {
                flashEffect.SetActive(false);
                flashonoff = false;
                flashstop++;
            }
            else
            {
                flashEffect.SetActive(true);
                flashonoff = true;

            }
            if (flashstop >= 6f)
            {

                CancelInvoke("Flash");
                flashEffect.SetActive(false);
                flashstop = 0;

            }


        }
        void Hitcam()
        {


            hitcamtimer += Time.deltaTime;

            if (hitcamtimer <= hitcamdur)
            {

                Sakihit.SetActive(true);

            }

            if (hitcamtimer >= hitcamdur)
            {

                Sakihit.SetActive(false);
                hitbool = false;
                hitcamtimer = 0;
            }

            
        }
        public void CheatLife()
        {
            maxLife = gameCheat.cheatLife;
        }

    }

}







