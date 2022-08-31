using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameItemController : MonoBehaviour
{
    public int ID;
    public int m_Quantity;
    public bool m_Clicked = false;
    private LevelEditorManager m_LevelEditor;
    
    void Start()
    {
        m_LevelEditor =
            GameObject.FindGameObjectWithTag("LevelEditorManager").GetComponent<LevelEditorManager>();
    }

    public void ButtonClicked()
    {
        // if (m_Quantity > 0)
        // {
        //     m_Quantity --;
        // }
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        m_Clicked = true;
        m_LevelEditor.m_CurrentButtonPressed = ID;
        GameObject shadow = m_LevelEditor.m_ItemPrefabs[ID];
        var colour = shadow.GetComponent<SpriteRenderer>().color;
        colour.a = 0.4f;
        shadow.GetComponent<SpriteRenderer>().color = colour;
        m_LevelEditor.ItemClicked(shadow);
    }

}
