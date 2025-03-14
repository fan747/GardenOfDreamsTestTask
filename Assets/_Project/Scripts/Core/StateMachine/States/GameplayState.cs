using Assets._Project.Scripts.Base.BaseStateMachine;
using Assets._Project.Scripts.Core.Constants;
using Assets._Project.Scripts.Gameplay;
using Assets._Project.Scripts.Gameplay.Building.Configs;
using Assets._Project.Scripts.Gameplay.StateMachine;
using Assets._Project.Scripts.Gameplay.StateMachine.States;
using UnityEngine;
using UnityEngine.Events;

namespace Assets._Project.Scripts.Core.StateMachine.States
{
    public class GameplayState : State
    {
        private UIRootView _uiRootView;
        private UnityEvent<BuildingConfig> _onSelectItem = new();
        private GameplayStateMachine _gameplayStateMachine;
        private InputControls _inputControls;

        public GameplayState(IStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            _inputControls = ServiceLocator.ServiceLocator.Current.Get<InputControls>();
            _uiRootView = ServiceLocator.ServiceLocator.Current.Get<UIRootView>();

            var mousePositionAction = _inputControls.Gameplay.CursorPosition;
            var mouseClickAction = _inputControls.Gameplay.Click;

            LoadItemsIntoUI();

            _gameplayStateMachine = new GameplayStateMachine(_onSelectItem, mousePositionAction, mouseClickAction);

            _uiRootView.OnPlaceEvent.AddListener(OnPlace);
            _uiRootView.OnReplaceEvent.AddListener(OnReplace);
        }

        public void OnReplace()
        {
            _gameplayStateMachine.SetState<ReplaceState>();
        }

        public void OnPlace()
        {
            _gameplayStateMachine.SetState<PlaceState>();
        }

        private void LoadItemsIntoUI()
        {
            BuildingsConfig buildingsConfig = Resources.Load<BuildingsConfig>(ResourcePath.ItemsConfig);

            foreach (var item in buildingsConfig.Items)
            {
                var uiItem = _uiRootView.LoadItem(buildingsConfig.ItemIconPrefab);

                if (uiItem != null)
                {
                    if (uiItem.TryGetComponent<ItemIcon>(out ItemIcon itemIcon))
                    {
                        itemIcon.Construct(item, _onSelectItem);
                        continue;
                    }

                    Debug.LogError($"{uiItem} dont have ItemIcon component");
                }
            }

            _uiRootView.ShowGameplayMenu();
        }

        public override void Exit()
        {
            Resources.UnloadUnusedAssets();
            _onSelectItem.RemoveAllListeners();
            _gameplayStateMachine.SetState<SaveGameplayState>();
        }
    }
}
