using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MetalRay{
public class BulletBehaviour : MonoBehaviour
{
    public float speed;
    public int damage = 50;
    public GameObject hitFX;
     public Rigidbody rb;

    private float velocityModifer;

    // Update is called once per frame
    void Start()
    {
            rb.velocity = (-1* transform.up) * speed;
            soundManager.PlaySound(SoundType.DISCO);
    }

  void OnTriggerEnter(Collider hitInfo){
           PlayerLife playerLife = hitInfo.GetComponent<PlayerLife>();
            if(playerLife != null){
                playerLife.TakeDamage(damage);
            
              }

          
           Destroy(gameObject);
        }
}
}