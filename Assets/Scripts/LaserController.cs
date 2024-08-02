using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class LaserController : MonoBehaviour
{

    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate = .05f;//smaller = faster i think
    [SerializeField] private float projectileSpeed = 8f;
    private GameObject gameObject;

    private float lastShotTime = 0f;
    Rigidbody2D rigidbody;
    Vector2 lastVelocity;
    private GameObject projectile;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        //gameObject = GetComponent<GameObject>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && Time.time > lastShotTime + fireRate)
        {
            FireProjectile();
            lastShotTime = Time.time;
        }
    }

    void FixedUpdate()
    {
        lastVelocity = rigidbody.velocity;
    }

    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        //projectile = Instantiate(projectilePrefab, transform.position, transform.rotation);
        //projectile.SetComponent<LaserCollision>
        Rigidbody2D projectileRigidbody = projectile.GetComponent<Rigidbody2D>();

        // Ensure the projectile does not collide with the player
        Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());

        // Apply a 90-degree rotation to the projectile
        projectile.transform.Rotate(Vector3.forward * -90f);

        Vector2 velocity = transform.up * projectileSpeed;
        projectileRigidbody.velocity = velocity;

        projectile.layer = LayerMask.NameToLayer("Default");
    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Laser ... " + collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Boundary") && projectile != null)
        {
            Debug.Log("Laser-Boundary");
            // Destroy the laser (the projectile) when it hits the boundary
            Destroy(projectile);
        }


    }*/
}