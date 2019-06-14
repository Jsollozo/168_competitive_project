using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public GameObject controlsPanel;
    public GameObject instructions;

    private bool m_IsPaused = false;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            controlsPanel.SetActive(true);
            TogglePause();
        }
        else if (Input.GetButtonDown("Resume"))
        {
            TogglePause();
        }
        else if (Input.GetButtonDown("Instruction"))
        {
            ToggleInstructions();
        }
        else if (Input.GetButtonDown("Quit"))
        {
            ToggleQuit();
        }
    }

    public void TogglePause()
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

    public void ToggleInstructions()
    {
        instructions.SetActive(true);
        controlsPanel.SetActive(false);
    }

    public void ToggleQuit()
    {
        Application.Quit();
    }

    public void Open()
    {
        controlsPanel.SetActive(true);
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
