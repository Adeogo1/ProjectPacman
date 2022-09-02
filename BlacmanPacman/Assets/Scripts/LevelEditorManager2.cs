using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelEditorManager2 : MonoBehaviour
{
    
    public int m_Rows, m_Col;
    public float m_TileSize = 1;
    public Grid2<Tile> m_Grid;
    public Grid m_Grid2;
    public TilemapVisual m_TilemapVisual;
    public Tile.TilemapSprite m_ActiveTile;
    private Dictionary<Tile.TilemapSprite, Tile.TileMovementType> m_TileTypesDic = new Dictionary<Tile.TilemapSprite, Tile.TileMovementType>();
    private Vector3 m_PlayerStartPos;
    private int m_PlayerCount;
    private List<Vector3> m_EnemyStartPos = new List<Vector3>();

    public GameObject m_TilePrefab;
    void Start()
    {
        //GenerateGrid2();
        GenerateGrid();
    }

    private void OnEnable() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        m_Grid.GetXY(pos, out var x, out var y);
        
        Tile tileAtPos = m_Grid.GetGridObject(pos);
        
        if (Input.GetMouseButtonDown(0))
        {
            if (tileAtPos != null)
            {
                if (tileAtPos.GetTileSpriteOne() == Tile.TilemapSprite.NONE)
                {
                    tileAtPos.SetTileOne(pos);
                }else if (m_ActiveTile == Tile.TilemapSprite.PLAYER && m_PlayerCount < 1)
                {
                    m_PlayerStartPos = m_Grid.GetWorldPosition(x, y);
                    tileAtPos.SetTileTwo(pos,m_ActiveTile, m_TileTypesDic[m_ActiveTile]);
                }else if (m_ActiveTile == Tile.TilemapSprite.ENEMY)
                {
                    m_EnemyStartPos.Add( m_Grid.GetWorldPosition(x, y));
                    tileAtPos.SetTileTwo(pos,m_ActiveTile, m_TileTypesDic[m_ActiveTile]);
                }
                else
                {
                    pos = new Vector3(pos.x + m_TileSize / 2, pos.y + m_TileSize / 2);
                     tileAtPos.SetTileTwo(pos,m_ActiveTile, m_TileTypesDic[m_ActiveTile]);
                    m_TilemapVisual.AddIleVisual(tileAtPos);
                }
            }
        }
        else if(Input.GetMouseButtonDown(1))
        {
            if (tileAtPos.GetTileSpriteTwo() == Tile.TilemapSprite.PLAYER)
            {
                m_PlayerStartPos = Vector3.positiveInfinity;
            }

            else if (tileAtPos.GetTileSpriteTwo() == Tile.TilemapSprite.ENEMY)
            {
                m_EnemyStartPos.Remove(m_Grid.GetWorldPosition(x, y)); 
            } 
            tileAtPos?.RemoveTile(pos);
        }
    }

    void GenerateGrid()
    {
        m_Grid = new Grid2<Tile>(m_Col, m_Rows, m_TileSize, Vector3.zero, (Grid2<Tile>g, int x, int y) => new Tile(g,x,y));
        m_PlayerCount = 0;
        m_TilemapVisual.InitGrid(m_Grid);
        ChangeActiveTile(Tile.TilemapSprite.NONE);
        m_TileTypesDic.Add(Tile.TilemapSprite.NONE,Tile.TileMovementType.NONE);
        m_TileTypesDic.Add(Tile.TilemapSprite.BLOCK,Tile.TileMovementType.NONWALKABLE);
        m_TileTypesDic.Add(Tile.TilemapSprite.GATETILE,Tile.TileMovementType.NONWALKABLE);
        m_TileTypesDic.Add(Tile.TilemapSprite.BACKGROUND,Tile.TileMovementType.WALKABLE);

    }

    void GenerateGrid2()
    {
        m_Grid2 = new Grid(m_Col, m_Rows, m_TileSize, transform.position);
        for (int row = 0; row < m_Grid2.m_gridArray.GetLength(0); row++)
        {
            for (int col = 0; col < m_Grid2.m_gridArray.GetLength(1); col++)
            {
                //Gizmos.DrawWireCube(m_Grid.GetWorldPosition(row,col), Vector3.one * m_SquareSize); 
                var spawnedTile = Instantiate(m_TilePrefab, transform);
                //spawnedTile.Init(false);
                spawnedTile.transform.position = m_Grid2.GetWorldPosition(row, col);
                spawnedTile.transform.localScale *= m_TileSize;

            }
        }
    }
    
    
    
    public void ChangeActiveTile(Tile.TilemapSprite _newActiveTile)
    {
        m_ActiveTile = _newActiveTile;
    }

    public void ChangeTileInGridVisual()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
