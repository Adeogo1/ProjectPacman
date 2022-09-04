using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public enum TileTransportType
{
    NONE,
    WALKABLE,
    NONEWALKABLE
}

[Serializable]
public enum TileSprite
{
    NONE,
    BACKGROUND,
    BLOCK,
    ENEMY,
    ENEMY2,
    ENEMY3,
    ENEMY4,
    PLAYER,
    GATE,
    FOOD,
    BIGFOOD,
    FRUIT
}
[Serializable]

public class Cell : MonoBehaviour
{
    public Grid m_Grid;
    protected Vector3 m_Position;
    public TileSprite m_TileSpriteOne;
    public TileSprite m_TileSpriteTwo;
    public GameObject m_Tile;
    public int x, y;
    public TileTransportType m_TileTransportType;
    public float m_TileSize;
    public SpriteRenderer m_Sprite;
    private bool m_IsCurrentlySelected;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Cell InitTile(Grid _grid, int _x, int _y,  GameObject _tileGO, float _cellSize)
    {
        m_Grid = _grid;
        x = _x;
        y = _y;
        //m_Tile1 
        m_TileSize = _cellSize;
        m_Tile = _tileGO;
        m_Tile = Instantiate(m_Tile,m_Grid.transform);
        m_Tile.name = x.ToString() + " " + y.ToString();
        float posX = x * m_TileSize;
        float posY = y * -m_TileSize;
        Vector3 pos = new Vector3(posX, posY);
        m_Position = pos;
        m_TileSpriteOne = TileSprite.NONE;
        m_TileSpriteTwo = TileSprite.NONE;
        m_TileTransportType = TileTransportType.NONE;
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Tile.transform.position = m_Position;
        return m_Tile.GetComponent<Cell>();
    }

    public Vector3 GetTilePos()
    {
        return m_Position;
    }

    void UpdateTile()
    {
        if ((m_TileSpriteTwo == TileSprite.NONE && m_TileSpriteOne == TileSprite.BACKGROUND)|| (m_TileSpriteTwo == TileSprite.BACKGROUND && m_TileSpriteOne == TileSprite.BACKGROUND))
        {
            m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteOne);
        }else if (m_TileSpriteOne == TileSprite.NONE)
        {
            m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteOne);
        }
        else
        {
            
            switch (m_TileSpriteTwo)
            {
                case TileSprite.FOOD:
                    print(m_Grid.m_TileSprite[6].name);
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.GATE:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.BLOCK:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.ENEMY:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.ENEMY2:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.ENEMY3:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.ENEMY4:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.FRUIT:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.PLAYER:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.BIGFOOD:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                case TileSprite.NONE:
                    m_Sprite.sprite = m_Grid.GetTileSprite(m_TileSpriteTwo);
                    break;
                default:
                    
                    break;
            }
        }

    }

    public void SetTile(TileSprite _tileSprite, TileTransportType _tileTransportType)
    {
        
        {
            m_TileSpriteOne = TileSprite.BACKGROUND;
            m_TileSpriteTwo = _tileSprite;
            m_TileTransportType = _tileTransportType;
        }
        UpdateTile();
    }

    public void GetTileXY(out int _x, out int _y)
    {
        _x = x;
        _y = y;
    }

    public void RemoveTile()
    {
        if (m_TileSpriteTwo != TileSprite.NONE)
        {
            m_TileSpriteTwo = TileSprite.NONE;
            m_TileTransportType = TileTransportType.WALKABLE;
        }
        else if (m_TileSpriteOne != TileSprite.NONE)
        {
            m_TileSpriteOne = TileSprite.NONE;
            m_TileTransportType = TileTransportType.NONE;
        }
        UpdateTile();
    }

    // public TileSprite GetTileOne()
    // {
    //     return m_Tile1;
    // }
    //
    // public TileSprite GetTileTwo()
    // {
    //     return m_Tile2;
    // }
    //
    public void GetTiles(out TileSprite tile1, out TileSprite tile2)
    {
        tile1 = m_TileSpriteOne;
        tile2 = m_TileSpriteTwo; 
    }

    private void OnMouseEnter()
    {
        EventManager.OnTileSelected(x,y);
        m_IsCurrentlySelected = true;
        //
        // if (GameManager.m_GameType == GameManager.GameType.LEVELEDITOR)
        // {
        //     
        // }
    }

    public bool MouseOnTile()
    {
        return m_IsCurrentlySelected;
    }
    private void OnMouseExit()
    {
        m_IsCurrentlySelected = false;
    }
}
