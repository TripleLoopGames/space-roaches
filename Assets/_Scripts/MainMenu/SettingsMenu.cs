﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LocalConfig = Config.Audio;
using System;

public class SettingsMenu : MonoBehaviourEx, IHandle<AudioSetUpMessage>
{
    private MenuCanvas.EnableDelegate _enableDelegate;
    private Action _onCloseEndedDelegate;

    private BasePopupComponent _basePopupComponent;

    [SerializeField]
    private Slider _effectsSlider;
    [SerializeField]
    private Slider _musicSlider;
    [SerializeField]
    private Toggle _tutoriaToggle;

    private bool _audioSetUp;

    public SettingsMenu Initialize(bool tutorialForced)
    {
        if (!_audioSetUp)
        {
            Messenger.Publish(new RequestAudioStateMessage());
        }
        _effectsSlider.maxValue = LocalConfig.EffectsSlider.MaxValue;
        _effectsSlider.minValue = LocalConfig.EffectsSlider.MinValue;
        _musicSlider.maxValue = LocalConfig.MusicSlider.MaxValue;
        _musicSlider.minValue = LocalConfig.MusicSlider.MinValue;
        _tutoriaToggle.isOn = tutorialForced;
        _onCloseEndedDelegate = OnCloseEnded;
        _basePopupComponent = gameObject.GetComponent<BasePopupComponent>();
        _basePopupComponent.Initialize(_onCloseEndedDelegate);
        return this;
    }

    public SettingsMenu Show(MenuCanvas.EnableDelegate enableDelegate)
    {
        EnableChildren();
        _basePopupComponent.ShowPopUp();
        _enableDelegate = enableDelegate;
        return this;
    }

    private void OnCloseEnded()
    {
        DisableChildren();
    }

    //Function executed on pressing popup x button
    public void Close()
    {
        _basePopupComponent.ClosePopUp();
        _enableDelegate();
    }

    public void OnSliderMusic(float value)
    {
        if (!_audioSetUp) return;
        Messenger.Publish(new AudioStateMessage(null, value));
    }

    public void OnSliderEffects(float value)
    {
        if (!_audioSetUp) return;
        Messenger.Publish(new AudioStateMessage(value, null));
    }

    public void OnToogleTutorial(bool value)
    { 
        Messenger.Publish(new TutorialForcedMessage(value));
    }

    public void Handle(AudioSetUpMessage message)
    {
        if (message.EffectsVolume != null)
        {
            _effectsSlider.value = message.EffectsVolume.Value;
        }
        if (message.MusicVolume != null)
        {
            _musicSlider.value = message.MusicVolume.Value;
        }
        _audioSetUp = true;
    }

    private SettingsMenu EnableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        return this;
    }

    private SettingsMenu DisableChildren()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
        return this;
    }
   
}
