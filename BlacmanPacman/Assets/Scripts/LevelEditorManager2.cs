using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager2 : MonoBehaviour
{
    
    public Grid m_Grid;
    public int m_Rows, m_Col;
    public float m_CellSize = 1;
    public GameObject m_EmptyTile;
    public Cell mCell;
    public Cell mSelectedCell;
    public TileSprite m_ActiveTile;
    private List<Vector3> m_EnemyPos;
    private Vector3 m_PlayerPos;
    public int m_PlayerCount = 0;

    void Start()
    {
        m_Grid.GenerateGrid(m_Rows, m_Col, m_CellSize, m_EmptyTile, mCell);
    }

    private void OnEnable()
    {
        EventManager.TileSelected += SelectedTile;
        EventManager.ChangeActiveTile += ChangeActiveTile;
    }
    
    public void ChangeActiveTile(TileSprite _tileToChange)
    {
        
        m_ActiveTile = _tileToChange;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            print(mSelectedCell.x + " " + mSelectedCell.y);
            RemovingTiles(); 
            AddingTiles();

        }

        if (Input.GetMouseButtonDown(1))
        {
            RemovingTiles();
        }

        
    }

    private void SelectedTile(int x, int y)
    {
        //print(x + " and " + y);
        mSelectedCell = m_Grid.GetGridObject(x, y);
    }

    private void RemovingTiles()
    {
        TileSprite tile1, tile2;
        mSelectedCell.GetTiles(out tile1, out tile2);
        if (tile2 == TileSprite.ENEMY || tile2 == TileSprite.ENEMY2 || tile2 == TileSprite.ENEMY3 ||tile2 == TileSprite.ENEMY4 )
        {
            m_Grid.RemoveEnemyPos(mSelectedCell.GetTilePos());
        }
        else if (tile2 == TileSprite.PLAYER)
        {
            m_PlayerCount--;
            m_Grid.SetPlayerPos(new Vector3(10000,10000));
        }
        mSelectedCell.RemoveTile();
    }

    private void AddingTiles()
    {
        if (!mSelectedCell.MouseOnTile())
        {
            return;
        }
        if (m_ActiveTile == TileSprite.BACKGROUND)
        { 
            mSelectedCell.SetTile(m_ActiveTile, TileTransportType.WALKABLE);
        }else if (m_ActiveTile == TileSprite.ENEMY)
        {
            mSelectedCell.SetTile(m_ActiveTile, TileTransportType.WALKABLE);
            m_Grid.AddEnemyPos(mSelectedCell.GetTilePos());
        }else if (m_ActiveTile == TileSprite.PLAYER && m_PlayerCount <= 0)
        {
            mSelectedCell.SetTile(m_ActiveTile, TileTransportType.WALKABLE);
            m_Grid.SetPlayerPos( mSelectedCell.GetTilePos());
            m_PlayerCount++;
            return;
        }
        else if(m_ActiveTile != TileSprite.PLAYER )
        {
            TileTransportType transportType = m_ActiveTile == TileSprite.BLOCK  ? TileTransportType.NONEWALKABLE : TileTransportType.WALKABLE;
            mSelectedCell.SetTile(m_ActiveTile, transportType);
        }
    }


    private void OnDisable()
    {
        EventManager.TileSelected -= SelectedTile;
        EventManager.ChangeActiveTile -= ChangeActiveTile;
    }
}
