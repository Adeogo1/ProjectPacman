using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelEditorManager : MonoBehaviour
{
    //make reference to ourItemControllerScripts
    public List<GameItemController> m_GameItems = new List<GameItemController>();

    public List<GameObject> m_ItemPrefabs;
    public int m_CurrentButtonPressed = -1;

    private GameObject m_Item;

    private void Update()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);

        if (m_GameItems[m_CurrentButtonPressed].m_Clicked)
        {
            m_Item.transform.position = worldPos;
            if (Input.GetMouseButtonDown(0))
            {
                m_GameItems[m_CurrentButtonPressed].m_Clicked = false;
                Instantiate(m_ItemPrefabs[m_CurrentButtonPressed], new Vector3(worldPos.x, worldPos.y),
                    Quaternion.identity);
                
            }//for destruction do on mouse over
        }
    }

    public void ItemClicked(GameObject _Item)
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(screenPos);
        m_Item = Instantiate(_Item, worldPos, Quaternion.identity);
    }
    
}
