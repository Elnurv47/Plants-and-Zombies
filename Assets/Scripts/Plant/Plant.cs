﻿using System;
using UnityEngine;

public class Plant : PlaceableObject
{
    public Action<Node> OnPlaced;

    private Vector3 boxColliderCenter = Vector3.one;
    public Vector3 BoxColliderCenter { get => boxColliderCenter; set => boxColliderCenter = value; }

    [SerializeField] protected PlantLongRangeChecker plantLongRangeChecker;

    public override void InvokeOnPlaced(Node placedOnNode)
    {
        base.InvokeOnPlaced(placedOnNode);
        OnPlaced?.Invoke(placedOnNode);
    }
}
