using System;
using System.Collections;
using System.Collections.Generic;
using MetalRay;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class BossMove : MonoBehaviour
{
    public float spd = 1;
    public bool move;

    public GameObject reference;

    float min = -2;
    float max = 2;


    float timer = 0f;
    float interval = 20.0f;
    int porcent;

    public static bool down;
    private void Start()
    {
        down = true;
    }
    private void Update()
    {
        Vector2 pos = transform.position;
        timer += Time.deltaTime;



        if (timer >= interval)
        {
            porcent = Random.Range(0, 100);
            
            timer = 0;
        }
        if (down == true)
        {

            pos.y -= 2 * Time.deltaTime;
           
            if (pos.y <= 5.20f && pos.y >= 5.15f)
            {
                down = false;
                
            }

        }

        transform.position = pos;
    }
}