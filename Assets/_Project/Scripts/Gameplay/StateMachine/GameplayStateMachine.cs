using Assets._Project.Scripts.Gameplay.Building.Configs;
using Assets._Project.Scripts.Gameplay.ItemGrid;
using Assets._Project.Scripts.Gameplay.StateMachine.States;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets._Project.Scripts.Gameplay.StateMachine
{
    public class GameplayStateMachine : Base.BaseStateMachine.StateMachine
    {
        private readonly UnityEvent<BuildingConfig> _onSelectItemEvent;
        private readonly BuildingsConfig _buildingsConfig;
        private readonly PlacementController _placementController;
        private readonly SaveSystem.SaveSystem _saveSystem;

        public GameplayStateMachine(UnityEvent<BuildingConfig> onSelectItemEvent, InputAction mousePositionAction, InputAction mouseClickAction)
        {
            _onSelectItemEvent = onSelectItemEvent;
            //Ищем PlacementController для прокидки зависиостей + для управления из стейтов
            _placementController = GameObject.FindFirstObjectByType<PlacementController>();
            _saveSystem = new();

            BuildingGridData buildingGridData = new BuildingGridData(_saveSystem.LoadGame());
            BuildingGrid buildingGrid = new BuildingGrid(buildingGridData);

            AddState<BootstrapGameplayState>(new BootstrapGameplayState(this, _onSelectItemEvent, mousePositionAction, _placementController, buildingGrid));
            AddState<PlaceState>(new PlaceState(this, _placementController, mouseClickAction));
            AddState<ReplaceState>(new ReplaceState(this, _placementController, mouseClickAction));
            AddState<SaveGameplayState>(new SaveGameplayState(this, _saveSystem, buildingGridData, _onSelectItemEvent));

            SetState<BootstrapGameplayState>();
        }
    }
}
