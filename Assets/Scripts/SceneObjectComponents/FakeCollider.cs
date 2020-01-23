using UnityEngine;

public class FakeCollider : MonoBehaviour
{
    private float sizeX;
    private float sizeY;
    private BoxCollider boxCollider;
    private Vector3 originalPosition;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        sizeX = boxCollider.size.x;
        sizeY = boxCollider.size.y;
        originalPosition = transform.position;
    }

    public void SetPositionAndRotation(Vector3 colliderEdgePosition, Vector3 lookAtPosition)
    {
        Vector3 positionWithoutY = colliderEdgePosition + (colliderEdgePosition - lookAtPosition).normalized * sizeX * 0.5f;
        transform.position = new Vector3(positionWithoutY.x, 0f, positionWithoutY.z);
        transform.LookAt(new Vector3(lookAtPosition.x, 0f, lookAtPosition.z));
    }

    public void MoveDown()
    {
        transform.position = originalPosition;
    }
}
