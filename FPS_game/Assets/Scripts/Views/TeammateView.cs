using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class TeammateView : BaseSceneObject
    {

        private TeamMateModel _teammate;
        protected override void Awake()
        {
            base.Awake();
            StartCoroutine(Initialize());

        }
        IEnumerator Initialize()
        {
            yield return new WaitWhile(() => Main.Instance == null);
            _teammate = GetComponentInParent<TeamMateModel>();
            TeamMateController.OnTeammateSelected += OnTeammateSelected;
            IsVisible = false;
        }
        private void OnDestroy()
        {
            TeamMateController.OnTeammateSelected -= OnTeammateSelected;
        }
        private void OnTeammateSelected(TeamMateModel teammate)
        {
            IsVisible = teammate == _teammate;
        }
    }
}

