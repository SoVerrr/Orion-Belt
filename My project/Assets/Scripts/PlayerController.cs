using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private TextMeshProUGUI tmProFuelLevel;
    [SerializeField] private TextMeshProUGUI tmProPoints;
    [SerializeField] private TextMeshProUGUI tmProAmmo;

    [SerializeField] private float speed = 3.0f;
    [SerializeField] private float zRange = 7.0f;
    [SerializeField] private float fuelDepletionSpeed = 0.1f;

    private float startFuelDepletionSpeed;
    static public int points = 0;
    private float fuelLevel;
    private float playerInput;
    private bool flag = false;
    private bool isMenuOff = true;
    private int ammo = 100;


    void Awake()
    {
        fuelLevel = 100f;
        Time.timeScale = 0;
        startFuelDepletionSpeed = fuelDepletionSpeed;
    }
    //End the game when player collides with asteroid
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Asteroid>()){
            Debug.Log("hit");
            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            points = 0;
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Fuel>())
        {
            if(fuelLevel < 80) 
                fuelLevel += Fuel.fuelBoost;
            else
                fuelLevel = 100;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.GetComponent<Ammo>())
        {
            ammo += Ammo.ammoBoost;
            Destroy(other.gameObject);
        }
    }
    public void IncrementPoints() 
    {
        Debug.Log("Incrementing points");
        points++; 
    
    }
    void Update()
    {
        //Set the timescale to 1 to run the game
        if (!flag)
        {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
            {
                Debug.Log("Game started");
                Time.timeScale = 1;
                flag = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Menu(isMenuOff);
            isMenuOff = !isMenuOff;
        }
        //Restart the game if players fuel level reaches 0
        if(fuelLevel <= 0)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //Set textmeshpro to display current fuel level / points / ammo
        tmProFuelLevel.SetText("{0}%", fuelLevel);
        tmProPoints.SetText("{0}", points);
        tmProAmmo.SetText("{0}", ammo);

        MovePlayer();
        BoundCheck();
        Shoot();
        FuelDepletion();
    }
    private void MovePlayer()
    {
        //Basic movement will propably change later
        playerInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * playerInput * Time.deltaTime * speed);
    }
    //Keep player from leaving the camera view
    private void BoundCheck()
    {
        //Checks if player is about to leave the bounds
        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
        else if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }
    }
    private void Shoot()
    {
        //Instantiate a projectile when player presses space
        if (Input.GetKeyDown(KeyCode.Space) && ammo > 0 && Time.timeScale != 0)
        {
            Instantiate(projectile, new Vector3(transform.position.x + 1, transform.position.y, transform.position.z), Quaternion.Euler(0, 90, 0));
            ammo--;
        }
    }
    //Decrease players fuel by 1% every 0.1 seconds
    private void FuelDepletion()
    {
        if (fuelDepletionSpeed > 0)
            fuelDepletionSpeed -= Time.deltaTime;
        else
        {
            fuelDepletionSpeed = startFuelDepletionSpeed;
            fuelLevel -= 1;
        }

    }
    public void Menu(bool state)
    {
        continueButton.gameObject.SetActive(state);
        menuButton.gameObject.SetActive(state);
        if (state == true)
            Time.timeScale = 0;
        else if (state == false)
            Time.timeScale = 1;
    }
}
