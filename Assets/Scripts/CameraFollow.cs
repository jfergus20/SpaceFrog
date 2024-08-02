using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTransform;
    public Vector3 offset;
    public float smoothSpeed = 3f;
    public float minX = -16f;
    public float maxX = 16f;
    public float minY = -18f;
    public float maxY = 18f;
    //public GameManager gameManager;

    private void LateUpdate()
    {
        //if (gameManager.gameOverPanel == null || !gameManager.gameOverPanel.activeInHierarchy)
        //{
        if (playerTransform == null)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        Vector3 desiredPos = playerTransform.position + offset;

        // Clamp the desired position within boundaries
        desiredPos.x = Mathf.Clamp(desiredPos.x, minX, maxX);
        desiredPos.y = Mathf.Clamp(desiredPos.y, minY, maxY);

        Vector3 smoothPos = Vector3.Lerp(transform.position, desiredPos, smoothSpeed * Time.deltaTime);
        transform.position = smoothPos;
        //}
    }

}
