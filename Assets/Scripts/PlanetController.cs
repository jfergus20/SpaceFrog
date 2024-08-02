using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{

    public GameObject planetPrefab;
    public int maxPlanetsOnScreen = 5;
    private int currentPlanetsOnScreen = 0;
    public float spawnOffset = 5.0f;

    public float scale;
    public float minSize;
    public float maxSize;
    //public float scale = 0.1f;
    //public float minSize = 0.1f;
    //public float maxSize = 0.1f;

    public Camera mainCamera; // Reference to the main camera

    //**************************************************************************


    private void Start()
    {
        //gameManager = FindAnyObjectByType<GameManager>();
        //gameManager = GameObject.Find("GameManager");
        //gameManager = FindObjectOfType<GameManager>();
        //InitializeMainCameraReference();
    }

    private Vector3 GetRandomSpawnPosition()
    {
        //Camera mainCamera = gameManager.GetMainCamera();

        // Calculate the camera's view in world coordinates
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Define buffer values to ensure objects are entirely outside the view
        float buffer = spawnOffset;// + radius?

        // Calculate random spawn position outside of the camera's view/
        float randomX = Random.Range(mainCamera.transform.position.x - cameraWidth / 2 - buffer,
                                        mainCamera.transform.position.x + cameraWidth / 2 + buffer);
        float randomY = Random.Range(mainCamera.transform.position.y - cameraHeight / 2 - buffer,
                                        mainCamera.transform.position.y + cameraHeight / 2 + buffer);

        //check valid?

        // Set the spawn position
        return new Vector3(randomX, randomY, 0);

        /*
        //ValidSpawnPos()
        float minX = -22f;
        float maxX = 22f;
        float minY = -22f;
        float maxY = 22f;

        float leftBoundary = pos.x - radius;
        float rightBoundary = pos.x + radius;
        float topBoundary = pos.y + radius;
        float bottomBoundary = pos.y - radius;

        // Check if the calculated boundaries are within the defined boundaries
        bool withinXBounds = leftBoundary >= minX && rightBoundary <= maxX;
        bool withinYBounds = bottomBoundary >= minY && topBoundary <= maxY;

        bool collisionOnSpawn = CollisionOnSpawn();
        return withinXBounds && withinYBounds && !collisionOnSpawn;


        //**********************************************************************

        //GetRandomSpawnPosition()

        mainCamera = Camera.main;

        // Calculate the camera's view in world coordinates
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;

        // Define buffer values to ensure objects are entirely outside the view
        float buffer = spawnOffset;

        // Calculate random spawn position outside of the camera's view
        float randomX = Random.Range(mainCamera.transform.position.x - cameraWidth / 2 - buffer, mainCamera.transform.position.x + cameraWidth / 2 + buffer);
        float randomY = Random.Range(mainCamera.transform.position.y - cameraHeight / 2 - buffer, mainCamera.transform.position.y + cameraHeight / 2 + buffer);

        //Vector3 checkMe = new Vector3(randomX, randomY, 0);
        //bool isValid = ValidSpawnPos(checkMe, radius);//spawn position, object size, boundary wall





        // Set the spawn position
        return new Vector3(randomX, randomY, 0);
         */
    }


    public void SpawnPlanet()
    {
        if (currentPlanetsOnScreen < maxPlanetsOnScreen)
        {
            //GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);

            GameObject newPlanet = Instantiate(planetPrefab,
                                                GetRandomSpawnPosition(),
                                                Quaternion.identity);
            //change size of enemy
            //Debug.Log("planetsizepre: " + newPlanet.transform.localScale);
            float randomSize = Random.Range(minSize, maxSize);
            //Debug.Log("rand: " + randomSize);
            //Debug.Log("min: " + minSize);
            //Debug.Log("max: " + maxSize);
            newPlanet.transform.localScale = new Vector3(randomSize * scale,
                                                        randomSize * scale, 1f);
            //Debug.Log("planetsizepost: " + newPlanet.transform.localScale);

            // Set up the new enemy (e.g., initialize behavior, AI, etc.)
            //EnemyController

            currentPlanetsOnScreen++;
        }


        /*
        while (true)
        {
            if (objSpawned < maxObjs)
            {

                GameObject selectedAsteroid;
                var i = Random.Range(0, 3);
                var s = 10;

                float radius = 1.0f;

                if (i == 0)
                {
                    s = 15;
                    //Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadX, spawnRadX), Random.Range(-spawnRadY, spawnRadY), 0);
                    selectedAsteroid = asteroidVariations[Random.Range(0, asteroidVariations.Length)];

                }
                else
                {
                    s = 1;
                    //Vector3 spawnPosition = new Vector3(Random.Range(-spawnRadX, spawnRadX), Random.Range(-spawnRadY, spawnRadY), 0);
                    selectedAsteroid = planetVariations[Random.Range(0, planetVariations.Length)];
                }

                CircleCollider2D collider = selectedAsteroid.GetComponent<CircleCollider2D>();

                radius = collider.radius;

                Vector3 spawnPosition = GetRandomSpawnPosition(radius);


                GameObject asteroid = Instantiate(selectedAsteroid, spawnPosition, Quaternion.identity);

                Rigidbody2D asteroidRigidbody = asteroid.GetComponent<Rigidbody2D>();

                if (asteroidRigidbody != null)
                {
                    float randomSpeed = Random.Range(minSpeed, maxSpeed);
                    Vector2 randomDirection = Random.insideUnitCircle.normalized;
                    asteroidRigidbody.velocity = randomDirection * randomSpeed;
                }

                float randomSize = Random.Range(minSize, maxSize);
                asteroid.transform.localScale = new Vector3(randomSize * s, randomSize * s, 1f);





                objSpawned++; // Increment the count
            }

            yield return new WaitForSeconds(1.0f / spawnRate);
        }
         */


    }

    public void PlanetDestroyed()
    {
        //score increase
        currentPlanetsOnScreen--;
    }
}