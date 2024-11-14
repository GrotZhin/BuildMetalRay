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
        public GameObject model;
        public GameObject hitSprite;

        public GameObject deathEffect;

        public TextMeshProUGUI textoVida;

        float killtimer = 0f;
        bool die;


        void Start()
        {
            life = maxLife;
            die = false;
        }

        public void TakeDamage(int damage)
        {
            life -= damage;
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
            Destroy(model.gameObject);
        }
    }
}
