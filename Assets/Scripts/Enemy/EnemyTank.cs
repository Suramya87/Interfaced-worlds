using UnityEngine;

public class EnemyTank : Enemy
{
    void Awake()
    {
        enemyType = EnemyType.Tank;
        maxHealth = 50; 
    }

    public override void OnSpawn(Vector3 position)
    {
        base.OnSpawn(position);
    }

    protected override void Die()
    {
        GameManager.Instance.AddPoints(2, "TANK");


        base.Die();
    }
}
