using System;
using System.Collections;
using System.Collections.Generic;
using MetalRay;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class subBossMove : MonoBehaviour
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


        if (move == true && down == false)
        {
            pos.x -= spd * Time.deltaTime;
            if (pos.x <= min)
            {
                move = false;

            }

        }
        else if (move == false && down == false)
        {
            pos.x += spd * Time.deltaTime;
            if (pos.x >= max)
            {
                move = true;
            }
        }

        if (timer >= interval)
        {
            porcent = Random.Range(0, 100);
            Debug.Log(porcent);
            timer = 0;
        }

        else if (porcent <= 100 && porcent > 0)
        {
            down = true;
            porcent = 0;
        }

        if (down == true)
        {
            SubBossWeapon.shootOn = false;
            pos.y -= 5 * Time.deltaTime;
            if (pos.y <= 0)
            {
                pos.y = reference.transform.position.y;
                pos.x = reference.transform.position.x;

            }
            if (pos.y <= 5.20f && pos.y >= 5.18f)
            {
                down = false;
                SubBossWeapon.shootOn = true;
            }

        }
        transform.position = pos;
    }
}