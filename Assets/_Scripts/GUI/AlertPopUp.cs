﻿using System;
using UnityEngine;
using UnityEngine.UI;

public class AlertPopUp : MonoBehaviourEx, IHandle<ShowAlertMessage>
{
    
    public AlertPopUp Initialize()
    {
        _childrenController = gameObject.AddComponent<ChildrenControllerComponent>();
        _basePopupComponent = gameObject.GetComponent<BasePopupComponent>();
        _onCloseEndedDelegate = OnCloseEnded;
        _basePopupComponent.Initialize(_onCloseEndedDelegate);
        _messageText = GetComponentsInChildren<Text>(true)[0];
        return this;
    }

    public void Handle(ShowAlertMessage message)
    {
        _childrenController.EnableChildren();
        _basePopupComponent.ShowPopUp();      
        _messageText.text = message.Message;
        return;
    }

    private void OnCloseEnded()
    {
        _childrenController.DisableChildren();
    }

    public void ClosePopUp()
    {
        Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.BasicButton));
        _basePopupComponent.ClosePopUp();
        return;
    }

    private ChildrenControllerComponent _childrenController;
    private Action _onCloseEndedDelegate;

    private Text _messageText;
    private BasePopupComponent _basePopupComponent;
}
