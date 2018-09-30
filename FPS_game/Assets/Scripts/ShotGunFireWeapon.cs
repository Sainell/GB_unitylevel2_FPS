using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace FPS
{
    public class ShotGunFireWeapon : BaseWeapon
    {
        [SerializeField]
        private Transform _firepoint;
        public override void Fire()
        {
            
            if (!TryShoot()) return;
            else
            {
               for (int i = 0; i < 21; i++)
                {

                    BaseAmmo bullet = Instantiate(_ammoPrefabGun[i],_firepoint);
                    
                    bullet.Initialize(_force);
                }
            }
        }

        public override void Reload()
        {
           //
        }
    }
}