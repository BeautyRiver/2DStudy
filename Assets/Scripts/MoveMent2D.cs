using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class MoveMent2D : MonoBehaviour
{
    [SerializeField]
    private float speed = 5.0f; // �÷��̾� �̵��ӵ�
    [SerializeField]
    private float jumpForce = 8.0f;
    private Rigidbody2D rigid2D;    
    public bool isLongJump = false;

    [SerializeField]
    private LayerMask groundLayer; // �ٴ� üũ�� ���� ���̾�
    private CircleCollider2D circleCollider2D; 
    private bool isGrounded; // �ٴ� üũ
    private Vector3 footPostion; // ���� ��ġ

    [SerializeField]
    private int maxJumpCount = 2; // �ִ� ���� Ƚ��
    private int currentJumpCount = 0; // ���� ������ ���� Ƚ��

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

        // ���� ����, ���� ����
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
