using System;
using UnityEngine;

public class PlantLongRangeChecker : MonoBehaviour
{
    private const int PLANT_LOCATED_CELL_SIZE = 2;

    public Action OnTriggered;

    private bool hasAttackTarget;
    public bool HasAttackTarget { get => hasAttackTarget; }

    [SerializeField] private float borderLineXPosition;
    [SerializeField] private Plant plant;
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private LayerMask zombieLayerMask;

    private void Start()
    {
        plant.OnPlaced += Plant_OnPlaced;
    }

    private void Plant_OnPlaced(Node placedOnNode)
    {
        float distanceToBorderLine = borderLineXPosition - transform.position.x;
        boxCollider.size = new Vector3(distanceToBorderLine, 1, PLANT_LOCATED_CELL_SIZE - 0.2f);

        float boxColliderCenteredXPosition = distanceToBorderLine / 2;
        boxCollider.center = new Vector3(boxColliderCenteredXPosition, 1, 1);
    }

    private void Update()
    {
        Collider[] collidersInRange = 
            Physics.OverlapBox(
                transform.TransformPoint(boxCollider.center), boxCollider.size / 2, Quaternion.identity, zombieLayerMask);
        hasAttackTarget = collidersInRange.Length > 0;
    }
}
