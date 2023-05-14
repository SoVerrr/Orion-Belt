using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float ammoSpeed = 10.0f;
    public float xBound = -30.0f;
    // Start is called before the first frame update
    void Start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        //Move the asteroid forward
        transform.Translate(Vector3.forward * Time.deltaTime * ammoSpeed);

        //Destroy the asteroid out of players view
        if (transform.position.x < xBound)
        {
            Destroy(gameObject);
        }
    }
}
