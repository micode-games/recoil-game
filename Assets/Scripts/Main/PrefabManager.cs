using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Instance;

    [Header("Effects")] 
    [SerializeField] private GameObject wallHitEffect;
    [SerializeField] private GameObject enemyDeathEffect;
    [SerializeField] private float effectLifeTime = 3f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SpawnWallHit(Vector2 position, Vector2 normal)
    {
        if (wallHitEffect != null)
        {
            var go = Instantiate(wallHitEffect, position, Quaternion.LookRotation(normal));
            Destroy(go, effectLifeTime);
        }
    }

    public void SpawnEnemyDeath(Vector2 position)
    {
        if (enemyDeathEffect != null)
        {
            var go = Instantiate(enemyDeathEffect, position, Quaternion.identity);
            Destroy(go, effectLifeTime);
        }
    }
}
