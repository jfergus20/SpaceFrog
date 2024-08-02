using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 2f;
    [SerializeField] public float boostSpeed = 2.2f;
    [SerializeField] public float rotationSpeed = 300;
    [SerializeField] public float vertBound = 9f; 
    [SerializeField] public float horizBound = 16f;
    [SerializeField] public float wallBounce = 100f;
    
    private Rigidbody2D rigidbody;
    private Vector2 lastVelocity;

    private GameManager gameManager;
    //*****************************
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private float fireRate = .2f;
    [SerializeField] private float projectileSpeed = 7.5f;
    private float lastShotTime = 0f;
    private Vector2 laserLastVelocity;
    private Rigidbody2D laserrb;
    //****************************

    public static PlayerController Instance { get; private set; }

    public Transform playerTransform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetPlayerTransform(Transform player)
    {
        playerTransform = player;
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }



    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
 
    }
    //**************************************************************************
    private void Update()
    {
   
        //Debug.Log("Player position: " + transform.position);

        
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            moveSpeed = 4f;
        }


        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(horiz, vert, 0f);

        transform.position += dir * moveSpeed * Time.deltaTime;


        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10f;


        Vector3 playerPos = Camera.main.WorldToScreenPoint(transform.position);
        mousePos -= playerPos;

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg - 90f;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);


        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.LeftShift))
        {
            moveSpeed = 2f;
        }

    }
    //**************************************************************************

    private void FixedUpdate()
    {
        lastVelocity = rigidbody.velocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Boundary"))
        {


            var speed = lastVelocity.magnitude;
            var direction = Vector2.Reflect(lastVelocity.normalized,
                                            collision.contacts[0].normal);

            rigidbody.velocity = direction * Mathf.Max(speed, 0f);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerDie();
        }

    }

    void PlayerDie()
    {
        FindAnyObjectByType<GameManager>().PlayerDie();
    }
}