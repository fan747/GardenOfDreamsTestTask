using Assets._Project.Scripts.Core.StateMachine;
using UnityEngine;

namespace Assets._Project.Scripts.Core
{
    public class GameEntryPoint
    {
        private UIRootView _UIRootView;
        private UtilBehavior _utilBehavior;
        private static GameEntryPoint _instance;
        private static GameStateMachine _gameStateMachine;

        private GameEntryPoint()
        {
            _gameStateMachine = new();
        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        public static void AutostartGame()
        {
            _instance = new GameEntryPoint();
        }
    }
}