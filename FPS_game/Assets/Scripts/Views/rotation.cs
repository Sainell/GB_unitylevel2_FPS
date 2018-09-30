using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class rotation : BaseSceneObject
    {
        

        // Update is called once per frame
        void Update()
        {
            gameObject.transform.Rotate(0, 2, 0);
        }
    }
}
