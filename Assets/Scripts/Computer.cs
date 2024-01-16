using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Computer : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    [SerializeField] private Ball ball;
    private void Update() {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(transform.position.x, ball.transform.position.y), speed * Time.deltaTime);
    }
}
