using System;
using UnityEngine;

public class PlantRangeChecker : MonoBehaviour
{
    public Action OnTriggered;

    [SerializeField] private float borderLineXPosition;
    [SerializeField] private Plant plant;
    [SerializeField] private BoxCollider boxCollider;

    private void Start()
    {
        plant.OnPlaced += Plant_OnPlaced;
    }

    private void Plant_OnPlaced(Node placedOnNode)
    {
        boxCollider.size = plant.BoxColliderSize;
        boxCollider.center = plant.BoxColliderCenter;
    }

    private void OnTriggerEnter(Collider collider)
    {
        OnTriggered?.Invoke();
    }
}
