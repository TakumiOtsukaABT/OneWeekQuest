﻿using UnityEngine;

public class AnimationHandle : MonoBehaviour
{
    bool running = false;
    bool stateBeforeRunning = false;
    Animator animator;

    public bool Running { get => running; set => running = value; }

    void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void animationUpStairs()
    {
        animator.Play("WalkUp");
    }
    public void animationBlackout()
    {
        animator.Play("WalkUp");
    }

    public void animationDownStairs()
    {
        animator.Play("WalkDown");
    }

    private void Update()
    {
        if (stateBeforeRunning != running)
        {
            animator.SetBool("Running", running);
        }
        stateBeforeRunning = running;
    }
}
