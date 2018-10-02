using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{

    public class BotSpawner : MonoBehaviour
    {
        public bool UseRandomWP;

        [SerializeField]
        private EnemyBot _prefab;

        private EnemyBot _instance;

        private void Update()
        {
            if(!_instance)
            {
                _instance = Instantiate(_prefab, transform.position, transform.rotation);
                _instance.Initialize(this);
                
            }
        }

    }
}