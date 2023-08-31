using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Net.Mime;

public class TextFileReader : MonoBehaviour
{
    [SerializeField] private TextAsset dialogueText;

    void Start()
    {
        string text = "";
        TextReader();
    }

    public void TextReader()
    {
        
        var content = dialogueText.text;
        
        string[] lines = content.Split(new [] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries); //change
        
        Queue<string> dialogueQueue = new Queue<string>();
        
        foreach (string line in lines)
        {
            dialogueQueue.Enqueue(line);
        }
        
        while (dialogueQueue.Count > 0)
        {
            string line = dialogueQueue.Dequeue();


            Debug.Log(line);
        }

        void update()
        {

        }
    }
}


