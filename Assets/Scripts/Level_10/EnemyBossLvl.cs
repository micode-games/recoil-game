using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBossLvl : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            Invoke(nameof(ReloadScene), 1f);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            PrefabManager.Instance.SpawnEnemyDeath(transform.position);
            CameraShake.Instance.Shake(0.15f, 0.3f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

