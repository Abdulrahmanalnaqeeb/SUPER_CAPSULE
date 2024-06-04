using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class stickyPlatform : MonoBehaviour
{
    
  private bool isOnMovingPlatform = false;
private Vector3 lastPlatformPosition;
private Transform playerTransform;

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.name == "Player")
    {
        isOnMovingPlatform = true;
        lastPlatformPosition = transform.position;
        playerTransform = collision.gameObject.transform;
    }
}

private void OnCollisionExit(Collision collision)
{
    if (collision.gameObject.name == "Player")
    {
        isOnMovingPlatform = false;
        playerTransform = null;
    }
}
void FixedUpdate()
{
    if (isOnMovingPlatform && playerTransform != null)
    {
        Vector3 platformMovement = transform.position - lastPlatformPosition;
        playerTransform.position += platformMovement;
        lastPlatformPosition = transform.position;
    }
}

}
