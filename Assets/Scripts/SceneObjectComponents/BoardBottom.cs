using UnityEngine;

public class BoardBottom : MonoBehaviour
{
    private MeshCollider mCollider;

    private void Start()
    {
        mCollider = GetComponent<MeshCollider>();
    }

    public void ActivateCollider()
    {
        mCollider.enabled = true;
    }

    public void DeactivateCollider()
    {
        mCollider.enabled = false;
    }
}
