using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace Assets._Project.Scripts.Gameplay
{
    //Рисует сетку строительства
    public class TileMapRenderer : MonoBehaviour
    {
        [SerializeField] private Tilemap _tileMap;
        [SerializeField] private Grid _grid;
        [SerializeField] private List<Tile> _renderTiles;
        [SerializeField] private Vector2Int _tileSize;

        private int _tileIndex = 0;
        private bool _isInverse = false;

        private void Start()
        {
            Render();
        }

        private void Render()
        {
            _tileMap.ClearAllTiles();

            for(int x = -_tileSize.x/2;  x < _tileSize.x/2; x++)
            {
                for (int y = -_tileSize.y / 2; y < _tileSize.y / 2; y++)
                {
                    var tilePos = _grid.WorldToCell(new Vector3(x, y, 0));
                    DrawTile(tilePos);
                }

                _isInverse = !_isInverse;
            }
        }

        private void DrawTile(Vector3Int pos)
        {
            if (_renderTiles.Count == 0 ) return;

            bool isReset = _tileIndex == -1 || _tileIndex > _renderTiles.Count - 1;

            if (!_isInverse)
            {
                if (isReset) _tileIndex = 0;

                _tileMap.SetTile(pos, _renderTiles[_tileIndex]);;
                _tileIndex++;           
                return;
            }

            if (isReset) _tileIndex = _renderTiles.Count - 1;
            _tileMap.SetTile(pos, _renderTiles[_tileIndex]);

            _tileIndex--;
        }

    }
}
