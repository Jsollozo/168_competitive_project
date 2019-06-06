using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayer : PlayerBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPaused)
        {
            return;
        }

        UpdateChargeColor();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveUp();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveDown();
        }

        if(Input.GetKey(KeyCode.RightArrow))
        {
            Charge();
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            Shoot(transform.right * -1);
            ResetCharge();
        }
    }
}
