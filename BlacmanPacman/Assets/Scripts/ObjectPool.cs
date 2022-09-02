using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject m_ObjectToPool;
    public int m_PooledAmount;
    private List<GameObject> m_PoolOfObjects;

    private void Start()
    {
        m_PoolOfObjects = new List<GameObject>();


    }

    public void InitPool()
    {
        for (int i = 0; i < m_PooledAmount; i++)
        {
            AddToPool();
        }
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < m_PoolOfObjects.Count; i++)
        {
            if (!m_PoolOfObjects[i].activeInHierarchy)
            {
                return m_PoolOfObjects[i];
            }
        }
        AddToPool();
        return m_PoolOfObjects[m_PoolOfObjects.Count - 1];
    }

    public void AddToPool()
    {
        GameObject obj = Instantiate(m_ObjectToPool);
        obj.transform.SetParent(transform);
        obj.SetActive(false);
        m_PoolOfObjects.Add(obj);
    }

}
