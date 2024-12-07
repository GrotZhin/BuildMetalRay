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
        public float life;
        float maxLife = 100;
        public int damage = 20;
        public UnityEngine.UI.Image fillBar;
        public UnityEngine.UI.Image halfBar;
        public GameObject lifeBar;
        public GameObject model;
        public GameObject hitSprite;
        public new CapsuleCollider collider;
        public GameObject deathEffect;

         public ParticleSystem vfxdeath;
        float iframe = 0f;
        bool hitbool = false;

        [SerializeField] private GameObject flashEffect ;
        [SerializeField] private GameObject Sakihit ;
        [SerializeField] private GameObject Sakideath ;
        public float hitcamtimer;
        public float hitcamdur;

        bool flashonoff = true;
        int flashstop ;

        public TextMeshProUGUI textoVida;

        float killtimer = 0f;
        bool die;
        bool ignore;

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
            Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("enemyShoot"),true);
            hitbool= true;
            FlashEffect();
            
            soundManager.PlaySound(SoundType.PLAYERHIT);

            if (life <= 0)
            {   
                Die();
                if (scene.name == ("level1"))
                {
                    Retry.i =1;
                }else if(scene.name == ("level2"))
                {
                    Retry.i =2;
                }
                else if(scene.name == ("level3"))
                {
                    Retry.i =3;
                }

               
            }

        }

        public void RestaureLife(int restaure)
        {
            life += restaure;
            if (life > maxLife)
            {
                life = 100;
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

        }
        void Update()
        {
            if (ignore == true)
            {
                iframe += Time.deltaTime;
                 if (iframe >= 1f)
            {
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
                Physics.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("enemyShoot"),false);   
                iframe = 0;
                ignore = false;
            }
            }
           
            if (die == true)
            {
                killtimer += Time.deltaTime;
                Debug.Log(killtimer);
            }
            if (killtimer >= 2)
            {
                SceneManager.LoadScene("lose");
                killtimer = 0f;
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

        }

        public void LifeBar()
        {
            fillBar.fillAmount = life / maxLife;
            halfBar.fillAmount = life / maxLife;

        }

        void Die()
        {
            die = true;
            halfBar.fillAmount = 0;
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Instantiate(vfxdeath, transform.position, Quaternion.identity);
            Sakideath.SetActive(true);
            Destroy(model.gameObject);
        }

        void FlashEffect()
        {

           InvokeRepeating("Flash",0f,0.06f);

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

    }

}
            
        
    
        

    

