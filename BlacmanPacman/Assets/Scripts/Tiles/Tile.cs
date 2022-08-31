using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile 
{
    public enum TileMovementType
    {
        NONE,
        WALKABLE,
        NONWALKABLE
    }
    public enum TilemapSprite
    {
        NONE, 
        BACKGROUND,
        BLOCK,
        CHERRY,
        FOODTILE,
        GATETILE
    }

    private Grid2<Tile> m_Grid;
    private int x, y;
    protected TileMovementType m_TileMovementType;
    protected TilemapSprite m_TileSprite;
    

    public Tile(Grid2<Tile> _grid, int _x, int _y)
    {
        m_Grid = _grid;
        x = _x;
        y = _y;

        m_TileSprite = TilemapSprite.NONE;
        m_TileMovementType = TileMovementType.NONE;

    }

    public void SetTile(Vector3 pos, TileMovementType _movementType, TilemapSprite _sprite)
    {
        if (m_TileMovementType == _movementType && m_TileSprite == _sprite)
        {
            return;
        }

        m_TileMovementType = _movementType;
        m_TileSprite = _sprite;
        m_Grid.SetGridObject(pos, this);
    }

    public TilemapSprite GetTileSprite()
    {
        return m_TileSprite;
    }
    public TileMovementType GetTileMovementType()
    {
        return m_TileMovementType;
    }
    
    private void OnMouseEnter()
    {
        if (GameManager.m_GameState == GameState.LEVELEDITOR)
        {
            //m_Highlight.SetActive(true);
        }
        
    }

    private void OnMouseExit()
    {
        if (GameManager.m_GameState == GameState.LEVELEDITOR)
        {
            //m_Highlight.SetActive(false);
        }
        
    }
}
