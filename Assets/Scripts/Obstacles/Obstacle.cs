using UnityEngine;
using DG.Tweening;

public abstract class Obstacle : MonoBehaviour
{
    [SerializeField] protected Transform _obstacle;
    [SerializeField] protected float _duration;

    private void Start()
    {
        Move();
    }

    public abstract void Move();

    private void OnDisable()
    {
        _obstacle.DOKill();
    }
}
