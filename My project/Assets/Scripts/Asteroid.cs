using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float asteroidSpeed = 10.0f;
    public float xBound = -30.0f;
    public AudioClip explosionSound;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void DestroyWithProjectile()
    {
        audioSource.PlayOneShot(explosionSound, 1f);
        gameObject.GetComponent<MeshRenderer>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = false;
        Destroy(gameObject, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        //Move the asteroid forward
        transform.Translate(Vector3.forward * Time.deltaTime * asteroidSpeed);
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}
