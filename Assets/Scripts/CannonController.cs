using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    [SerializeField] private Weapon _weapon;

    private void Update()
    {        
        if (Input.GetMouseButton(0))
        {
            _weapon.ShootingDelay();
        }
    }
}
