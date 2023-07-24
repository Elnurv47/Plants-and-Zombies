using System;
using UnityEngine;

public class Plant : PlaceableObject
{
    public Action<Node> OnPlaced;

    private Vector3 boxColliderSize = Vector3.one;
    public Vector3 BoxColliderSize { get => boxColliderSize; set => boxColliderSize = value; }

    private Vector3 boxColliderCenter = Vector3.one;
    public Vector3 BoxColliderCenter { get => boxColliderCenter; set => boxColliderCenter = value; }

    [SerializeField] private PlantRangeChecker plantRangeChecker;

    protected virtual void Start()
    {
        plantRangeChecker.OnTriggered += PlantController_OnTriggered;
    }

    public override void InvokeOnPlaced(Node placedOnNode)
    {
        base.InvokeOnPlaced(placedOnNode);
        OnPlaced?.Invoke(placedOnNode);
    }

    private void PlantController_OnTriggered()
    {
        Debug.Log("Something entered range!");
    }
}
