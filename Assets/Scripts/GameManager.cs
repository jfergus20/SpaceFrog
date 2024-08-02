using System.Collections;
using UnityEngine;
//******************************************************************************
// Game Manager
//******************************************************************************
public class GameManager : MonoBehaviour
{

    public GameObject playerPrefab;
    private Transform playerSpawnPoint;
    private GameObject currentPlayer;
    private bool hasSpawnedPlayer = false;


    public EnemyController enemySpawner;
    public PlanetController planetSpawner;
    public float spawnInterval = 3.0f;


    //[SerializeField] private GameObject projectilePrefab;
    [SerializeField] public GameObject laserPrefab;
    //private LaserController laser;
    [SerializeField] private float fireRate = .2f;
    [SerializeField] private float projectileSpeed = 7.5f;
    //private float lastShotTime = 0f;

    public ScoreManager scoreManager;

    public GameObject gameOverPanel;

    // Remove the GetCamera method
    /*
    public GameObject playerPrefab; // Reference to the player prefab
    private Transform playerSpawnPoint; // Spawn point for the player
    private GameObject currentPlayer; // Reference to the active player instance
    private bool hasSpawnedPlayer = false; // Track whether the player has been spawned


    public EnemySpawner enemySpawner;
    public PlanetSpawner planetSpawner;
    public float spawnInterval = 3.0f;


    private Camera mainCamera;



    public Camera GetMainCamera()
    {
        return mainCamera;
    }*/
    //**************************************************************************
    //**************************************************************************
    private void Start()
    {
        //Debug.Log("Starting GameManager");
        //mainCamera = Camera.main;
        gameOverPanel.SetActive(false);

        // Spawn the player character at the specified spawn point if not already spawned
        if (!hasSpawnedPlayer)
        {
            SpawnPlayer();
            hasSpawnedPlayer = true; // Mark as spawned
            //Debug.Log("Start: Player Spawned");
        }

        //spawn all asteroids and powerups
        StartCoroutine(SpawnPlanets());
        //Debug.Log("Start: Planets Spawned");

        //spawn enemies in between asteroids
        StartCoroutine(SpawnEnemiesPeriodically());
        //Debug.Log("Start: Enemies Spawned");

        //laser = laserPrefab.GetComponent<Laser>();

    }
    //******************************************************************************
    /*private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > lastShotTime + fireRate)
        {
            //laserPrefab.GetComponent<Laser>().FireProjectile();
            laser.FireProjectile();
            lastShotTime = Time.time;
        }
    }*/
    //******************************************************************************
    private IEnumerator SpawnPlanets()
    {
        while (true)
        {
            if (ShouldSpawnPlanet())
            {
                planetSpawner.SpawnPlanet();
            }
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private bool ShouldSpawnPlanet()
    {

        return true;
    }
    //******************************************************************************
    private IEnumerator SpawnEnemiesPeriodically()
    {
        while (true)
        {
            // Check game conditions to decide when to spawn enemies.
            if (ShouldSpawnEnemies())
            {
                enemySpawner.SpawnEnemy();
            }

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private bool ShouldSpawnEnemies()
    {
        // Implement your logic to determine when to spawn enemies.
        return true; // Replace with your game logic.
    }
    //******************************************************************************

    private void SpawnPlayer()
    {
        playerSpawnPoint = gameObject.GetComponent<Transform>();
        playerSpawnPoint.localPosition = Vector3.zero;

        // Check if the playerPrefab and playerSpawnPoint are assigned
        if (playerPrefab != null && playerSpawnPoint != null)
        {
            // Instantiate the player prefab at the spawn point with no rotation
            currentPlayer = Instantiate(playerPrefab, playerSpawnPoint.position, Quaternion.identity);
            //Debug.Log("Player Spawned.");
        }
        else
        {
            Debug.LogError("Player prefab or spawn point not assigned in the GameManager.");
        }
        currentPlayer.SetActive(true);
    }


    public void RespawnPlayer()
    {
        if (currentPlayer != null)
        {
            //Debug.Log("Respawning Player...");
            Destroy(currentPlayer); // Destroy the current player instance
            SpawnPlayer(); // Spawn a new player instance
            Debug.Log("Player Respawned.");
        }
        else
        {
            Debug.LogError("No player to respawn.");
        }
    }

    //******************************************************************************
    public void PlayerDie()
    {
        //what order should these two lines be in

        gameOverPanel.SetActive(true);

        currentPlayer.SetActive(false);

        //gameOverPanel.SetActive(true);

    }

}
