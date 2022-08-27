using UnityEngine;
using DG.Tweening;

public class Obstacle2 : Obstacle
{
    private Vector3 _rotate = new Vector3(0, 0, 359);

    public override void Move()
    {
        _obstacle.DORotate(_rotate, _duration/100,RotateMode.Fast)
                 .SetLoops(-1,LoopType.Incremental);
    }
}
