using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class Tile : MonoBehaviour
{
    public Color m_baseColour, m_OffsetColour;
    public SpriteRenderer m_BackgroundRender;
    public GameObject m_Highlight;
    

    public void Init(bool isOffset)
    {
       
        //m_Render[0].color = isOffset ? m_OffsetColour : m_baseColour;
    }

    private void OnMouseEnter()
    {
        m_Highlight.SetActive(true);
    }

    private void OnMouseExit()
    {
        m_Highlight.SetActive(false);
    }

    public void FoodTile()
    {
        
    }
}
