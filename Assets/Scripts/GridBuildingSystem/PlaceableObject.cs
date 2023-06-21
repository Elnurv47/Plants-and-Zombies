using System;
using UnityEngine;

public class PlaceableObject : MonoBehaviour
{
    public Vector3 LocalScale { get => transform.localScale; }

    private const int ROTATIONDEGREE = 90;

    protected Node placedOnNode;

    [SerializeField] private int xSize;
    [SerializeField] private int ySize;
    [SerializeField] private Transform visualTransform;

    public virtual void Awake()
    {
    }

    public virtual void InvokeOnPlaced(Node placedOnNode)
    {
        this.placedOnNode = placedOnNode;
    }
}
