﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuCanvas : MonoBehaviour
{
    [SerializeField]
    private Button _playButton;
    [SerializeField]
    private Button _leaderboardButton;
    [SerializeField]
    private Button _configurationButton;

    public MenuCanvas Initialize(Camera mainCamera)
    {
        GetComponent<Canvas>().worldCamera = mainCamera;
        return this;
    }
    
    /// <summary>
    /// Function executed by pressing the _play button
    /// </summary>
    public void Play()
    {
        DisableButtons();
        SceneManager.LoadScene(SRScenes.MainGame);
    }

    /// <summary>
    /// Function executed by pressing the _leaderboardButton button
    /// </summary>
    public void Leaderboard()
    {
        DisableButtons();
        Debug.Log("opened _leaderboardButton");
    }

    /// <summary>
    /// Function executed by pressing the _configurationButton button
    /// </summary>
    public void Configuration()
    {
        DisableButtons();
        Debug.Log("opened _configurationButton");
    }

    private MenuCanvas DisableButtons()
    {
        _playButton.interactable = false;
        _leaderboardButton.interactable = false;
        _configurationButton.interactable = false;
        return this;
    }

    private MenuCanvas EnableButtons()
    {
        _playButton.interactable = true;
        _leaderboardButton.interactable = true;
        _configurationButton.interactable = true;
        return this;
    }
}
