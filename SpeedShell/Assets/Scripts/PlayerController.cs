using System.Collections;
using System.Collections.Generic;
using UnityEditor.Searcher;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] public float speed = 7f;
    [SerializeField] public float Rotatespeed = 50f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0f, 0.0f, verticalInput * -1);
        Vector3 rotation = new Vector3(0f, horizontalInput, 0f);

        transform.Translate(movement * speed * Time.deltaTime);
        if (verticalInput != 0)
        {
            transform.Rotate(rotation * Rotatespeed * Time.deltaTime);
        }
        
       
        
    }
}
