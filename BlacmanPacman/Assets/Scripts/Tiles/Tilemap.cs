using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tilemap
{

    public Grid2<TilemapObject> m_Grid;

    public Tilemap(int _width, int _height, float _cellSize, Vector3 _originPosition)
    {
        //m_Grid = new Grid2<TilemapObject>(_width, _height, _cellSize, _originPosition, (Grid2<TilemapObject>g,int x, int y) => new TilemapObject(g,x,y));
    }

    public void SetTilemapSprite(Vector3 worldposition, TilemapObject.TilemapSprite tilemapSprite)
    {
        TilemapObject tilemapObject = m_Grid.GetGridObject(worldposition);
        if (tilemapObject != null) 
        {
            tilemapObject.SetTilemapSprite(tilemapSprite);
        }
    }

    public class TilemapObject
    {
        public enum TilemapSprite
        {
            BACKGROUND,
            BLOCK,
            CHERRY,
            ENEMY,
            FOODTILE,
            GATETILE
        }

        private TilemapSprite m_TilemapSprite;
        private Grid2<TilemapObject> m_Grid;
        private int x, y;

        public TilemapObject(Grid2<TilemapObject> _grid, int _x, int _y)
        {
            m_Grid = _grid;
            x = _x;
            y = _y;
        }

        public TilemapSprite GetTilemapSprite()
        {
            return m_TilemapSprite;
        }

        public void SetTilemapSprite(TilemapSprite _tilemapSprite)
        {
            m_TilemapSprite = _tilemapSprite;
            
        }
    }
    
}
