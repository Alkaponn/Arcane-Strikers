using UnityEngine;

public class DefaultStaff : Staff
{
    private Camera mainCamera;

    protected override void Start()
    {
        base.Start();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    protected override Vector2 CalculateTargetPosition() {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = (Vector2)mousePos;

        return targetPosition;
    }
}
