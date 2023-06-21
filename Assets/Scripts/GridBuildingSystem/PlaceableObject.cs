using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public Vector3 LocalScale { get => transform.localScale; }

    protected Node placedOnNode;

    [SerializeField] private int xSize;
    [SerializeField] private int ySize;
    [SerializeField] private Transform visualTransform;

    public virtual void InvokeOnPlaced(Node placedOnNode)
    {
        this.placedOnNode = placedOnNode;
    }
}
