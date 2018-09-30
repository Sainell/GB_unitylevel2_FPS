using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPS
{
    public class InputController : BaseController
    {
        private void Update()
        {
            if (Input.GetButtonDown("SwitchFlashlight"))
                Main.Instance.FlashlightController.Switch();

            if (Input.GetAxis("Mouse ScrollWheel")!=0f)
                Main.Instance.WeaponController.ChangeWeapon(Input.GetAxis("Mouse ScrollWheel"));

            if (Input.GetButton("Fire1"))
                Main.Instance.WeaponController.Fire();
            if (Input.GetButton("TeammateCommand"))
                Main.Instance.TeamMateController.MoveCommand();

        }
    }

}