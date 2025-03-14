using Assets._Project.Scripts.Base.BaseStateMachine;
using UnityEngine.InputSystem;

namespace Assets._Project.Scripts.Gameplay.StateMachine.States
{
    public class ReplaceState : State
    {
        private readonly PlacementController _placementController;
        private readonly InputAction _clickAction;

        public ReplaceState(IStateMachine stateMachine, PlacementController placementController, InputAction clickAction) : base(stateMachine)
        {
            _placementController = placementController;
            _clickAction = clickAction;
        }

        private void ClickAction(InputAction.CallbackContext obj)
        {
            _placementController.Replace();
        }


        public override void Enter()
        {
            _placementController.ReplaceInit();
            _clickAction.performed += ClickAction;
        }

        public override void Exit()
        {
            _clickAction.performed -= ClickAction;
        }
    }
}
