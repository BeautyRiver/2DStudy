using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MoveMent2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f; // 플레이어 이동속도
    [SerializeField]
    private float jumpForce = 8.0f;
    private Rigidbody2D rigid2D;    
    public bool isLongJump = false;

    [SerializeField]
    private LayerMask groundLayer; // 바닥 체크를 위한 레이어
    private CircleCollider2D circleCollider2D; 
    private bool isGrounded; // 바닥 체크
    private Vector3 footPostion; // 발의 위치

    [SerializeField]
    private int maxJumpCount = 2; // 최대 점프 횟수
    private int currentJumpCount = 0; // 현재 가능한 점프 횟수

    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        circleCollider2D = GetComponent<CircleCollider2D>();
    }

    private void FixedUpdate()
    {
        Bounds bounds = circleCollider2D.bounds;
        footPostion = new Vector2(bounds.center.x, bounds.min.y);
        isGrounded = Physics2D.OverlapCircle(footPostion, 0.1f, groundLayer);
        
        if (isGrounded == true && rigid2D.velocity.y <= 0)
        {
            currentJumpCount = maxJumpCount;
        }

        // 낮은 점프, 높은 점프
        if (isLongJump && rigid2D.velocity.y > 0)
        {
            rigid2D.gravityScale = 1.0f;
        }
        else
        {
            rigid2D.gravityScale = 2.5f;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(footPostion, 0.1f);
    }
    public void Move(float x)
    {
        rigid2D.velocity = new Vector2(x * speed, rigid2D.velocity.y);
    }
    public void Jump()
    {
        if (currentJumpCount > 0)
        {
            rigid2D.velocity = Vector2.up * jumpForce;
            currentJumpCount--;
        }
    }
}
