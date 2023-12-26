using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponState 
{
    protected Player _player;
    protected WeaponController _weaponController;

    public WeaponState(Player player, WeaponController weaponController)
    {
        _player = player;
        _weaponController = weaponController;
    }

    public virtual void Enter() { }
    protected virtual void Update() { }
    public virtual void Exit() { }
}
