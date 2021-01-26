using UnityEngine;
using System.Collections;

/// <summary>
/// This tower attack the first monster in front of it
/// </summary>

public class TowerLongRange : TowerBase
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
                    //Debug.Log("Tower is attacking");
                    EnemyData().gameObject.GetComponent<MonsterBase>().TakeDamage(attack);
                }
            }
            yield return new WaitForSeconds(attackRate);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }

}
