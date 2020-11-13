    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour {

    float verticalInput;
    public float movementSpeed = 5.0f;
    public float smooth = 2.0f;

    public string axisName;

    Rigidbody2D rb;

    public GameObject Top;
    public GameObject Center;
    public GameObject Bottom;

    void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update() {

        verticalInput = Input.GetAxisRaw(axisName);
    }

    void FixedUpdate() {

        Vector3 newPosition = transform.position + (Vector3.up * verticalInput * movementSpeed * Time.deltaTime);
        rb.MovePosition(Vector3.Lerp(transform.position, newPosition, smooth));
    }
}
