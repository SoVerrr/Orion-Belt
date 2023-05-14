using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject asteroid;
    public GameObject fuel;
    public GameObject ammo;
    public float timeRemainingAsteroid = 1;
    public float timeRemainingFuel = 2;
    public float timeRemainingAmmo = 10;
    public Vector3 halfBoxSize = new Vector3(0.5f, 0.5f, 0.5f);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SpawnAsteroid();
        SpawnFuel();
        SpawnAmmo();
    }
    //Recursive function finding a suitable coordinates to spawn a new object
    private Vector3 CheckIfLegal(Vector3 spawnPosition)
    {
        if (Physics.OverlapBox(spawnPosition, halfBoxSize).Length > 0)
        {
            Debug.Log("Found conflicting spawn");
            return CheckIfLegal(new Vector3(30, 0, Random.Range(-7, 7)));
        }
        else
            return spawnPosition;
    }
    private void SpawnAsteroid()
    {
        if (timeRemainingAsteroid > 0)
        {
            timeRemainingAsteroid -= Time.deltaTime;
        }
        else
        {
            Vector3 spawnVector = CheckIfLegal(new Vector3(30, 0, Random.Range(-7, 7)));
            timeRemainingAsteroid = 1;
            Instantiate(asteroid, spawnVector, Quaternion.Euler(0, -90, 0));
        }
    }
    private void SpawnFuel()
    {
        if (timeRemainingFuel > 0)
        {
            timeRemainingFuel -= Time.deltaTime;
        }
        else
        {
            Vector3 spawnVector = CheckIfLegal(new Vector3(30, 0, Random.Range(-7, 7)));
            timeRemainingFuel = 2f;
            Instantiate(fuel, spawnVector, Quaternion.Euler(0, -90, 0));
        }
    }

    private void SpawnAmmo()
    {
        if (timeRemainingFuel > 0)
        {
            timeRemainingAmmo -= Time.deltaTime;
        }
        else
        {
            Vector3 spawnVector = CheckIfLegal(new Vector3(30, 0, Random.Range(-7, 7)));
            timeRemainingAmmo = 10f;
            Instantiate(ammo, spawnVector, Quaternion.Euler(0, -90, 0));
        }
    }
}
