using UnityEngine;

public class DefaultStaff : Staff
{
    protected Camera mainCamera;

    protected override void Start()
    {
        base.Start();
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    protected override void UseStaff()
    {
        base.UseStaff();
    }

    protected override Vector2 CalculateBulletVelocity(GameObject bullet, Vector2 targetPosition)
    {
        return base.CalculateBulletVelocity(bullet, targetPosition);
    }

    protected override Vector2 CalculateTargetPosition() {
        Vector3 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = (Vector2)mousePos;

        return targetPosition;
    }
}
