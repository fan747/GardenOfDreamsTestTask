using System.Collections;
using Assets._Project.Scripts.Base.BaseStateMachine;
using Assets._Project.Scripts.Core.Constants;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets._Project.Scripts.Core.StateMachine.States
{
    public class BootstrapState : State
    {
        private readonly GameStateMachine _stateMachine;
        private UIRootView _UIRootView;
        private UtilBehavior _utilBehavior;
        private InputControls _inputControls;

        public BootstrapState(GameStateMachine stateMachine) : base(stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public override void Enter()
        {
            _utilBehavior = new GameObject("[UtilBehavior]").AddComponent<UtilBehavior>();
            GameObject.DontDestroyOnLoad(_utilBehavior.gameObject);

            _utilBehavior.Construct(_stateMachine);

            var uiRootViewPrefab = Resources.Load(ResourcePath.UIRootView);
            GameObject uiRootViewObject = (GameObject)GameObject.Instantiate(uiRootViewPrefab, Vector3.zero, Quaternion.identity);
           
            _UIRootView = uiRootViewObject.GetComponent<UIRootView>();
            GameObject.DontDestroyOnLoad(_UIRootView.gameObject);

            _inputControls = new();
            _inputControls.Enable();

            ServiceLocator.ServiceLocator.Initialize();
            ServiceLocator.ServiceLocator.Current.Register<InputControls>(_inputControls);
            ServiceLocator.ServiceLocator.Current.Register<UtilBehavior>(_utilBehavior);
            ServiceLocator.ServiceLocator.Current.Register<UIRootView>(_UIRootView);
            ServiceLocator.ServiceLocator.Current.Register<GameStateMachine>(_stateMachine);

            RunGame();
        }

        public override void Exit()
        {
            Resources.UnloadUnusedAssets();
        }

        private void RunGame()
        {

#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;

            if (sceneName == SceneName.Gameplay)
            {
                _utilBehavior.StartCoroutine(StartAndLoadGameplay());
                return;
            }

            if (sceneName != SceneName.Boot)
            {
                return;
            }
#endif
            _utilBehavior.StartCoroutine(StartAndLoadGameplay());
        }

        private IEnumerator StartAndLoadGameplay()
        {
            _UIRootView.ShowLoadingScreen();

            yield return LoadScene(SceneName.Gameplay);
            yield return null;

            _UIRootView.HideLoadingScreen();
            StateMachine.SetState<GameplayState>();
        }

        private IEnumerator LoadScene(string sceneName)
        {
            yield return SceneManager.LoadSceneAsync(SceneName.Boot);
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }

}
