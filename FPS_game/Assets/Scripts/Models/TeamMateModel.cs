using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;
namespace FPS
{
    public class TeamMateModel : MonoBehaviour {


        private NavMeshAgent _agent;
        private ThirdPersonCharacter _character;

        private void Start()
        {
            _agent = GetComponent<NavMeshAgent>();
            _character = GetComponent<ThirdPersonCharacter>();
            _agent.updatePosition = true;
            _agent.updateRotation = false;
        }
        private void Update()
        {
            if (_agent.remainingDistance > _agent.stoppingDistance)
                _character.Move(_agent.desiredVelocity, false, false);

            else _character.Move(Vector3.zero,false,false);
        }
        public void SetTarget(Vector3 pos)
        {
            _agent.SetDestination(pos);
        }

    }
}
