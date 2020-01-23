using UnityEngine;

public class SetRenderQueue : MonoBehaviour
{
    [SerializeField]
    protected int[] queues = new int[] { 3000 };

    protected void Awake()
    {
        Material[] materials = GetComponent<Renderer>().materials;
        for (int i = 0; i < materials.Length && i < queues.Length; ++i)
        {
            materials[i].renderQueue = queues[i];
        }
    }
}
