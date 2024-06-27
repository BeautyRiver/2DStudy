using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    Vector3 mousePosition;
    public LayerMask platform;

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Collider2D overCollider2d = Physics2D.OverlapCircle(mousePosition, 0.01f, platform);
            if(overCollider2d != null)
            {
                overCollider2d.transform.GetComponent<Bricks>().MakeDot(mousePosition);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(mousePosition, 0.2f);

    }
}
