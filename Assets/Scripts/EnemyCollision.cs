using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Enemy-Projectile");
            ScoreManager.instance.IncreaseScore(10);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    //[SerializeField] public EnemyController enemyController;
    //public EnemyController enemyController;
    public GameObject enemyController;

    // Start is called before the first frame update
    //public ScoreManager scoreManager;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            //Debug.Log("Enemy--Projectile");
            //Debug.Log("increasing score");

            //scoreManager.GetComponent<ScoreManager>().IncreaseScore(10);
            //enemyController.EnemyDestroyed();
            enemyController.GetComponent<EnemyController>().EnemyDestroyed();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
*/