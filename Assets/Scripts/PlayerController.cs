using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float speed = 30f;

    private void Start() { 
        rb = GetComponent<Rigidbody2D>();
    }

    public void PlayerMovement() {
        float y = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(0, y) * speed;
    }
}
