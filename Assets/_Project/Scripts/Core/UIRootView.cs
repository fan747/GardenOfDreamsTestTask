using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._Project.Scripts.Core
{
    public class UIRootView : MonoBehaviour
    {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private GameObject _gameplayMenu;
        [SerializeField] private Transform _itemsSelectorTransform;
        [SerializeField] private Button _placeButton;
        [SerializeField] private Button _replaceButton;

        public UnityEvent OnPlaceEvent => _placeButton.onClick;
        public UnityEvent OnReplaceEvent => _replaceButton.onClick;


        public void Awake()
        {
            HideLoadingScreen();
            HideGameplayMenu();
        }

        public void ShowLoadingScreen()
        {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen()
        {
            _loadingScreen.SetActive(false);
        }

        public void ShowGameplayMenu()
        {
            _gameplayMenu.SetActive(true);
        }

        public void HideGameplayMenu()
        {
            _gameplayMenu.SetActive(false);
        }

        public GameObject LoadItem(GameObject iconPrefab)
        {
            if (iconPrefab == null)  return null;

            var prefab = iconPrefab;
            var uiItem = GameObject.Instantiate(prefab, _itemsSelectorTransform, false);
            return uiItem;
        }
    }
}