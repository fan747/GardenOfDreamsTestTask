using Assets._Project.Scripts.Base.BaseStateMachine;
using UnityEngine.InputSystem;

namespace Assets._Project.Scripts.Gameplay.StateMachine.States
{
    public class PlaceState : State
    {
        private readonly PlacementController _placementController;
        private readonly InputAction _clickAction;

        public PlaceState(IStateMachine stateMachine, PlacementController placementController, InputAction clickAction) : base(stateMachine)
        {
            _placementController = placementController;
            _clickAction = clickAction;
        }

        private void ClickAction(InputAction.CallbackContext obj)
        {
            _placementController.Place();
        }


        public override void Enter()
        {
            _clickAction.performed += ClickAction;
            _placementController.PlaceInit();
        }

        public override void Exit()
        {
            _clickAction.performed -= ClickAction;
        }
    }
}
