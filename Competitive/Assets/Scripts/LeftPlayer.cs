using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayer : PlayerBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            Shoot(transform.right);
        }
    }
}
