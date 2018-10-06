using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class Target : BaseSceneObject, IDamageable
    {
        [SerializeField]
        float _maxHealth = 100;
        [SerializeField]
        float _currentHealth = 100;
        public float MaxHealth { get { return _maxHealth; } }



        public float CurrentHealth { get { return _currentHealth; } }


        public void ApplyDamage(float damage)
        {
            if (_currentHealth <= 0) return;
            else
            {
                _currentHealth -= damage;
                if (_currentHealth <= 0)
                {
                    del();
                }
            }
        }

        private void del()      
        {
            Destroy(gameObject,3f);
        }

    }
}
