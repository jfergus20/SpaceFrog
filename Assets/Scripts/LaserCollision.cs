using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserCollision : MonoBehaviour
{
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        projectile = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*
        //Debug.Log("Laser ... " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Boundary") && projectile != null)
        {
            Debug.Log("Laser-Boundary");
            // Destroy the laser (the projectile) when it hits the boundary
            Destroy(projectile);
        }

        if (collision.gameObject.CompareTag("Planet") && projectile != null)
        {
            Debug.Log("Laser-Planet");
            // Destroy the laser (the projectile) when it hits the boundary
            Destroy(projectile);
        }

        if (collision.gameObject.CompareTag("Projectile") && projectile != null)
        {
            Destroy(collision.gameObject);
        }
        */
        /*if (collision.gameObject.CompareTag("Enemy") && projectile != null)
        {
            Debug.Log("Laser-Enemy");
            Destroy(collision.gameObject);//this doesnt seem to work
        }*/

    }
}
