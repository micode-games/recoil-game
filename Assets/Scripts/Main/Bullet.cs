using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") ||
            other.gameObject.CompareTag("Bullet") ||
            other.gameObject.CompareTag("Gun"))
        {
            return;
        }

        if (!other.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D contact = other.contacts[0];
            PrefabManager.Instance.SpawnWallHit(contact.point, contact.normal);
            CameraShake.Instance.Shake(0.05f, 0.1f);
        }
        Destroy(gameObject);
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
}