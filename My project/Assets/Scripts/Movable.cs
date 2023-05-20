using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable : MonoBehaviour
{
    [SerializeField] protected float speed = 10.0f;
    [SerializeField] protected float bound = -30.0f;

    protected void Move(float speed, float bound)
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        //Destroy the asteroid out of players view
        if (transform.position.x < bound)
        {
            Destroy(gameObject);
        }
    }
}
