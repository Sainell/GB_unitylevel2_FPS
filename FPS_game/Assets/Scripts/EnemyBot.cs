using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
namespace FPS
{
    public class EnemyBot : BaseSceneObject, IDamageable
    {
        public bool IsAlive { get { return _currentHealth > 0; } }

        [SerializeField]
        private Transform _eyesTransform;
        [SerializeField]
        private float _searchDistance = 30f;
        [SerializeField]
        private float _rangeAttackDistance = 15f;
        [SerializeField]
        private float _meleAttackDistance = 5f;
        private NavMeshAgent _agent;
        [SerializeField]
        private Vector3 _randomPos;
        private Transform _targetTransform;

        private WayPoint[] _waypoints;
        private int _currentWP;
        private float _currentWPTimeOut;
        [SerializeField]
        private bool UseRandomWP;

        private bool _seenTarget;
        [SerializeField]
        private float _maxRandomWPradius = 20f;
        private BaseWeapon _weapon;
        [SerializeField]
        private float _currentHealth;
        public float CurrentHealth { get { return _currentHealth; } }

        [SerializeField]
        private float _maxHealth;
        public float MaxHealth { get { return _maxHealth; } }

        protected void Start()
        {
            //Initialize();
          //  SetTarget(PlayerModel.LocalPlayer.transform);
        }
        public void SetTarget(Transform target)
        {
            _targetTransform = target;
        }
        public void Initialize(BotSpawner _spawner)
        {
            _agent = GetComponent<NavMeshAgent>();
            _weapon = GetComponentInChildren<BaseWeapon>(true);
            UseRandomWP = _spawner.UseRandomWP;
            if (UseRandomWP)
            {
                _randomPos = GenerateRandomWP();
            }
            else
            {
                _waypoints = _spawner.GetComponentsInChildren<WayPoint>();

            }

            if (Main.Instance != null)
            {
                Main.Instance.EnemyBotsController.AddBot(this);
            }
        }

        private Vector3 GenerateRandomWP()
        {
            Vector3 randomPos = Random.insideUnitSphere * _maxRandomWPradius;
            NavMeshHit navMeshHit;
            if (NavMesh.SamplePosition(transform.position + randomPos, out navMeshHit, _maxRandomWPradius * 1.5f, NavMesh.AllAreas))
                randomPos = navMeshHit.position;
            else return transform.position;


            return randomPos;
        }




        private void Update()
        {
            if (!IsAlive) return;
            if (_targetTransform)
            {
                float dist = Vector3.Distance(transform.position, _targetTransform.position);
                if (dist < _rangeAttackDistance)
                {
                    //attack range; 
                    _seenTarget = !IsTargetBlocked();
                    if (_seenTarget)
                    {
                        _agent.SetDestination(_targetTransform.position);
                        if(_weapon)
                        _weapon.Fire();
                    }
                }
                else if (dist < _meleAttackDistance)
                {
                    
                    _seenTarget = !IsTargetBlocked();
                    _agent.SetDestination(_targetTransform.position);
                    //mele attack
                }
                else if (dist < _searchDistance)
                {
                    _seenTarget = !IsTargetBlocked();
                    if (_seenTarget) _agent.SetDestination(_targetTransform.position);
                }
                else
                {
                    _seenTarget = false;
                }
            }
            if (_seenTarget) return;
            if (UseRandomWP)
            {
                _agent.SetDestination(_randomPos);
                if (!_agent.hasPath || _agent.remainingDistance > _maxRandomWPradius * 2f)
                {
                    _randomPos = GenerateRandomWP();
                }
            }
            else
            {
                if (_waypoints.Length > 1)
                {
                    _agent.SetDestination(_waypoints[_currentWP].transform.position);
                    if (!_agent.hasPath)
                    {
                        _currentWPTimeOut += Time.deltaTime;
                        if (_currentWPTimeOut >= _waypoints[_currentWP].WaitTime)
                        {
                            _currentWPTimeOut = 0;
                            _currentWP++;
                            if (_currentWP >= _waypoints.Length)
                            {
                                _currentWP = 0;
                            }
                        }
                    }
                }
            }
        }

        private bool IsTargetBlocked()
        {
            RaycastHit hit;
            if(Physics.Linecast(_eyesTransform.position, _targetTransform.position,out hit))
            {
                if (hit.transform == _targetTransform)
                {
                    Debug.DrawLine(_eyesTransform.position, hit.point, Color.red);
                    return false;
                }
            }
            Debug.DrawLine(_eyesTransform.position, _targetTransform.position, Color.blue);
            return true;

        }
        public void ApplyDamage(float damage)
        {
            if (_currentHealth <= 0)
                return;
            _currentHealth -= damage;
            if (!IsAlive)
                Death();
        }

        public void Death()
        {
            Main.Instance.EnemyBotsController.RemoveBot(this);

            foreach (var child in GetComponentsInChildren<Transform>())
            {
                
                child.SetParent(null);
                Destroy(child.gameObject, 3f);

                var col = child.GetComponent<Collider>();
                if (col) col.enabled = true;
                var rb = child.gameObject.AddComponent<Rigidbody>();
                rb.mass = 1;
                rb.AddForce(Vector3.up * Random.Range(1f, 10f), ForceMode.Impulse);
            }


        }

    }
    
}
