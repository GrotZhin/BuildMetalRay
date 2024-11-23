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
        public static int counter = 0;
        public TextMeshProUGUI score;
        public TextMeshProUGUI killCounter;
        public Image[] phrases;
        public GameObject[] multiplier;
        public Transform reference;
        public Image save;

        void Start()
        {
            score = GetComponent<TextMeshProUGUI>();
        }

        // Update is called once per frame
        void Update()
        {
            score.text = "" + scoreValue;
            killCounter.text = "" + killCounterValue;

           if (counter == 10)
            {

               Phrases();
               counter = 0;
           }

            if (killCounterValue >= 10 && killCounterValue < 20)
            {
                multiplier[0].SetActive(true);

            }
            else if (killCounterValue >= 20 && killCounterValue < 30)
            {
                multiplier[0].SetActive(false);
                multiplier[1].SetActive(true);

            }
            else if (Score.killCounterValue > 30 && Score.killCounterValue < 40)
            {
                multiplier[1].SetActive(false);
                multiplier[2].SetActive(true);

            }
        }

        public void Phrases()
        {

            var randomPhrase = phrases[Random.Range(0, phrases.Length)];
          
           
            if(save != null)
            {
                Destroy(save);
                
            }
             save = Instantiate(randomPhrase, reference.transform);
        }
    }
}
