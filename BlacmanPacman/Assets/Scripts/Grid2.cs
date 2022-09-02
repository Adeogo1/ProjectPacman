using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Grid2 <TGridObject> 
{
 private int m_width;
    private int m_height;
    private float m_CellSize;
    public TGridObject[,] m_gridArray;
    public Vector3 m_OriginPosition;

    public Grid2(int _width, int _height, float _cellSize, Vector3 _originPos, Func<Grid2<TGridObject>, int, int, TGridObject>createGridObject)
    {
        m_width = _width;
        m_height = _height;
        m_CellSize = _cellSize;
        m_gridArray = new TGridObject[m_width, m_height];
        float gridWidth = m_width * m_CellSize;
        float gridHeight = m_height * m_CellSize;
        m_OriginPosition = new Vector3((_originPos.x - gridWidth/2) + _cellSize/2, (_originPos.y - gridHeight/2) +_cellSize/2);
        //m_OriginPosition = new Vector3(m_OriginPosition.x - m_CellSize / 2, m_OriginPosition.y - m_CellSize / 2);
        //m_OriginPosition = _originPos;
        
       
        for (int row = 0; row < m_gridArray.GetLength(0); row++)
        {
            for (int col = 0; col < m_gridArray.GetLength(1); col++)
            {
                m_gridArray[row, col] = createGridObject(this, row, col);
                Debug.Log(GetGridObject(row,col));
                Debug.DrawLine(GetWorldPosition(row,col), GetWorldPosition(row,col + 1), Color.white,100);
                Debug.DrawLine(GetWorldPosition(row,col), GetWorldPosition(row + 1,col), Color.white,100);

            }
        }
        
        Debug.DrawLine(GetWorldPosition(0,m_height), GetWorldPosition(m_width,m_height), Color.white,100);
       Debug.DrawLine(GetWorldPosition(m_width,0), GetWorldPosition(m_width,m_height), Color.white,100);

        
    }

    public Vector3 GetWorldPosition(int x, int y)
    {
        Vector3 pos = new Vector3(x, y) * m_CellSize + m_OriginPosition;
        //pos = new Vector3(pos.x - m_CellSize / 2, pos.y - m_CellSize / 2);
        return pos;
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
    public void SetGridObject(int x, int y, TGridObject value)
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

    public void SetGridObject(Vector3 _worldPosition, TGridObject value)
    {
        int x, y;
        GetXY(_worldPosition, out x, out y);
        SetGridObject(x,y,value);
    }

    public TGridObject GetGridObject(int x, int y)
    {
        
        if (x >=0 && y >= 0 && x < m_width && y < m_height)
        {
            return m_gridArray[x, y];
        }

        return default(TGridObject);
        
        
    }
    public TGridObject GetGridObject(Vector3 worldPos)
    {
        int x, y;
        GetXY(worldPos,out x, out y);
        return GetGridObject(x, y);
    }

    public float GetCellSize()
    {
        return m_CellSize;
    }

    public int GridObjectAmount()
    {
        return m_width * m_height;
    }
}
