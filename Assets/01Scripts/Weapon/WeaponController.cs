using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    [SerializeField]
    private Weapon _curWeapon;
    public Weapon CurWeapon => _curWeapon;

    [SerializeField] private Transform _gunHolder;

    private Player _player;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _player.InputReader.Fire += FireHandle;
    }

    private void Update()
    {
        if (_curWeapon == null)
            return;

        _curWeapon.transform.position = _gunHolder.position;
    }

    private void FireHandle()
    {
        Debug.Log("Fire");
        _curWeapon?.Fire();
    }
}
