﻿using System;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using LocalConfig = Config.TypeWritting;

public class TypeWriting : MonoBehaviourEx
{

    private Action<char> _callback;
    private Text dialogueBox;
    //Image showAvailabeAction;
    private string[] currentDialogLines;
    private int currentLine;
    //private int _messageId;
    private bool _typing = false;
    
    // Use this for initialization
	/*void Start () {
        dialogueBox = transform.Find("dialogText").GetComponent<Text>();
	    dialogueBox.text ="";
	}*/

    public void StartWrite(string text, Action<char> callback)
    {
        /*foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
        //showAvailabeAction.gameObject.SetActive(false);
        currentDialogLines = message.DialogText;
        //_messageId = message.MessageId;
        currentLine = 0;*/
        //StartCoroutine(DetectInput());
        //NextLine();
        _callback = callback;
        StartCoroutine(TypeText(text));
    }

    /*public void NextLine()
    {
        if (_typing) return;
        if (currentDialogLines.Length > currentLine)
        {
            dialogueBox.text = "";
            StopCoroutine("TypeText");
            StartCoroutine(TypeText(currentDialogLines, currentLine));
        }
        else
        {
            StopAllCoroutines();
            foreach (Transform child in transform)
            {
                child.gameObject.SetActive(false);
            }
            //Messenger.Publish(new DialogueEndMessage(_messageId));
        }
        currentLine++;
    }*/
    //TODO: remove references of UI.text, just use callback and make it more Loosely coupled
    IEnumerator TypeText(string text/*, int line*/)
    {
        _typing = true;
        //showAvailabeAction.gameObject.SetActive(false);
        foreach (char letter in text/*[line]*/.ToCharArray())
        {
            _callback(letter);
            Messenger.Publish(new PlaySoundEffectMessage(SRResources.Core.Audio.Clips.SoundEffects.keystroke));
            yield return new WaitForSeconds(LocalConfig.TimePerLetter);
        }
        //showAvailabeAction.gameObject.SetActive(true);
        _typing = false;
    }

    /*IEnumerator DetectInput()
    {
        while (true)
        {
            if (Input.GetButtonDown("Action"))
            {
                NextLine();
            }
            yield return null;
        }
       
    }*/

    public TypeWriting StopWriting()
    {
        if (_typing)
        {
            StopAllCoroutines();
        }
        return this;
    }
}
