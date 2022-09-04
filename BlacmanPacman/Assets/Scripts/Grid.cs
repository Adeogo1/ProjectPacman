using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Grid : MonoBehaviour
{
    public GameObject[] m_TileSprite;
    public Dictionary<TileSprite, Sprite> m_TileSpriteDictionary = new Dictionary<TileSprite, Sprite>();
    private Cell _mCell;
    private int m_Width, m_Height;
    private float m_CellSize;
    private Cell[,] m_gridArray;
    private Vector3 m_PlayerPos;
    private List<Vector3> m_EnemyPos;
    public Sprite sprite;
    

    public void GenerateGrid(int _rows, int _columns, float _cellSize, GameObject _EmptyTile, Cell cell)
    {
        m_Width = _columns;
        m_Height = _rows;
        m_CellSize = _cellSize;
        m_gridArray = new Cell[m_Width, m_Height];
        _mCell = cell; 
        for (int row = 0; row < m_gridArray.GetLength(0); row++)
        {
            for (int col = 0; col < m_gridArray.GetLength(1); col++)
            {
                m_gridArray[row, col] = _mCell.InitTile(this, row, col, _EmptyTile, m_CellSize);
                //Gizmos.DrawWireCube(GetWorldPosition(row,col), Vector3.one * m_CellSize);
            }
        }
        float gridWidth = m_Width * m_CellSize; 
        float gridHeight = m_Height * m_CellSize;
        transform.position = new Vector2(-gridWidth / 2 + m_CellSize/2, gridHeight / 2 - m_CellSize/2);
        SetUpSpritesDictionary();
    }

    

    void SetUpSpritesDictionary()
    {
        for (int i = 0; i < m_TileSprite.Length; i++)
        {
            m_TileSpriteDictionary.Add((TileSprite)i, m_TileSprite[i].GetComponent<SpriteRenderer>().sprite);
        }

        print(m_TileSpriteDictionary.Count);
    }

    public Sprite GetTileSprite(TileSprite _tileSprite)
    {
        
        sprite = m_TileSprite[2].GetComponent<SpriteRenderer>().sprite;
        return m_TileSpriteDictionary[_tileSprite];
    }

    public void ClearGrid()
    {
        for (int row = 0; row < m_gridArray.GetLength(0); row++)
        {
            for (int col = 0; col < m_gridArray.GetLength(1); col++)
            {
                m_gridArray[row,col].RemoveTile();
                m_gridArray[row,col].RemoveTile();
            }
        }
        
    }
    
    public void SetupGrid()
    {
        
    }
    
    public Cell GetGridObject(int x, int y)
    {
        if (x >=0 && y >= 0 && x < m_Width && y < m_Height)
        {
            return m_gridArray[x, y];
        }
        return null;
    }

    public void SetPlayerPos(Vector3 _playerPos)
    {
        m_PlayerPos = _playerPos;
    }

    public void AddEnemyPos(Vector3 _EnemyPos)
    {
        m_EnemyPos.Add(_EnemyPos);
    }
    
    public void RemoveEnemyPos(Vector3 _EnemyPos)
    {
        m_EnemyPos.Remove(_EnemyPos);
    }

}