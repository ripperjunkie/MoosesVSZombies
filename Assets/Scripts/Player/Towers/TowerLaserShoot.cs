using UnityEngine;
using System.Collections;

/// <summary>
/// This tower shoots out a laser and attack every monster in sight
/// </summary>

public class TowerLaserShoot : TowerBase
{
    private void Start()
    {
        StartCoroutine("Attack");
    }

    private IEnumerator Attack()
    {
        while (true)
        {
            RaycastHit[] hits;
            hits = Physics.RaycastAll(transform.position, transform.forward, rayLength, layerMask);

            for (int i = 0; i < hits.Length; i++)
            {
                MonsterBase monster = hits[i].collider.gameObject.GetComponent<MonsterBase>();
                if (monster)
                {
                    if(bCanAttack)
                        monster.TakeDamage(attack);
                }
                else { Debug.Log("Whops"); }
            }
            yield return new WaitForSeconds(attackRate);
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawRay(transform.position, transform.forward * rayLength);
    }
}
