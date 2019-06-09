using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lane : MonoBehaviour
{
    [SerializeField] bool m_IsOccupied = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsOccupied()
    {
        return m_IsOccupied;
    }

    public void Occupy()
    {
        m_IsOccupied = true;
    }

    public void Vacate()
    {
        m_IsOccupied = false;
    }
}
