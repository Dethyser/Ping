using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Goal : MonoBehaviour {

    public UnityEvent goalEvent;

    private void OnTriggerEnter2D(Collider2D collision) {

        goalEvent.Invoke();
    }
}
