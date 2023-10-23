using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.Mime;
using StacksAndQueues;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;

public class TextFileReader : MonoBehaviour
{
    [SerializeField] private TextAsset dialogueText;
    [SerializeField] private Button nextButton;
    [SerializeField] private Text dialogueTextBox;
    [SerializeField] private GameObject snailImage;
    private int count;
    private QueueLinked<string> dialogueQueue; 
    int isSpeaking = 1;
    void Start()
    {
        TextReader();
        NextButtonPress();
    }
    

    public void TextReader()
    {
        
        var content = dialogueText.text;
        
        string[] lines = content.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); 
        
        dialogueQueue = new QueueLinked<string>();
        
        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
           // Debug.Log(line);
        }
        nextButton.onClick.AddListener(NextButtonPress);
    }

    public void NextButtonPress()
    {
        isSpeaking *= -1;
        var line = dialogueQueue.Dequeue();
        if (count == 0)
        {
            line = dialogueQueue.Dequeue();
        }
        Debug.Log("ButtonClicked");
        dialogueTextBox.text = line;
        count++;
       
        if (isSpeaking == 1)
        {
            
            snailImage.GetComponent<Animator>().Play("InactiveDialogue");
            
        }
        else
        {
            
            snailImage.GetComponent<Animator>().Play("ActiveDialogue");
        }
        
        
        if (dialogueQueue.Size <= 0)
        {
            SceneManager.LoadScene("Checkpoint Race");
        }
    }
}


