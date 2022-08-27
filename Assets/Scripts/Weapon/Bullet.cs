using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _lifetime = 5f;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private Rigidbody2D _rigidBody;
    
    private bool _check;

    private void OnEnable()
    {
        _check = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Finish") && !_check)
        {
            other.GetComponent<GoalSystem>().IncreaseGoal();
            StopAllCoroutines();
            _check = true;
        }
    }
    public void Construct()
    {
        StartCoroutine(LifeRoutine());

        _rigidBody.AddForce(Vector2.down * _bulletSpeed, ForceMode2D.Impulse);
    }

    private IEnumerator LifeRoutine()
    {
        yield return new WaitForSecondsRealtime(_lifetime);

        StartCoroutine(Deactivate());

        yield break;
    }

    private IEnumerator Deactivate()
    {
        _rigidBody.velocity = Vector3.zero;

        yield return new WaitForSeconds(0.7f);

        gameObject.SetActive(false);

        yield break;
    }
}
