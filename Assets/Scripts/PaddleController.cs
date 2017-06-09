using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour {

    public float speed;
    public float adjustSpeed;
    public float lowerLimit = -3.7f;
    public float upperLimit = 3.7f;
    public bool isRedPlayer;

    private float direction;

    private void Update() {
        direction = 0;
        if (isRedPlayer && Input.GetKey(KeyCode.W) || !isRedPlayer && Input.GetKey(KeyCode.UpArrow)) {
            direction = 1;
        } else if (isRedPlayer && Input.GetKey(KeyCode.S) || !isRedPlayer && Input.GetKey(KeyCode.DownArrow)) {
            direction = -1;
        }
        float clampYPosition = transform.position.y + (direction * speed * Time.deltaTime);
        clampYPosition = Mathf.Clamp(clampYPosition, lowerLimit, upperLimit);
        Vector3 newPosition = new Vector3(transform.position.x, clampYPosition, transform.position.z);
        transform.position = newPosition;
    }

    private void OnCollisionExit2D(Collision2D other) {
        other.rigidbody.velocity = new Vector2(other.rigidbody.velocity.x * 1.1f, other.rigidbody.velocity.y + (direction * adjustSpeed));
    }
}
