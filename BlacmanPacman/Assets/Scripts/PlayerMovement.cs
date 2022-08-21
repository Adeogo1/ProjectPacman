using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{

    public float m_Speed;
    public Transform m_MovePoint;
    private Vector2 m_MoveInput;
    public LayerMask m_WhatStopsMovement; 
    void Start()
    {
        m_MovePoint.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //Move();

        transform.position = Vector3.MoveTowards(transform.position, m_MovePoint.position, m_Speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, m_MovePoint.position) <= .05f)
        {
            
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (!Physics2D.OverlapCircle(m_MovePoint.position + new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0),.2f, m_WhatStopsMovement))
                {
                    m_MovePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
                }
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (!Physics2D.OverlapCircle(m_MovePoint.position + new Vector3(0, Input.GetAxisRaw("Vertical"), 0),.2f, m_WhatStopsMovement))
                {
                    m_MovePoint.position += new Vector3(0, Input.GetAxisRaw("Vertical"), 0);
                }
            }

        }
    }


    void Move()
    {
        m_MoveInput = new Vector2(Input.GetAxis("Horizontal") ,Input.GetAxis("Vertical")).normalized;
        transform.position += (Vector3)m_MoveInput * m_Speed * Time.deltaTime;
    }
    
    
}
