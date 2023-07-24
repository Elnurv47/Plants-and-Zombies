using UnityEngine;

public class PeaShooter : Plant
{
    private const int PLANT_LOCATED_CELL_SIZE = 2;

    [SerializeField] private float borderLineXPosition;

    protected override void Start()
    {
        base.Start();
        OnPlaced += Plant_OnPlaced;
    }

    private void Plant_OnPlaced(Node placedNode)
    {
        float distanceToBorderLine = borderLineXPosition - transform.position.x;
        BoxColliderSize = new Vector3(distanceToBorderLine, 1, PLANT_LOCATED_CELL_SIZE - 0.2f);

        float boxColliderCenteredXPosition = distanceToBorderLine / 2;
        BoxColliderCenter = new Vector3(boxColliderCenteredXPosition, 1, 1);
    }
}
