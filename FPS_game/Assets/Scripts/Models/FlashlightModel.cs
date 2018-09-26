using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class FlashlightModel : MonoBehaviour
    {
        private Light _light;
        [SerializeField]
        public float ButterySize = 50;
        private float ButteryMaxSize = 100;
        [SerializeField]
        private bool ButteryFlag = true;
        
        public bool IsOn
        {
            get
            {
                if (!_light) return false;
                return _light.enabled;
            }
        }

        private void Awake()
        {
            _light = GetComponent<Light>();
        }

        public void On()
        {
            if (ButterySize <= 30) return;
            _light.enabled = true;
            ButteryFlag = false;

        }

        public void Off()
        {
            _light.enabled = false;
            ButteryFlag = true;
        }

        public void Switch()
        {
            if (IsOn)
                Off();
            else
                On();
        }


        public void ButteryReg()
        {
            if (ButterySize <= ButteryMaxSize)
                ButterySize += 5 * Time.deltaTime;
        }
        public void ButteryCheck()
        {
            if (IsOn)
            {
                ButterySize -= 5 * Time.deltaTime;
                if (ButterySize <= 0) Switch();
            }
            else if (ButteryFlag)
                ButteryReg();
        }
     
        
        
    }
}