using System.Collections;
using UnityEngine;

public class TowerFreezer : TowerBase
{
    private void Start()
    {
        StartCoroutine("Attack");
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            if (EnemyData())
            {
                if (bCanAttack)
                {
                   // Debug.Log("Tower is attacking");
                    EnemyData().gameObject.GetComponent<MonsterBase>().TemporarilyStopMovement(3);
                }
            }
            yield return new WaitForSeconds(attackRate);
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;

        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }
}
