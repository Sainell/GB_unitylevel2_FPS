using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace FPS
{
    public class WayPoint : MonoBehaviour
    {
        [SerializeField]
        public float WaitTime = 1f;
        [SerializeField]
        public UnityEvent OnReachEvent;

        
    }
}