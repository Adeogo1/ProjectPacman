using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private int m_width;
    private int m_height;
    private float m_CellSize;
    public int[,] m_gridArray;
    public Vector3 m_OriginPosition;

    public Grid(int _width, int _height, float _cellSize, Vector3 _originPos)
    {
        m_width = _width;
        m_height = _height;
        m_CellSize = _cellSize;
        m_gridArray = new int[m_width, m_height];
        float gridWidth = m_width * m_CellSize;
        float gridHeight = m_height * m_CellSize;
        m_OriginPosition = new Vector3((_originPos.x - gridWidth/2) + _cellSize/2, (_originPos.y - gridHeight/2) +_cellSize/2);
        //m_OriginPosition = _originPos;
        for (int row = 0; row < m_gridArray.GetLength(0); row++)
        {
            for (int col = 0; col < m_gridArray.GetLength(1); col++)
            {
                Debug.DrawLine(GetWorldPosition(row,col), GetWorldPosition(row,col + 1), Color.white,100);
                Debug.DrawLine(GetWorldPosition(row,col), GetWorldPosition(row + 1,col), Color.white,100);
            }
        }
        Debug.DrawLine(GetWorldPosition(0,m_height), GetWorldPosition(m_width,m_height), Color.white,100);
        Debug.DrawLine(GetWorldPosition(m_width,0), GetWorldPosition(m_width,m_height), Color.white,100);

        
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x, y) * m_CellSize + m_OriginPosition;
    }

    public void GetXY(Vector3 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt((worldPos-m_OriginPosition).x / m_CellSize);// with the cellsize of 10 the world position 5 wont be on grid 0
                                                      // and a world position of 15 wont be on grid 1
        y = Mathf.FloorToInt((worldPos-m_OriginPosition).y / m_CellSize);                                              
    }

    public float GetGridXExtent()
    {
        float gridWidth = m_width * m_CellSize;
        return gridWidth / 2;
    }
    public float GetGridYExtent()
    {
        float gridHeight = m_height * m_CellSize;
        return gridHeight / 2;
    }

    public Vector3 GetOriginPos()
    {
        return m_OriginPosition;
    }
    
    //functions too modify the grid
    public void SetValue(int x, int y, int value)
    {
        //how we should deal with invalid values like negative numbers
        //we can throw error, correct it to the closest value or ignore it
        //the best option is to ignore it
        
        if (x <0 && y < 0 && x > m_width && y > m_height)
        {
            return;
        }
        m_gridArray[x, y] = value;
    }

    public void SetValue(Vector3 _worldPosition, int value)
    {
        int x, y;
        GetXY(_worldPosition, out x, out y);
        SetValue(x,y,value);
    }

    public int GetValue(int x, int y)
    {
        
        if (x >=0 && y >= 0 && x < m_width && y < m_height)
        {
            return m_gridArray[x, y];
        }
        else
        {
            return default(int);
        }
        
    }
    public int GetValue(Vector3 worldPos)
    {
        int x, y;
        GetXY(worldPos,out x, out y);
        return GetValue(x, y);
    }
    
}
