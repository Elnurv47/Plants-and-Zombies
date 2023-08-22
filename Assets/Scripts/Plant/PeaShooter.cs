using UnityEngine;

public class PeaShooter : Plant
{
    private const int PLANT_LOCATED_CELL_SIZE = 2;

    [SerializeField] private float borderLineXPosition;
    [SerializeField] private Bullet bulletPrefab;

    private void Start()
    {
        OnPlaced += Plant_OnPlaced;
    }

    private float timer;
    private float maxTimer = 2f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer > maxTimer)
        {
            timer = 0;
            TryAttack();
        }
    }

    private void Plant_OnPlaced(Node placedNode) { }

    private void TryAttack()
    {
        if (plantLongRangeChecker.HasAttackTarget)
        {
            Vector3 locatedNodeCenterOffset = new Vector3(PLANT_LOCATED_CELL_SIZE / 2, 0, PLANT_LOCATED_CELL_SIZE / 2);
            Spawner.Spawn(bulletPrefab, transform.position + locatedNodeCenterOffset, Quaternion.identity);
        }
    }
}
