using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator controller;

    private static readonly int Happy = Animator.StringToHash("happy");
    private static readonly int Hiphop = Animator.StringToHash("hiphop");
    private static readonly int Silly = Animator.StringToHash("silly");
    
    private static readonly int CycleOffset = Animator.StringToHash("offset");
    private static readonly int Mirror = Animator.StringToHash("offset");
    // Start is called before the first frame update
    private void Awake()
    {
        controller = GetComponent<Animator>();
        controller.speed = Random.Range(0.95f, 1.05f);
        //controller.
        
        controller.SetFloat(CycleOffset, Random.Range(0f,1f));
        controller.SetBool(Mirror, Random.Range(0f,1f) > 0.5f);

        RandomiseAnimation();
    }

    void RandomiseAnimation()
    {
        int[] trigger = { Happy, Hiphop, Silly };
        StartCoroutine(TriggerAnimationCouroutine(trigger[Random.Range(0, trigger.Length)]));
    }

    IEnumerator WaitRandomTime()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        RandomiseAnimation();
    }


    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            StartCoroutine(TriggerAnimationCouroutine(Happy));
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            StartCoroutine(TriggerAnimationCouroutine(Hiphop));
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            StartCoroutine(TriggerAnimationCouroutine(Silly));
        }
    }



    IEnumerator TriggerAnimationCouroutine(int id)
    {
        controller.SetTrigger(id);

        yield return new WaitForSeconds(0.1f);
        
        controller.ResetTrigger(id);
    }
}
