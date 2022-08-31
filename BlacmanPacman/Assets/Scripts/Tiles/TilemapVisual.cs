using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class TilemapVisual : MonoBehaviour
{
    private Grid2<Tile> m_Grid;
    public GameObject[] m_TilePrefabs;
    private bool m_updateMesh;

    private void Awake()
    {
        
    }
    

    public void SetGrid(Grid2<Tile> _grid)
    {
        m_Grid = _grid;
    }

    public void SetIleVisual(Tile _tile, Vector3 pos)
    {
        switch (_tile.GetTileSprite())
        {
            case Tile.TilemapSprite.BACKGROUND:
                if (_tile.GetTileSprite() == Tile.TilemapSprite.BACKGROUND)
                {
                    return;
                }
                Instantiate(m_TilePrefabs[0], pos, Quaternion.identity);
            break;
        }
    }

    private void LateUpdate()
    {
        
    }
}
