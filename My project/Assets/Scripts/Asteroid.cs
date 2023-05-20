using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : Movable
{

    public AudioClip explosionSound;
    public AudioSource audioSource;
    private MeshRenderer asteroidMeshRenderer;
    private Collider asteroidCollider;
    void Start()
    {
        asteroidMeshRenderer = gameObject.GetComponent<MeshRenderer>();
        asteroidCollider = gameObject.GetComponent<Collider>();
        audioSource = GetComponent<AudioSource>();
    }
    public void DestroyWithProjectile()
    {
        audioSource.PlayOneShot(explosionSound, 1f);
        asteroidMeshRenderer.enabled = false;
        asteroidCollider.enabled = false;
        Destroy(gameObject, 1f);
    }
    void Update()
    {
        Move(speed, bound);
    }
}
