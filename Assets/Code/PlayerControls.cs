using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerControls : MonoBehaviour
{

    public float MoveSpeed = 1f;
    public float JumpSpeed = 5f;
    public bool IsJumping = false;
    public float HowManyJumps = 1f;

    private float CurrentJumps;
    private float Move;
    private Vector2 Movement;
    private Rigidbody2D PlayerRigidBody;
    private Vector3 SpawnPos;

    void Start() {
        PlayerRigidBody = GetComponent<Rigidbody2D>();
        CurrentJumps = HowManyJumps;
        SpawnPos = transform.position;
        Debug.Log(SpawnPos);
    }

    public void Reset() {
        transform.position = SpawnPos;
    }

    void Update() {
        
        Move = Input.GetAxis("Horizontal");

        PlayerRigidBody.velocity = new Vector2(MoveSpeed * Move, PlayerRigidBody.velocity.y);

        if (Input.GetButtonDown("Jump") && (IsJumping == false || CurrentJumps != 0)) {
            CurrentJumps--;
            PlayerRigidBody.velocity = new Vector2(PlayerRigidBody.velocity.x, JumpSpeed);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) { 
        if (other.gameObject.CompareTag("Ground")) {
            IsJumping = false;
            CurrentJumps = HowManyJumps;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("Ground")) {
            IsJumping = true;
        }
    }


}
