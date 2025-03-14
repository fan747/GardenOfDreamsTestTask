using Assets._Project.Scripts.Gameplay.Building.Configs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets._Project.Scripts.Gameplay
{
    public class ItemIcon : MonoBehaviour
    {
        [SerializeField] private RawImage _iconImage;
        [SerializeField] private Color _selectColor;

        private Color _startColor;
        private ColorBlock _buttonColorBlock;
        private BuildingConfig _buildingConfig;
        private UnityEvent<BuildingConfig> _onSelectEvent;

        //Грузим в него конфиг, при клике высылаем его из GameplayState вниз до PlacementController
        public void Construct(BuildingConfig buildingConfig, UnityEvent<BuildingConfig> onSelectEvent)
        {
            _buildingConfig = buildingConfig;
            _onSelectEvent = onSelectEvent;

            if(_buildingConfig.Icon  != null) 
                _iconImage.texture = _buildingConfig.Icon.texture;

            _startColor = _iconImage.color;

            _onSelectEvent.AddListener(OnDeselect);
        }

        public void OnClick()
        {
            _onSelectEvent?.Invoke(_buildingConfig);
            ChangeImageColor(_selectColor);
        }

        public void OnDeselect(BuildingConfig prefabGameObject)
        {
            ChangeImageColor(_startColor);
        }

        private void ChangeImageColor(Color color)
        {
            _iconImage.color = color;
        }

    }
}
