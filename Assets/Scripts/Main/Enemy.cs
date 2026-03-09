using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
   private void OnCollisionEnter2D(Collision2D other)
   {
      if (other.gameObject.CompareTag("Player"))
      {
         // Проигрываем звук удара
         AudioManager.Instance?.PlayHitSound();
         
         Destroy(other.gameObject);
         Invoke(nameof(ReloadScene), 1f);
      }

      if (other.gameObject.CompareTag("Bullet"))
      {
         AudioManager.Instance?.PlayEnemyDeathSound();
         PrefabManager.Instance.SpawnEnemyDeath(transform.position);
         CameraShake.Instance.Shake(0.15f, 0.3f);
         HitStop.Instance.Stop(0.05f);
      }
   }

   private void ReloadScene()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
