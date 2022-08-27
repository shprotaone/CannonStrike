using UnityEngine;
using DG.Tweening;

public class Obstacle1 : Obstacle
{
    [SerializeField] private Transform _secondPoint;

    public override void Move()
    {
        _obstacle.DOMoveX(_secondPoint.position.x, _duration)
                 .SetLoops(-1,LoopType.Yoyo).SetEase(Ease.InOutQuad);
    }
}
