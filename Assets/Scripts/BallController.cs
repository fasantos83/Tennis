using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float startForce;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public GameManager gameManager;

    private Rigidbody2D rb2D;

    private void Start() {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = new Vector2(startForce, startForce);
    }


    private void OnTriggerEnter2D(Collider2D other) {

        if (other.CompareTag("GoalZone")) {
            Vector3 newPosition;
            float direction;
            int player;
            if (transform.position.x < 0) {
                //Ball exited through the left side
                newPosition = rightPaddle.transform.position + new Vector3(-1f, 0f, 0f);
                direction = -1;
                player = 2;
                //Ball exited through the right side
            } else {
                newPosition = leftPaddle.transform.position + new Vector3(1f, 0f, 0f);
                direction = 1;
                player = 1;
            }
            gameManager.UpdateScore(player);
            transform.position = newPosition;
            rb2D.velocity = rb2D.velocity = new Vector2(startForce * direction, startForce * direction);
        }
    }
}
