using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : Movable
{
    public float projectileSpeed = 10.0f;
    public float xBound = 30.0f;
    public PlayerController playerController;



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>())
        {
            collision.gameObject.GetComponent<Asteroid>().DestroyWithProjectile();
            DestroyProjectile();            
            //Add 1 point for destroying asteroid
            playerController.IncrementPoints();
        }
    }
    private void DestroyProjectile() //waits before destryoing projectile to let the sound fully play
    {
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        Move(speed, bound);
    }
}
