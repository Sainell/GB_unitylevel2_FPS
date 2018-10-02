using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class Firstaidkit : BaseAmmo
    { 
         [SerializeField]
        private Transform finalPos;
        private bool _isHitted;
      //  private float _heal = -30;

        public override void Initialize(float force)
        {

        }
        public void Start()
        {
            
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log("hit");
            IDamageable d = other. GetComponent<IDamageable>();
            if (d != null)
            {
                d.ApplyDamage(_damage);

                Destroy(gameObject, 0.3f);
            }
        }

       
    }
}
