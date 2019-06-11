using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPack : Health
{
    [SerializeField] float m_HealAmount = 15f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Die()
    {
        if(m_LastHitBy != null)
            m_LastHitBy.GetComponent<Health>().Heal(m_HealAmount);

        base.Die();
    }
}
