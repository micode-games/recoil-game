using UnityEngine;

public class SpikesToPlayer : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float flySpeed = 0.5f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.Lerp(transform.position, player.position, Time.deltaTime * flySpeed);
    }
}
