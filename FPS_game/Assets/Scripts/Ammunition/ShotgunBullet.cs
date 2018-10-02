using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS {


    public class ShotgunBullet : BaseAmmo
    {
        private bool _isHitted;
        private float _speed;

       
        public override void Initialize(float force)
        {
            _speed = force;
        }
       
        private void Start()
        {
            
        }
        private void FixedUpdate()
        {
            if (_isHitted)
                return;
            Vector3 finalPos = transform.position + transform.forward * _speed * Time.fixedDeltaTime;
            RaycastHit hit;
            if (Physics.Linecast(transform.position, finalPos, out hit, _layerMask))
            {
                _isHitted = true;
                transform.position = hit.point;

                IDamageable d = hit.collider.GetComponent<IDamageable>();
                if (d != null)
                    d.ApplyDamage(_damage);

                Destroy(gameObject, 0.3f);

            }
            else
            {
                transform.position = finalPos;
                Destroy(gameObject, _destroyTime);
            }
        }
    }
}
    


