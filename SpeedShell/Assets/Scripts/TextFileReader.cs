using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.Mime;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextFileReader : MonoBehaviour
{
    [SerializeField] private TextAsset dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Text dialogueTextBox;
    private Queue<string> dialogueQueue; 

    void Start()
    {
        string text = "";
        TextReader();
    }

    public void TextReader()
    {
        
        var content = dialogueText.text;
        
        string[] lines = content.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); //change
        
        dialogueQueue = new Queue<string>();
        
        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
        }
        
        nextButton.onClick.AddListener(NextButtonPress);

    }

    public void NextButtonPress()
    {
        string line = dialogueQueue.Dequeue();

        dialogueTextBox.text = line;
        
        Debug.Log(line);
        if (dialogueQueue.Count <= 0)
        {
            SceneManager.LoadScene();
        }
    }
}


