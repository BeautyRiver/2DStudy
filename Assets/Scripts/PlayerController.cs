using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private MoveMent2D moveMent2D;
    private void Awake()
    {
        moveMent2D = GetComponent<MoveMent2D>();
    }

    private void Update()
    {
        // �÷��̾� �̵�
        float x = Input.GetAxisRaw("Horizontal");
        moveMent2D.Move(x);

        // �÷��̾� ����
        if(Input.GetKeyDown(KeyCode.Space))
        {
            moveMent2D.Jump();
        }

        if (Input.GetKey(KeyCode.Space))
        {
            moveMent2D.isLongJump = true;
        }

        else if(Input.GetKeyUp(KeyCode.Space))
        {
            moveMent2D.isLongJump = false;
        }
    }
 
}
