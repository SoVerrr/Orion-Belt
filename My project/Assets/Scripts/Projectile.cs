using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Projectile : MonoBehaviour
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
    // Update is called once per frame
    void Update()
    {
        //Move the projectile forward
        transform.Translate(Vector3.forward * Time.deltaTime * projectileSpeed);

        //Destroy the projectile out of players view
        if(transform.position.x > xBound)
        {
            Destroy(gameObject);
        }
    }
}
