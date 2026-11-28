using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform player;

    [SerializeField] private float moveSpeed;

    [SerializeField, Range(0.01f, 0.1f)]
    private float edgeRatio;

    private bool isScrollHold;

    private void Update()
    {
        bool inputSpace = Input.GetKey(KeyCode.Space);

        if (inputSpace)
            transform.position = player.position + new Vector3(0, 0, -10);

        isScrollHold = inputSpace;

        HandEdgeScroll();
    }

    private void HandEdgeScroll()
    {
        if (isScrollHold)
            return;

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

        // 카메라 이동범위 제한 맵 바깥으로 못나가게
    }
}
