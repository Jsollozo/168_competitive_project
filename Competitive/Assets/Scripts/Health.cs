using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image m_HealthBar;

    [SerializeField] private float m_MaxHealth = 100f;

    [SerializeField] private float m_CurrentHealth;

    void Awake()
    {
        ResetHealth();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ResetHealth()
    {
        m_CurrentHealth = m_MaxHealth;
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        m_HealthBar.fillAmount = m_CurrentHealth / m_MaxHealth;

        if (m_CurrentHealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("I'm dead");
    }
}
