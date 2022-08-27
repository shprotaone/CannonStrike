using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private AmmoSystem _ammoSystem;
    [SerializeField] private Bullet _bulletPrefab;

    [SerializeField] private Transform _shootPosition;
    [SerializeField] private Transform _bulletContainer;
    [SerializeField] private AudioSource _shootSound;

    [SerializeField] private float _fireRate = 15f;
    [SerializeField] private float _poolCounter;
        
    private float _nextTimeToFire = 0;

    private BulletPool<Bullet> _pool;

    private void Start()
    {
        this._pool = new BulletPool<Bullet>(_bulletPrefab, _poolCounter, _bulletContainer);
    }

    public void ShootingDelay()
    {
        if(Time.time >= _nextTimeToFire && _ammoSystem.CurrentAmmo > 0)
        {
            _nextTimeToFire = Time.time + 1f / _fireRate;           
            Shoot();
        }
    }

    private void Shoot()
    {
        var bullet = _pool.GetBullet();

        bullet.transform.position = _shootPosition.position;
        bullet.GetComponent<Bullet>().Construct();

        _ammoSystem.DecreaseAmmo();
        _shootSound.Play();
    }
}
