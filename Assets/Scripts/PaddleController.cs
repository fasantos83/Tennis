using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public float speed;
    public float adjustSpeed;
    public float lowerLimit = -3.7f;
    public float upperLimit = 3.7f;

    public bool isPlayerOne;
    public bool isAI;
    public BallController ballController;

    private float direction;

    private void Start() {
        ballController = FindObjectOfType<BallController>();    
    }

    private void Update() {        
        Vector3 newPosition;
        float clampYPosition;
        if (isAI) {
            clampYPosition = ballController.transform.position.y;
            clampYPosition = Mathf.Clamp(clampYPosition, lowerLimit, upperLimit);
            newPosition = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, clampYPosition, transform.position.z), speed * Time.deltaTime);
        } else {
            direction = 0;
            if (isPlayerOne && Input.GetKey(KeyCode.W) || !isPlayerOne && Input.GetKey(KeyCode.UpArrow)) {
                direction = 1;
            } else if (isPlayerOne && Input.GetKey(KeyCode.S) || !isPlayerOne && Input.GetKey(KeyCode.DownArrow)) {
                direction = -1;
            }
            clampYPosition = transform.position.y + (direction * speed * Time.deltaTime);
            clampYPosition = Mathf.Clamp(clampYPosition, lowerLimit, upperLimit);
            newPosition = new Vector3(transform.position.x, clampYPosition, transform.position.z);
        }
        
        transform.position = newPosition;
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f, other.rigidbody.velocity.y + (direction * adjustSpeed));
    }
}
