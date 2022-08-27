using UnityEngine;
using TMPro;
using System;

public class AmmoSystem : MonoBehaviour
{
    public static Action OnAmmoIsOut;

    [SerializeField] private TMP_Text _ammoView;
    [SerializeField] private float _ammo;

    public float CurrentAmmo => _ammo;

    public void DecreaseAmmo()
    {
        _ammo--;
        UpdateView();

        if (_ammo <= 0)
        {
            OnAmmoIsOut?.Invoke();
        }
    }

    private void ResetAmmo()
    {
        _ammo = 30;
        UpdateView();
    }

    private void UpdateView()
    {
        _ammoView.text = _ammo.ToString();
    }
}
