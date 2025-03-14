using Assets._Project.Scripts.Core.StateMachine;
using Assets._Project.Scripts.Core.StateMachine.States;
using UnityEngine;

namespace Assets._Project.Scripts.Core
{
    public class UtilBehavior : MonoBehaviour
    {
        private GameStateMachine _stateMachine;

        public void Construct(GameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public void Update()
        {
            if (_stateMachine != null)
            {
                _stateMachine.Update();
            }
        }

        public void OnDestroy()
        {
            _stateMachine.SetState<ExitState>();
        }
    }
}