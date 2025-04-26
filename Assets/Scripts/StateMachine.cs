﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        idle,
        walking,
        swimming,
        climbing
    }

    public State currentState = State.idle;
    Vector3 lastPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.idle: Idle(); break;
            case State.walking: Walking(); break;
            case State.swimming: Swimming(); break;
            case State.climbing: Climbing(); break;
            default: break;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if(other.name == "Water")
        {
            Swimming();
        }
    }

    void OnTriggerExit(Collider other)
    {
        
    }

    void Swimming()
    {
        Debug.Log("I am swimming");
    }

    void Climbing()
    {
        Debug.Log("I am climbing");
    }

    void Idle()
    {
        Debug.Log("I am idle");
        if (lastPosition != transform.position)
        {
            Debug.Log("Moving");
        }
        lastPosition = transform.position;
    }

    void Walking()
    {
        Debug.Log("I am walking");
        if (lastPosition == transform.position)
        {
            Debug.Log("Stopped");
        }
        lastPosition = transform.position;
    }
}
