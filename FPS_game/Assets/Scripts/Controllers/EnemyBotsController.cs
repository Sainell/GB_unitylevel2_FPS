using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace FPS
{
    public class EnemyBotsController : BaseController
    {

        private List<EnemyBot> _botList = new List<EnemyBot>();
        private Transform _targetTransform;

        private void Start()
        {
            _targetTransform = PlayerModel.LocalPlayer.transform;
            foreach(var bot in FindObjectsOfType<EnemyBot>())
            {
                AddBot(bot);
            }
  
        }

        public void AddBot(EnemyBot bot)
        {
            if (_botList.Contains(bot))
                return;
            _botList.Add(bot);
            bot.SetTarget(_targetTransform);
        }
        public void RemoveBot(EnemyBot bot)
        {
            if (!_botList.Contains(bot))
                return;
            _botList.Remove(bot);
        }

    }
}