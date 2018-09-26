using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS{

    public abstract class BaseWeapon : BaseSceneObject
    {
        [SerializeField]
        protected BaseAmmo _ammoPrefab;
        [SerializeField]
        protected float _force;
        [SerializeField]
        protected float _reloadTime;
        private float _reloadTimer;
        [SerializeField]
        protected float _timeout = 0.5f;
        protected float _lastShotTime;

        public virtual void Fire()
        {
            if (Time.time - _lastShotTime < _timeout)
                return;
            _lastShotTime = Time.time;
        }
        public abstract void Reload();
    }
}
