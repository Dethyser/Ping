using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    Rigidbody2D rb;

    float initialSpeed = 5.0f;
    float startCooldown;
    public float maxSpeed;
    public float normalizedVelocity;

    float timeDifference;

    bool waits;

    Vector3 lastPosition = Vector3.zero;

    public GameObject player1;
    public GameObject player2;

    public GameObject ballTexture;
    public GameObject ballCollider1;
    public GameObject ballCollider2;
    SpriteRenderer ballRenderer;

    void Awake() {

        rb = gameObject.GetComponent<Rigidbody2D>();
        ballRenderer = ballTexture.GetComponent<SpriteRenderer>();
    }

    void Start() {

        ResetBall();
    }

    void Update() {
        timeDifference = Time.deltaTime;
        normalizedVelocity = CalculateNormalizedVelocity();
        ColorBall();
        if (normalizedVelocity >= 1) {

            ballCollider1.GetComponent<BoxCollider2D>().enabled = false;
            ballCollider2.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (startCooldown > 0.0f) {

            startCooldown -= timeDifference;
        } else if(waits) {

            rb.velocity = Random.insideUnitCircle.normalized * initialSpeed;
            waits = false;
        }
    }

    void ResetBall() {

        lastPosition = Vector3.zero;
        transform.position = Vector3.zero;
        rb.velocity = Vector3.zero;
        startCooldown = 3.0f;
        waits = true;

        ballCollider2.GetComponent<BoxCollider2D>().enabled = false;
        ballCollider1.GetComponent<BoxCollider2D>().enabled = true;
    }

    private void OnTriggerEnter2D(Collider2D collision) {

        ResetBall();
    }

    private void OnCollisionEnter2D(Collision2D collision) {

        float velocityLength = rb.velocity.magnitude;
        Vector2 currentVelocity = rb.velocity;

        switch (collision.collider.tag) {

            case "Top":
                rb.velocity = currentVelocity.y >= 0
                    ? (new Vector2(currentVelocity.x + 1, currentVelocity.y + 1).normalized * velocityLength) / 1.1f
                    : (new Vector2(currentVelocity.x + 1, currentVelocity.y + 3).normalized * velocityLength) / 1.1f;
                break;

            case "Center":
                rb.velocity = new Vector2(currentVelocity.x + 3, currentVelocity.y).normalized * velocityLength * 1.025f;
                break;

            case "Bottom":
                rb.velocity = currentVelocity.y >= 0
                    ? (new Vector2(currentVelocity.x - 1, currentVelocity.y - 3).normalized * velocityLength) / 1.1f
                    : (new Vector2(currentVelocity.x - 1, currentVelocity.y - 1).normalized * velocityLength) / 1.1f;
                break;

            default:
                break;
        }

        

    }

    float CalculateNormalizedVelocity() {

        return rb.velocity.magnitude / maxSpeed;

    }

    void ColorBall() {

        //float colorGB = (1.0f - (2.0f * (point - ((point > 25.0f) ? 25.0f : point))) / 255.0f);
        ballRenderer.color = new Color(1.0f, 1.0f - normalizedVelocity, 1.0f - normalizedVelocity, 1.0f);
    }
}
