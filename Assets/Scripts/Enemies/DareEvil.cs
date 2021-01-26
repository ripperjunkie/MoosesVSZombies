using UnityEngine;
using System.Collections;

/// <summary>
/// This enemy can attack from near distances
/// </summary>

public class DareEvil : MonsterBase
{
    public DareEvil() : base(100, 15, 1, 3, true, true)
    {

    }
    
    private IEnumerator Attack(TowerBase tower)
    {
        while (true)
        {
            if (tower)
            {
                Debug.Log("<color=green>Attacking</color> from " + gameObject.name);
                tower.TakeDamage(attack);
            }
    
            yield return new WaitForSeconds(attackRate);
        }
    }
    
    protected void OnTriggerEnter(Collider other)
    {
        TowerBase tower = other.gameObject.GetComponent<TowerBase>();

        if (tower)
        {
            StartCoroutine("Attack", tower);
            bCanMove = false;
        }
    }

    protected void OnTriggerExit(Collider other)
    {
        TowerBase tower = other.gameObject.GetComponent<TowerBase>();

        if (tower)
        {
            StopAllCoroutines();
            bCanMove = true;
        }
    }


}
