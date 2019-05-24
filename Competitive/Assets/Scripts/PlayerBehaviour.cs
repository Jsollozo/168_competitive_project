using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{

    public List<GameObject> m_Lanes;

    protected int m_Position = 1;

    protected float m_AttackRange = 50f;

    // Start is called before the first frame update
    void Start()
    {
        m_Position = 1;
        MovePlayer();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MoveUp()
    {
        if(m_Position > 0)
        {
            m_Position -= 1;
            MovePlayer();
        }
    }

    public void MoveDown()
    {
        if(m_Position < m_Lanes.Count - 1)
        {
            m_Position += 1;
            MovePlayer();
        }
    }

    public void Shoot(Vector3 direction)
    {
        Ray shotRay = new Ray(transform.position, direction);
        Debug.DrawRay(shotRay.origin, shotRay.direction * m_AttackRange, Color.red, 1f);

        RaycastHit hitInfo;
        if (Physics.Raycast(shotRay, out hitInfo, m_AttackRange))
        {
            Debug.Log("Hit");
        }
    }

    private void MovePlayer()
    {
        this.transform.position = m_Lanes[m_Position].transform.position;
    }
}
