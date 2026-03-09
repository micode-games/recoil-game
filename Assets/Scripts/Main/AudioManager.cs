using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [Header("Sound Effects")]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip finishSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip enemyDeathSound;
    
    private AudioSource _audioSource;
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        
        _audioSource = GetComponent<AudioSource>();
        if (_audioSource == null)
        {
            _audioSource = gameObject.AddComponent<AudioSource>();
        }
    }
    
    public void PlayShootSound()
    {
        if (shootSound != null)
        {
            _audioSource.PlayOneShot(shootSound);
        }
    }
    
    public void PlayFinishSound()
    {
        if (finishSound != null)
        {
            _audioSource.PlayOneShot(finishSound);
        }
    }
    
    public void PlayHitSound()
    {
        if (hitSound != null)
        {
            _audioSource.PlayOneShot(hitSound);
        }
    }
    
    public void PlayEnemyDeathSound()
    {
        if (enemyDeathSound != null)
        {
            _audioSource.PlayOneShot(enemyDeathSound);
        }
    }
}
