using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class Target : BaseSceneObject
    {
        private void del()
        {
            Destroy(this, 2f);
        }

    }
}
