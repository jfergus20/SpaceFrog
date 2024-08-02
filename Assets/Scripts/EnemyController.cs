using UnityEngine;
//******************************************************************************
// This class does nothing
//******************************************************************************
public class EnemyController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemiesOnScreen = 20;
    private int currentEnemiesOnScreen = 0;
    public float spawnOffset = 5.0f;

    public float scale = 1.0f;
    public float minSize = 0.06f;
    public float maxSize = 0.1f;
    public float minSpeed = 1.0f;
    public float maxSpeed = 3.5f;

    public Camera mainCamera; // Reference to the main camera

    //public ScoreManager scoreManager;

    private void Start()
    {
        //gameManager = FindObjectOfType<GameManager>();
        //InitializeMainCameraReference();
        //scoreManager = 
    }

    private Vector3 GetRandomSpawnPosition()
    {
        // Use gameManager.GetMainCamera() to access the camera reference.
        //Camera mainCamera = gameManager.GetMainCamera();
        // Calculate the camera's view in world coordinates
        float cameraHeight = 2f * mainCamera.orthographicSize;
        float cameraWidth = cameraHeight * mainCamera.aspect;


        // Define buffer values to ensure objects are entirely outside the view
        float buffer = spawnOffset;

        // Calculate random spawn position outside of the camera's view
        float randomX = Random.Range(mainCamera.transform.position.x - cameraWidth / 2 - buffer, mainCamera.transform.position.x + cameraWidth / 2 + buffer);
        float randomY = Random.Range(mainCamera.transform.position.y - cameraHeight / 2 - buffer, mainCamera.transform.position.y + cameraHeight / 2 + buffer);

        // Set the spawn position
        return new Vector3(randomX, randomY, 0);
    }



    public void SpawnEnemy()
    {
        if (currentEnemiesOnScreen < maxEnemiesOnScreen)
        {
            GameObject newEnemy = Instantiate(enemyPrefab, GetRandomSpawnPosition(), Quaternion.identity);
            /*
            Vector3 spawnPosition = GetRandomSpawnPosition();

            GameObject selectedEnemy;
            selectedEnemy = enemyVariations[Random.Range(0, enemyVariations.Length)];

            GameObject enemy = Instantiate(selectedEnemy, spawnPosition, Quaternion.identity);
             */

            /*EnemyAI enemyAI = newEnemy.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {

                Rigidbody2D enemyRigidbody = newEnemy.GetComponent<Rigidbody2D>();

                if (enemyRigidbody != null)
                {
                    //Roam();

                    float randomSpeed = Random.Range(minSpeed, maxSpeed);
                    Vector2 randomDirection = Random.insideUnitCircle.normalized;
                    enemyRigidbody.velocity = randomDirection * randomSpeed;
                }

                float randomSize = Random.Range(minSize, maxSize);
                newEnemy.transform.localScale = new Vector3(randomSize * scale, randomSize * scale, 1f);
            }*/
            //change size of enemy
            float randomSize = Random.Range(minSize, maxSize);
            newEnemy.transform.localScale = new Vector3(randomSize * scale, randomSize * scale, 1f);

            // Set up the new enemy (e.g., initialize behavior, AI, etc.)


            currentEnemiesOnScreen++;
            /*


   

            objSpawned++; // Increment the count
            */
        }
    }


    /*private void OnDestroy()
    {
        Debug.Log("OnDestroy, increasing score");
        scoreManager.IncreaseScore(10);
        currentEnemiesOnScreen--;
    }*/
    /*public void EnemyDestroyed()
    {
        Debug.Log("EnemyDestroyed, increasing score");
        scoreManager.IncreaseScore(10);
        currentEnemiesOnScreen--;
    }*/
}