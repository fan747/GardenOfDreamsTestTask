using Assets._Project.Scripts.Gameplay.Building.Configs;
using Assets._Project.Scripts.Gameplay.ItemGrid;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using Quaternion = UnityEngine.Quaternion;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

namespace Assets._Project.Scripts.Gameplay
{
    public class PlacementController : MonoBehaviour
    {
        [SerializeField] private Grid _grid;

        private GameObject _cursor;
        private BuildingConfig _currentBuildingConfig;
        private UnityEvent<BuildingConfig> _switchCursorEvent;
        private Vector3 _mousePosition;
        private Vector3Int _cellPosition;
        private InputAction _mousePositionAction;
        private bool _isCanInteraction;
        private bool _isPlacing;
        private bool _isCanJob;
        private BuildingGrid _buildingGrid;

        //Грузим позицию мышки и компонент управления сеткой
        public void Construct(InputAction mousePositionAction, BuildingGrid buildingGrid)
        {
            _mousePositionAction = mousePositionAction;
            _buildingGrid = buildingGrid;

            _isCanJob = true;
        }

        private void Update()
        {
            if(!_isCanJob) return;

            _isCanInteraction = !EventSystem.current.IsPointerOverGameObject(0);

            _mousePosition = new Vector3(MouseWorldPosition().x, MouseWorldPosition().y);
            _cellPosition = _grid.WorldToCell(_mousePosition);

            if (_isPlacing && _cursor != null && _isCanInteraction)
                _cursor.transform.position = new Vector3(_cellPosition.x, _cellPosition.y, _cursor.transform.position.z) + new Vector3( _currentBuildingConfig.ItemSize.x, _currentBuildingConfig.ItemSize.y) / 2;
        }

        private void CreateCursor()
        {
            if (_currentBuildingConfig != null)
            {
                _cursor = Instantiate(_currentBuildingConfig.Prefab, Vector3.zero, Quaternion.identity);
                var spriteRenderer = _cursor.GetComponent<SpriteRenderer>();
                spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b,
                    0.5f);
            }
        }

        private void DestroyCursor()
        {
            if (_cursor != null)
                Destroy(_cursor);
        }

        public Vector3 MouseWorldPosition()
        {
            return Camera.main.ScreenToWorldPoint(_mousePositionAction.ReadValue<Vector2>());
        }


        public void OnItemSelect(BuildingConfig buildingConfig)    
        {
            if(buildingConfig.Prefab == null) return;

            DestroyCursor();

            _currentBuildingConfig = buildingConfig;

            CreateCursor();
        }


        public void PlaceInit()
        {
            _isPlacing = true;

            DestroyCursor();
            CreateCursor();
        }

        public void ReplaceInit()
        {
            _isPlacing = false;

            DestroyCursor();
        }

        public void Place()
        {
            if (!_isCanInteraction) return;
            _buildingGrid.Place(_currentBuildingConfig.Prefab, _currentBuildingConfig.Data, _cellPosition);
        }

        public void Replace()
        {
            if (!_isCanInteraction) return;
            _buildingGrid.Replace(_cellPosition);
        }
    }
}
