using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.Mime;
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
    private int count = 0;
    private Queue<string> dialogueQueue; 

    void Start()
    {
        
        string text = "";
        TextReader();
        NextButtonPress();
        
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
        count++;
        string line = dialogueQueue.Dequeue();
        dialogueTextBox.text = line;
        Debug.Log(count);

        if (count % 2 == 0)
        {
            snailImage.GetComponent<Animator>().Play("InactiveDialogue");
        }
        else
        {
            snailImage.GetComponent<Animator>().Play("ActiveDialogue");
        }
        
        
        if (dialogueQueue.Count <= 0)
        {
           SceneManager.LoadScene("Checkpoint Race");
           
        }
    }

    

    
}


