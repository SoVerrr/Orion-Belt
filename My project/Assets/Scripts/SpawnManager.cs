using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private Asteroid asteroid;
    [SerializeField] private Fuel fuel;
    [SerializeField] private Ammo ammo;

    private float timeRemainingAsteroid = 1;
    private const float timeRemainingAsteroidStart = 1;

    private float timeRemainingFuel = 2;
    private const float timeRemainingFuelStart = 2;

    private float timeRemainingAmmo = 4;
    private const float timeRemainingAmmoStart = 4;

    private Vector3 halfBoxSize = new Vector3(0.5f, 0.5f, 0.5f);
    void Start()
    {
        
    }

    void Update()
    {
        SpawnMovable(asteroid, ref timeRemainingAsteroid, timeRemainingAsteroidStart);
        SpawnMovable(ammo, ref timeRemainingAmmo, timeRemainingAmmoStart);
        SpawnMovable(fuel, ref timeRemainingFuel, timeRemainingFuelStart);
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
    private void SpawnMovable(Movable obj, ref float timeRemaining, float timeStart)
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }
        else
        {
            timeRemaining = timeStart;
            Vector3 spawnVector = CheckIfLegal(new Vector3(30, 0, Random.Range(-7, 7)));
            Instantiate(obj.gameObject, spawnVector, Quaternion.Euler(0, -90, 0));
        }
    }
}
