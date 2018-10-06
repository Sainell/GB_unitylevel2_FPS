using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{

    public abstract class BaseWeapon : BaseSceneObject
    {
        [SerializeField]
        protected BaseAmmo _ammoPrefab;
        [SerializeField]
        public BaseAmmo[] _ammoPrefabGun;
        [SerializeField]
        protected float _force;
        [SerializeField]
        protected float _reloadTime;
        private float _reloadTimer;
        [SerializeField]
        protected float _timeout = 0.5f;
        protected float _lastShotTime;

        public abstract void Fire();
        

        protected bool TryShoot()

        {
            if (Time.time - _lastShotTime < _timeout)
                return false;
            _lastShotTime = Time.time;
                return true;
        }

        public abstract void Reload();
    }
}

