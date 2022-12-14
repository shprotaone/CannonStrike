using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool<Bullet> where Bullet : MonoBehaviour
{

    private List<Bullet> _pool;

    public List<Bullet> PoolList => _pool;
    public Bullet prefab { get; }
    public bool AutoExpand { get; set; }
    public Transform Container { get; }

    public BulletPool(Bullet prefab, float count, Transform container)
    {
        this.prefab = prefab;
        this.Container = container;
        this.CreatePool(count);
    }

    /// <summary>
    /// ???????? ????
    /// </summary>
    /// <param name="count"></param>
    private void CreatePool(float count)
    {
        this._pool = new List<Bullet>();

        for (int i = 0; i < count; i++)
        {
            this.CreateBullet();
        }
    }

    /// <summary>
    /// ???????? ???? ?? ????????? ??????????
    /// </summary>
    /// <param name="isActiveByDefault"></param>
    /// <returns></returns>
    private Bullet CreateBullet(bool isActiveByDefault = false)
    {
        var createdBullet = Object.Instantiate(this.prefab, this.Container);
        createdBullet.gameObject.SetActive(isActiveByDefault);

        this._pool.Add(createdBullet);

        return createdBullet;
    }

    /// <summary>
    /// ???????? ?? ????????? ????
    /// </summary>
    /// <param name="bullet"></param>
    /// <returns></returns>
    public bool HasFreeElement(out Bullet bullet)
    {
        foreach (var currentBullet in _pool)
        {
            if (!currentBullet.gameObject.activeInHierarchy)
            {
                bullet = currentBullet;
                currentBullet.gameObject.SetActive(true);
                return true;
            }
        }

        bullet = null;
        return false;
    }

    /// <summary>
    /// ????????? ????????? ????
    /// </summary>
    /// <returns></returns>
    public Bullet GetBullet()
    {
        if (this.HasFreeElement(out var bullet))
        {
            return bullet;
        }

        if (this.AutoExpand)
        {
            return this.CreateBullet(true);
        }

        throw new System.Exception("No free element");
    }
}
