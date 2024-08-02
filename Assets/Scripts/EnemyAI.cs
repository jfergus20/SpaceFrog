using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    private PlayerController playerController; // Reference to the PlayerController script

    private void Start()
    {
        playerController = FindObjectOfType<PlayerController>();

        if (playerController == null)
        {
            Debug.LogError("PlayerController not found.");
        }
    }

    private void Update()
    {
        if (playerController == null)
        {
            Debug.LogError("PlayerController is null.");
            return;
        }

        Transform playerTransform = playerController.GetPlayerTransform();

        if (playerTransform == null)
        {
            Debug.LogError("Player transform is null.");
            return;
        }
        //Debug.Log("Enemy position: " + transform.position);
        //Debug.Log("Player position: " + playerTransform.position);
        Vector2 direction = (playerTransform.position - transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
}
