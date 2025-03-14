using Assets._Project.Scripts.Base.BaseStateMachine;
using Assets._Project.Scripts.Gameplay.Building.Configs;
using Assets._Project.Scripts.Gameplay.ItemGrid;
using UnityEngine.Events;

namespace Assets._Project.Scripts.Gameplay.StateMachine.States
{
    public class SaveGameplayState : State
    {
        private readonly SaveSystem.SaveSystem _saveSystem;
        private readonly BuildingGridData _buildingGridData;
        private readonly UnityEvent<BuildingConfig> _onSelectItem;

        public SaveGameplayState(IStateMachine stateMachine, SaveSystem.SaveSystem saveSystem, BuildingGridData buildingGridData,
            UnityEvent<BuildingConfig> onSelectItem) : base(stateMachine)
        {
            _saveSystem = saveSystem;
            _buildingGridData = buildingGridData;
            _onSelectItem = onSelectItem;
        }

        public override void Enter()
        {
            _saveSystem.SaveGame(_buildingGridData.ItemPlaceDatas);
            _onSelectItem.RemoveAllListeners();
        }

        public override void Exit()
        {
            
        }
    }
}
