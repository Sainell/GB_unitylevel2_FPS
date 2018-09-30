using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS {
    public class SingleFireWeapon : BaseWeapon
    {
        [SerializeField]
        private Transform _firepoint;
        public override void Fire()
        {
            if (!TryShoot()) return;
            else
            {
                BaseAmmo bullet = Instantiate(_ammoPrefab, _firepoint.position, _firepoint.rotation);
                bullet.Initialize(_force);
            }
        } 

        public override void Reload()
        {
            //
        }
    }
}
	         
