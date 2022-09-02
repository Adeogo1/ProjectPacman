using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid3 : MonoBehaviour
{
    
    public int m_Rows, m_Col;
    public float m_TileSize = 1;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
