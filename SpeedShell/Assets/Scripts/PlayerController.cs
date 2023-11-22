using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 7f;
    [SerializeField] public float Rotatespeed = 50f;


    public  SFXManager sfxManager;
    
    void Start()
    {
        sfxManager.PlaySound("Thud");
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0f, verticalInput, 0f) ;
        Vector3 rotation = new Vector3(0f, 0f, horizontalInput);

        transform.Translate(movement * speed * Time.deltaTime);
        if (verticalInput != 0)
        {
            transform.Rotate(rotation * Rotatespeed * Time.deltaTime);
           // sfxManager.PlaySound("Start");
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        sfxManager.PlaySound("Thud");
    }
}
