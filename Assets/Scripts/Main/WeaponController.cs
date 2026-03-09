using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] private float spread = 0.5f;          // разброс пуль
    [SerializeField] private float bulletForce = 20f;      // скорость пуль
    [SerializeField] private int bulletsPerShot = 5;       // количество пуль при выстреле
    [SerializeField] private float fireRate = 0.5f;        // задержка между выстрелами
    private float _lastShotTime;

    [Header("Rotation")]
    [SerializeField] private float rotationSpeed = 10f;    // скорость вращения

    [Header("Recoil")]
    [SerializeField] private float recoilForce = 0.3f;     // сила отдачи (накапливается)
    [SerializeField] private float recoilRecoverySpeed = 10f; // скорость возврата отдачи к 0
    private float _currentRecoil;

    [Header("Weapon Position")]
    [SerializeField] private float baseDist = 0.6f;        // базовая дистанция оружия от игрока (ВАЖНО!)
    [SerializeField] private float minDist = 0.1f;         // минимальная дистанция (чтобы не влезало в игрока)

    [Header("Refs")]
    [SerializeField] private Transform firePoint;          // точка выстрела
    [SerializeField] private GameObject bulletPrefab;      // префаб пули

    [Header("Collision")]
    [SerializeField] private LayerMask obstacleLayer;      // слой препятствий

    private Transform _owner;

    private void Awake()
    {
        _owner = transform.parent;
    }

    private void Update()
    {
        HandleRotationAndPosition();
    }

    private void HandleRotationAndPosition()
    {
        // плавно возвращаем отдачу к нулю
        _currentRecoil = Mathf.Lerp(_currentRecoil, 0f, Time.deltaTime * recoilRecoverySpeed);

        Camera cam = Camera.main;
        if (cam == null || _owner == null) return;

        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)_owner.position).normalized;

        // вращение
        Vector3 targetRight = direction;
        transform.right = Vector3.Lerp(transform.right, targetRight, Time.deltaTime * rotationSpeed);

        // дистанция оружия от игрока + проверка препятствий
        float dist = baseDist;

        RaycastHit2D hit = Physics2D.Raycast(_owner.position, direction, baseDist, obstacleLayer);
        if (hit.collider != null)
        {
            dist = Mathf.Clamp(hit.distance, minDist, baseDist);
        }

        // ОТДАЧА (вариант 1: "вдавливает" оружие ближе к игроку)
        float finalDist = Mathf.Max(dist - _currentRecoil, minDist);

        // Если хочешь чтобы оружие отлетало ОТ игрока — используй это вместо строки выше:
        // float finalDist = Mathf.Max(dist + _currentRecoil, minDist);

        float yOffset = direction.y * 0.5f;

        // флип
        if (mousePos.x < _owner.position.x)
        {
            transform.localPosition = new Vector3(-finalDist, yOffset, 0f);
            transform.localScale = new Vector3(0.4f, -0.4f, 0.8f);
        }
        else
        {
            transform.localPosition = new Vector3(finalDist, yOffset, 0f);
            transform.localScale = new Vector3(0.4f, 0.4f, 0.8f);
        }
    }

    public bool Shoot(Vector2 direction)
    {
        if (Time.time - _lastShotTime < fireRate) return false;

        _lastShotTime = Time.time;
        _currentRecoil += recoilForce;

        // звук (если есть)
        AudioManager.Instance?.PlayShootSound();

        if (bulletPrefab == null || firePoint == null) return true;

        for (int i = 0; i < bulletsPerShot; i++)
        {
            Vector2 variance = new Vector2(
                Random.Range(-spread, spread),
                Random.Range(-spread, spread)
            );

            GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

            Rigidbody2D rb = newBullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                // В большинстве Unity версий правильно velocity (если у тебя linearVelocity работает — можешь вернуть)
                rb.linearVelocity = (direction + variance).normalized * bulletForce;
            }
        }

        return true;
    }
}
