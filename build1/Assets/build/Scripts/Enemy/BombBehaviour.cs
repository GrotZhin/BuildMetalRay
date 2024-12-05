using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    public float upperLimit;
    public float lowerLimit;

    public GameObject bulletPrefab;

    private GameObject player;
    private GameObject shoots;
    private float explodePosition;

    private void Start()
    {
        player = GameObject.Find("Player");
        // Limits based of player movement limit
    }

    private void Update()
    {
        explodePosition = Random.Range(lowerLimit, upperLimit);
        if (transform.position.y <= explodePosition)
        {
            Destroy(gameObject);
        }
        
     
    }


    private void OnDestroy()
    {



        // Quando a bomba e destruida, atira tiros em um padrao circular

        Vector3 rotation = Vector3.zero; // Variavel que determina a rotacao dos tiros a serem criados

        // Criacao de 8 tiros
        for (int i = 0; i < 8; i++)
        {
            shoots = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(rotation));
            rotation += new Vector3(0f, 0f, 45f); // Rotaciona em 45 graus no eixo y

        }
    }
}
