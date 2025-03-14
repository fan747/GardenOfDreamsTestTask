using Assets._Project.Scripts.Base.BaseStateMachine;
using Assets._Project.Scripts.Gameplay.Building.Configs;
using Assets._Project.Scripts.Gameplay.ItemGrid;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets._Project.Scripts.Gameplay.StateMachine.States
{
    public class BootstrapGameplayState : State
    {
        private readonly GameplayStateMachine _stateMachine;
        private readonly UnityEvent<BuildingConfig> _onSelectItemEvent;
        private readonly InputAction _mousePositionAction;
        private PlacementController _placementController;
        private readonly BuildingGrid _buildingGrid;

        public BootstrapGameplayState(GameplayStateMachine stateMachine, UnityEvent<BuildingConfig> onSelectItemEvent, InputAction mousePositionAction, PlacementController placementController, BuildingGrid buildingGrid) : base(stateMachine)
        {
            _stateMachine = stateMachine;
            _onSelectItemEvent = onSelectItemEvent;
            _mousePositionAction = mousePositionAction;
            _placementController = placementController;
            _buildingGrid = buildingGrid;
        }

        public override void Enter()
        {
            _onSelectItemEvent.AddListener(_placementController.OnItemSelect);

            _placementController.Construct(_mousePositionAction, _buildingGrid);
        }

        public override void Exit()
        {
            
        }
    }
}