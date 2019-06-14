using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsPanel;

    private bool m_IsPaused = true;

    void Awake()
    {
        //controlsPanel.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            TogglePause();
        }
    }

    private void TogglePause()
    {
        m_IsPaused = !m_IsPaused;

        if (m_IsPaused)
        {
            Open();
        }
        else
        {
            Close();
        }
    }

    public void Open()
    {
        //controlsPanel.SetActive(true);
        TogglePauseOnPlayers();
    }

    public void Close()
    {
        controlsPanel.SetActive(false);
        TogglePauseOnPlayers();
    }

    private void TogglePauseOnPlayers()
    {
        var players = GameObject.FindGameObjectsWithTag("Player");

        foreach (var player in players)
        {
            player.GetComponent<PlayerBehaviour>().TogglePause();
        }
    }
}
