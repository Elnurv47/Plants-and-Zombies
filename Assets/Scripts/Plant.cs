using System;
using UnityEngine;

public class Plant : PlaceableObject
{
    public Action<Node> OnPlaced;

    private Vector3 boxColliderCenter = Vector3.one;
    public Vector3 BoxColliderCenter { get => boxColliderCenter; set => boxColliderCenter = value; }

    [SerializeField] private PlantLongRangeChecker plantLongRangeChecker;

    protected virtual void Start()
    {
        plantLongRangeChecker.OnTriggered += PlantRangeChecker_OnTriggered;
    }

    public override void InvokeOnPlaced(Node placedOnNode)
    {
        base.InvokeOnPlaced(placedOnNode);
        OnPlaced?.Invoke(placedOnNode);
    }

    private void PlantRangeChecker_OnTriggered()
    {
        Debug.Log("Something entered range!");
        Attack();
    }

    protected virtual void Attack()
    {
        Debug.Log("Attacking");
    }
}
