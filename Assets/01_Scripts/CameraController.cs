using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField, Range(0.01f, 0.1f)]
    private float edgeRatio;

    private void Update()
    {
        HandEdgeScroll();
    }

    private void HandEdgeScroll()
    {
        float edgeX = Screen.width * edgeRatio;
        float edgeY = Screen.height * edgeRatio;

        Vector2 mousePos = Input.mousePosition;
        Vector2 moveDir = Vector2.zero;

        if (mousePos.x >= Screen.width - edgeX)
            moveDir.x = 1f;
        else if (mousePos.x <= edgeX)
            moveDir.x = -1f;

        if (mousePos.y >= Screen.height - edgeY)
            moveDir.y = 1f;
        else if (mousePos.y <= edgeY)
            moveDir.y = -1f;

        transform.position += (Vector3)moveDir.normalized * moveSpeed * Time.deltaTime;
    }
}
