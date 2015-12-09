﻿using System;
using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class Pizza : MonoBehaviourEx {

    private Rigidbody2D _rigidbody2D;

    private float strenght = 75f;

    public enum State
    {
        Idle,
        Moving,
        Death,
    }

    private Action _currentState;
    public State CurrentStateName;

    private void SetState(State state)
    {
        CurrentStateName = state;
        switch (state)
        {
            case State.Idle:
                _currentState = Idle;
                break;

            case State.Moving:
                _currentState = Moving;
                _rigidbody2D.AddForce(Random_dir() * strenght);
                break;
            case State.Death:
                _currentState = Death;
                break;
            default:
                Debug.Log("unrecognized state");
                break;
        }
    }

    private void Idle()
    {

    }

    private void Moving()
    {

    }

    private void Death()
    {

    }

    private Vector2 Random_dir()
    {
        var tempAngle = Random.Range(90, 271);
        return new Vector2((float)Mathf.Cos(tempAngle), (float)Mathf.Sin(tempAngle));
    }

    private void Update()
    {
        _currentState();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag(SRTags.Player))
        {
            Messenger.Publish(new PizzaEatenMessage(gameObject));
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.MediumHit));
        }
    }

    public override void Awake()
    {
        base.Awake();
        _rigidbody2D = this.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        _currentState = Idle;
        SetState(State.Moving);
    }
}
