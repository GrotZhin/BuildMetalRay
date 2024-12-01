using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_mov_ocean : MonoBehaviour
{
  float sinCenterX;

  public bool esquerda;
  public float amplitude;
  public float frequency;




  void Start()
  {

    sinCenterX = transform.position.x;
   
  }

  // Update is called once per frame
  void Update()
  {
    Moviment();
  }

  void Moviment()
  {
    Vector2 pos = transform.position;
    float sin;


    if (esquerda == true)
    {
      sin = Mathf.Sin((pos.y * frequency)) * amplitude;
    }
    else
    {
      sin = Mathf.Sin((pos.y * frequency)) * -amplitude;
    }

    pos.x = sinCenterX + sin;
    
    transform.position = pos;
  }





}