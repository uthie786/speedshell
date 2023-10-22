using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AJAnimatorController : MonoBehaviour
{
    private Animator controller;

    private static readonly int Victory = Animator.StringToHash("victoryIdle");
    private static readonly int Rallying = Animator.StringToHash("rallying");
    private static readonly int Defeat = Animator.StringToHash("defeat");
    
    private static readonly int CycleOffset = Animator.StringToHash("offset");
    private static readonly int Mirror = Animator.StringToHash("mirror");
    
    private void Awake()
    {
        controller = GetComponent<Animator>();
        controller.speed = Random.Range(0.95f, 1.05f);

        controller.SetFloat(CycleOffset, Random.Range(0f,1f));
        controller.SetBool(Mirror, Random.Range(0f,1f) > 0.5f);

        RandomiseAnimation();
    }

    void RandomiseAnimation()
    {
        int[] trigger = { Victory, Defeat, Rallying };
        StartCoroutine(TriggerAnimationCouroutine(trigger[Random.Range(0, trigger.Length)]));
        StartCoroutine(WaitRandomTime());
    }

    IEnumerator WaitRandomTime()
    {
        yield return new WaitForSeconds(Random.Range(3f, 10f));
        RandomiseAnimation();
        
    }
    
    IEnumerator TriggerAnimationCouroutine(int id)
    {
        controller.SetTrigger(id);

        yield return new WaitForSeconds(0.1f);
        
        controller.ResetTrigger(id);
    }
}
