﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RoachCount : MonoBehaviourEx, IHandle<RoachDeathMessage>
{
    private int _deadCount;
    private Text _text;

    public int GetScore()
    {
        return _deadCount;
    }

    public RoachCount Reset()
    {
        _deadCount = 0;
        _text.text = _deadCount.ToString();
        return this;
    }

    private  void Start()
    {
        _text = GetComponent<Text>();
    }

    public void Handle(RoachDeathMessage message)
    {
        _deadCount++;
        _text.text = _deadCount.ToString();
    }
    
}
