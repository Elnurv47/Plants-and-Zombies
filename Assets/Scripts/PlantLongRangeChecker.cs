using System;
using UnityEngine;

public class PlantLongRangeChecker : MonoBehaviour
{
    private const int PLANT_LOCATED_CELL_SIZE = 2;

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
        float distanceToBorderLine = borderLineXPosition - transform.position.x;
        boxCollider.size = new Vector3(distanceToBorderLine, 1, PLANT_LOCATED_CELL_SIZE - 0.2f);

        float boxColliderCenteredXPosition = distanceToBorderLine / 2;
        boxCollider.center = new Vector3(boxColliderCenteredXPosition, 1, 1);
    }

    private void OnTriggerEnter(Collider collider)
    {
        OnTriggered?.Invoke();
    }
}
