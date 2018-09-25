using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace FPS
{
    public class FlashlightView : MonoBehaviour
    {
        
        private Image _image;
        private FlashlightModel _model;

        private void Awake()
        {
            
            _image = GetComponent<Image>();
            
            _model = FindObjectOfType<FlashlightModel>();
        }
        
        public void BatteryColorChange()
        {
                       
            Debug.Log(1);
        }
        public void Update()
        {
            _image.fillAmount = _model.ButterySize * 0.01f;
            
        }
    }
}