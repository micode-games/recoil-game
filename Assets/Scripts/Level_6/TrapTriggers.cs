using UnityEngine;

public class TrapTriggers : MonoBehaviour
{
    [SerializeField] private Transform spikes;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            spikes.position = new Vector2(6, spikes.position.y);
        }
    }
}
