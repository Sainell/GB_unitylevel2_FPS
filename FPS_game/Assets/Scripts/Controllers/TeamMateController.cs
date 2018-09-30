using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
namespace FPS {
    public class TeamMateController : BaseController
    {
        public static UnityAction<TeamMateModel> OnTeammateSelected;
        private TeamMateModel _currentTeammate;
        [SerializeField]
        private BaseSceneObject _target;
        private Transform _pos;
        public void SelectTeamMate(TeamMateModel teammate)
        {
            _currentTeammate = teammate;
            if (OnTeammateSelected != null)
                OnTeammateSelected(teammate);
        }
            public void MoveCommand()
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            if (Physics.Raycast(ray,out hit)) 
            {
                TeamMateModel teammate = hit.collider.GetComponent<TeamMateModel>();
                

                if (teammate)
                    SelectTeamMate(teammate);
                else if (_currentTeammate)
                    _currentTeammate.SetTarget(hit.point);
                _pos = hit.transform;
                Instantiate(_target,_pos.position,_pos.rotation); // что-то не хочет

            }
        }
        

    }	
	
}
