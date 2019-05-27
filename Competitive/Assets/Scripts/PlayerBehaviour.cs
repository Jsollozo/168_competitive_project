using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public List<GameObject> m_Lanes;

    public Image m_HealthBar;

    [SerializeField] private float m_MaxHealth = 100f;

    [SerializeField] private float m_CurrentHealth;

    protected int m_Position = 1;

    protected float m_AttackRange = 50f;

    protected float m_Damage = 5f;


    void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
        m_Position = 1;
        MovePlayer();
    }

    // Start is called before the first frame update
    void Start()
    {

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
            hitInfo.transform.GetComponent<PlayerBehaviour>().TakeDamage(m_Damage);
        }
    }

    public void TakeDamage(float amount)
    {
        m_CurrentHealth -= amount;

        m_HealthBar.fillAmount = m_CurrentHealth/m_MaxHealth;

        if (m_CurrentHealth <= 0)
        {
            Die();
        }

    }

    public void Die()
    {
        Debug.Log("I'm dead");
    }

    private void MovePlayer()
    {
        this.transform.position = m_Lanes[m_Position].transform.position;
    }
}
