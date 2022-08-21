using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public int m_Rows, m_Col;
    public float m_TileSize = 1;// to manage the spacing between
    public float m_SquareSize = 1;
    public Tile m_TilePrefab;
    
    public Sprite m_BackgroundSprite;

    private Grid m_Grid;
    
    void Start()
    {
        //GenerateGid();
        //GenerateGrid2();
        GenerateGrid3();
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            m_Grid.SetValue(pos,56);
            print(m_Grid.GetValue(pos));
        }
    }
    

    void GenerateGid()
    {
        GameObject tile = new GameObject();
        tile.AddComponent<SpriteRenderer>().sprite = m_BackgroundSprite;
        tile.GetComponent<SpriteRenderer>().color = Color.black;
        tile.transform.localScale *= m_SquareSize;
        for (int row = 0; row < m_Rows; row++)
        {
            for (int col = 0; col < m_Col; col++)
            {
                GameObject newTile = Instantiate(tile, transform);
                float posX = col * m_TileSize;
                float posY = row * -m_TileSize;
                newTile.transform.position = new Vector2(posX, posY);
            }
        }
        Destroy(tile);
        float gridWidth = m_Col * m_TileSize;
        float gridHeight = m_Rows * m_TileSize;
        transform.position = new Vector2(-gridWidth / 2 + m_TileSize/2, gridHeight / 2 - m_TileSize/2);
    }


    void GenerateGrid2()
    {
        Tile spawnedTile;
        for (int row = 0; row < m_Rows; row++)
        {
            for (int col = 0; col < m_Col; col++)
            {
                spawnedTile = Instantiate(m_TilePrefab, transform);
                spawnedTile.Init(false);
                float posX = col * m_TileSize;
                float posY = row * -m_TileSize;
                spawnedTile.transform.position = new Vector3(posX, posY);
                spawnedTile.transform.localScale *= m_SquareSize;
            }
        }

        float gridWidth = m_Col * m_TileSize;
        float gridHeight = m_Rows * m_TileSize;
        transform.position = new Vector2(-gridWidth / 2 + m_SquareSize / 2, gridHeight / 2 - m_TileSize / 2);

    }

    void GenerateGrid3()
    {
        m_Grid = new Grid(m_Col, m_Rows, m_SquareSize, transform.position);
        for (int row = 0; row < m_Grid.m_gridArray.GetLength(0); row++)
        {
            for (int col = 0; col < m_Grid.m_gridArray.GetLength(1); col++)
            {
                //Gizmos.DrawWireCube(m_Grid.GetWorldPosition(row,col), Vector3.one * m_SquareSize); 
                var spawnedTile = Instantiate(m_TilePrefab, transform);
                spawnedTile.Init(false);
                spawnedTile.transform.position = m_Grid.GetWorldPosition(row, col);
                spawnedTile.transform.localScale *= m_SquareSize;
                 
            }
        }
        //m_Grid.CenterGrid();
    }

    private void OnDrawGizmos()
    {
        //GenerateGrid3();

    }
}
