using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilemapVisual : MonoBehaviour
{
    private Grid2<Tile> m_Grid;
    public ObjectPool[] m_TilePools;
    public GameObject[] m_TilePrefabs;
    //private Dictionary<GameObject, int> 
    
    // {
    //     None - 0
    //     Background - 1
    //     Block - 2
    //     Cherry - 3
    //     Enemy - 4
    //     Food - 5
    //     Gate - 6
    // }
    

    private void Awake()
    {
        
    }
    

    public void InitGrid(Grid2<Tile> _grid)
    {
        m_Grid = _grid;
        InitPools();
    }

    public void AddIleVisual(Tile _tile)
    {
        
        switch (_tile.GetTileSpriteTwo())
        {
            case Tile.TilemapSprite.NONE:
                break;
            case Tile.TilemapSprite.BLOCK:
                GameObject BlockObj = m_TilePools[2].GetPooledObject();
                BlockObj.SetActive(true);
                BlockObj.transform.position = _tile.TilePosition();
                break;
            case Tile.TilemapSprite.ENEMY:
                GameObject EnemyObj = m_TilePools[4].GetPooledObject();
                EnemyObj.SetActive(true);
                EnemyObj.transform.position = _tile.TilePosition();
                break;
            case Tile.TilemapSprite.CHERRY:
                GameObject CherryObj = m_TilePools[3].GetPooledObject();
                CherryObj.SetActive(true);
                CherryObj.transform.position = _tile.TilePosition();
                break;
            case Tile.TilemapSprite.PLAYER:
                break;
            case Tile.TilemapSprite.FOODTILE:
                GameObject FoodObj = m_TilePools[5].GetPooledObject();
                FoodObj.SetActive(true);
                FoodObj.transform.position = _tile.TilePosition();
                break;
            case Tile.TilemapSprite.GATETILE:
                GameObject GateObj = m_TilePools[6].GetPooledObject();
                GateObj.SetActive(true);
                GateObj.transform.position = _tile.TilePosition();
                break;
        }
    }

    private void LateUpdate()
    {
        
    }

    void InitPools()
    {
        for (int i = 0; i < m_TilePools.Length; i++)
        {
            m_TilePools[i].m_ObjectToPool = m_TilePrefabs[i];
            m_TilePools[i].m_PooledAmount = m_Grid.GridObjectAmount() / 2;
            m_TilePools[i].InitPool();
        }
    }
}
