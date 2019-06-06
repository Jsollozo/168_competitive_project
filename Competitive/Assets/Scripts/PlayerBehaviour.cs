using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviour : MonoBehaviour
{

    public List<GameObject> m_Lanes;

    public Image m_HealthBar;

    public Image m_ChargeBar;

    [SerializeField] private float m_MaxHealth = 100f;

    [SerializeField] private float m_CurrentHealth;

    [SerializeField] float m_ChargeMultiplier = 1f;

    [SerializeField] float m_MaxCharge = 5f;

    [SerializeField] float m_CooldownInSeconds = 3f;

    protected int m_Position = 1;

    protected float m_AttackRange = 50f;

    protected float m_Damage = 5f;

    private float m_cooldownTimer = 0;

    protected bool m_IsPaused = true;

    void Awake()
    {
        m_CurrentHealth = m_MaxHealth;
        m_Position = 1;
        MovePlayer();
        ResetCharge();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TogglePause()
    {
        m_IsPaused = !m_IsPaused;
    }

    public void UpdateChargeColor()
    {
        if (m_cooldownTimer <= Time.time)
        {
            if (m_ChargeBar.color != Color.cyan)
                m_ChargeBar.color = Color.cyan;
        }
        else
        {
            m_ChargeBar.color = Color.red;
        }
    }

        public void Charge()
    {
        if(m_cooldownTimer <= Time.time)
        {
            if (m_ChargeMultiplier <= m_MaxCharge)
            {
                m_ChargeMultiplier += Time.deltaTime / 2;
                m_ChargeBar.fillAmount = m_ChargeMultiplier / m_MaxCharge;
            }
        }
    }

    public void ResetCharge()
    {
        m_ChargeMultiplier = 1;
        m_ChargeBar.fillAmount = m_ChargeMultiplier / m_MaxCharge;
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
        if(m_cooldownTimer <= Time.time)
        {
            Ray shotRay = new Ray(transform.position, direction);
            Debug.DrawRay(shotRay.origin, shotRay.direction * m_AttackRange, Color.red, 1f);
            RaycastHit hitInfo;

            if (Physics.Raycast(shotRay, out hitInfo, m_AttackRange))
            {
                Debug.Log("Hit");
                hitInfo.transform.GetComponent<PlayerBehaviour>().TakeDamage(m_Damage * m_ChargeMultiplier);
            }

            m_cooldownTimer = Time.time + m_CooldownInSeconds * m_ChargeMultiplier;
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
