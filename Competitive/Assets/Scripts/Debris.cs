using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class MyIntEvent : UnityEvent<int>
{
}

public class Debris : MonoBehaviour
{

    public MyIntEvent debrisDestroyed = new MyIntEvent();

    // 0 - Top, 1 - Mid, 2 - Bot
    [SerializeField] int m_BelongToLane;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLane(int i)
    {
        m_BelongToLane = i;
    }

    void OnDestroy()
    {
        debrisDestroyed.Invoke(m_BelongToLane);
    }
}
