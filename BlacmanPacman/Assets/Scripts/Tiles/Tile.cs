using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Tile : MonoBehaviour
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
        PLAYER,
        ENEMY,
        BACKGROUND,
        BLOCK,
        CHERRY,
        FOODTILE,
        GATETILE
    }

    private Grid2<Tile> m_Grid;
    private int x, y;
    private TileMovementType m_TileMovementType;
    private TilemapSprite m_TileSprite1,m_TileSprite2;
    

    public Tile(Grid2<Tile> _grid, int _x, int _y)
    {
        m_Grid = _grid;
        x = _x;
        y = _y;

        m_TileSprite1 = TilemapSprite.NONE;
        m_TileSprite2 = TilemapSprite.NONE;
        m_TileMovementType = TileMovementType.NONE;

    }

    public void SetTileOne(Vector3 pos)
    {
        if ( m_TileSprite1 == TilemapSprite.BACKGROUND)
        {
            return;
        }

        m_TileMovementType = TileMovementType.WALKABLE;
        m_TileSprite1 = TilemapSprite.BACKGROUND;
        //m_TileSprite2 = TilemapSprite.NONE;
        m_Grid.SetGridObject(pos, this);
    }
    
    public void SetTileTwo(Vector3 pos, TilemapSprite _sprite, TileMovementType _movementType)
    {
        if (m_TileMovementType == _movementType && m_TileSprite2 == _sprite || _sprite == TilemapSprite.BACKGROUND)
        {
            return;
        }
        if (m_TileMovementType == _movementType && m_TileSprite2 != _sprite)
        {
            m_TileSprite2 = _sprite;
        }else if (m_TileMovementType != _movementType && m_TileSprite2 == _sprite)
        {
            m_TileMovementType = _movementType;
        }
        else
        {
            m_TileMovementType = _movementType;
            m_TileSprite2 = _sprite;
        }
        
        m_Grid.SetGridObject(pos, this);
    }

    public void RemoveTile(Vector3 pos)
    {
        if (m_TileSprite1 == TilemapSprite.NONE && m_TileMovementType == TileMovementType.NONE)
        {
            Debug.Log("Nothing here broooo");
            return;
        }
        if (m_TileSprite2 != TilemapSprite.NONE)
        {
            m_TileSprite2 = TilemapSprite.NONE;
        }
        else
        {
            m_TileSprite1 = TilemapSprite.NONE;
            m_TileMovementType = TileMovementType.NONE;
        }
        
        
        m_Grid.SetGridObject(pos, this);
    }

    public TilemapSprite GetTileSpriteOne()
    {
        return m_TileSprite1;
    }
    public TilemapSprite GetTileSpriteTwo()
    {
        return m_TileSprite2;
    }
    public TileMovementType GetTileMovementType()
    {
        return m_TileMovementType;
    }

    public Vector3 TilePosition()
    {
        Vector3 pos = m_Grid.GetWorldPosition(x, y);
        pos = pos = new Vector3(pos.x + m_Grid.GetCellSize() , pos.y + m_Grid.GetCellSize());
        return pos;
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
