using System.Collections;
using System.Collections.Generic;
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
        public GameObject hitSprite;

        public GameObject deathEffect;

        public TextMeshProUGUI textoVida;
        
        void Start(){
            life = maxLife;
        }

        public void TakeDamage(int damage)
        {
            life -= damage;

            if (life <= 0)
            {
                Die();
                SceneManager.LoadScene("lose");
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
           
        }
        void Update()
        {
            if (fillBar.fillAmount <= 0.5)
            {
                lifeBar.SetActive(false);
            }else if(fillBar.fillAmount >= 0.5){
                lifeBar.SetActive(true);
            }
            LifeBar();

        }

        public void LifeBar(){
            fillBar.fillAmount = life/maxLife;
            halfBar.fillAmount = life/maxLife;

        }

        void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
