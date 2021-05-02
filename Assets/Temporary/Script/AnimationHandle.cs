﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Update()
    {
        if(stateBeforeRunning != running)
        {
            animator.SetBool("Running", running);
            
        }
        stateBeforeRunning = running;
    }
}
