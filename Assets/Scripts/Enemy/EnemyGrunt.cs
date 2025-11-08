using UnityEngine;

public class EnemyGrunt : Enemy
{
    void Awake()
    {
        enemyType = EnemyType.Grunt;
        maxHealth = 50; 
    }

    public override void OnSpawn(Vector3 position)
    {
        base.OnSpawn(position);
    }

    protected override void Die()
    {
        GameManager.Instance.AddPoints(1, "GRUNT");


        base.Die();
    }
}
