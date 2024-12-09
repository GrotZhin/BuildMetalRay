using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MetalRay
{
    public class Score : MonoBehaviour
    {
        public static int scoreValue = 0;
        public static int killCounterValue = 0;
        public static int highKillCounterValue = 0;
        public static int counter = 0;
        public static float killTimer = 0;
        public TextMeshProUGUI score;
        public Image[] phrases;
        public TextMeshProUGUI killCounter;
        public TextMeshProUGUI chancesText;
        public TextMeshProUGUI highKillCounterText;
        public GameObject[] multiplier;
        public Transform reference;
        Image save;

        void Start()
        {
            score = GetComponent<TextMeshProUGUI>();
            counter = 0;
            killTimer = 0;
        }

        // Update is called once per frame
        void Update()
        {
            score.text = "" + scoreValue;
            killCounter.text = "" + killCounterValue;
            highKillCounterText.text = "" + highKillCounterValue;
            chancesText.text = WinCondition.chances + "x";
            
            if(killCounterValue < 10)
            {
                Destroy(save);
                multiplier[0].SetActive(false);
                multiplier[1].SetActive(false);
                multiplier[2].SetActive(false);
            }
            else if (killCounterValue >= 10 && killCounterValue < 20)
            {
                multiplier[0].SetActive(true);

            }
            else if (killCounterValue >= 20 && killCounterValue < 30)
            {
                multiplier[0].SetActive(false);
                multiplier[1].SetActive(true);

            }
            else if (killCounterValue > 30 && killCounterValue < 40)
            {
                multiplier[1].SetActive(false);
                multiplier[2].SetActive(true);

            }
            else if(killCounterValue > 40)
            {
                 multiplier[2].SetActive(true);
            }
            killTimer += Time.deltaTime;

            if (killTimer >= 10)
            {
                killCounterValue = 0;
            }

            if (counter >= 10)
            {

                Phrases();
                counter = 0;
            }
            HighKillStreak();
        }

        public void Phrases()
        {

            var randomPhrase = phrases[Random.Range(0, phrases.Length)];


            if (save != null)
            {
                Destroy(save);

            }
            save = Instantiate(randomPhrase, reference.transform);
        }
        void HighKillStreak()
        {
           if(highKillCounterValue < killCounterValue)
           {
            highKillCounterValue = killCounterValue;
           }
        }
        
    }
}
