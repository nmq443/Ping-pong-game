using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public void StartGame() {
        float speed = GameController.Instance.gameSpeed;
        GetComponent<Rigidbody2D>().velocity = Vector2.right*speed;
    }

    private float hitFactor(Vector2 ballPos, Vector2 racketPos, float racketHeight) {
        return (ballPos.y - racketPos.y)/racketHeight;
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        float speed = GameController.Instance.gameSpeed;
        if (collision.gameObject.name == "Player") {
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-1, y).normalized * speed;
        } else if (collision.gameObject.name == "Computer") {
            float y = hitFactor(transform.position, collision.transform.position, collision.collider.bounds.size.y);
            GetComponent<Rigidbody2D>().velocity = new Vector2(1, y).normalized * speed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "LeftWall") {
            // gameObject.SetActive(false);
            transform.position = new Vector3(0, 0, 0);
            GameController.Instance.PlayerScore();
        } else if (collider.name == "RightWall") {
            // gameObject.SetActive(false);
            transform.position = new Vector3(0, 0, 0);
            GameController.Instance.ComputerScore();
        }
    }

    private void Update() {

    }
}
