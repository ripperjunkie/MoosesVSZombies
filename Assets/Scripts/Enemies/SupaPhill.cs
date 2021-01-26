using UnityEngine;

/// <summary>
/// This enemy attacks only once and give a significant amount of damage to the tower (it EXPLODES!)
/// </summary>

public class SupaPhill : MonsterBase
{
    [Space (5)]
    [Header ("Specific attributes")]
    [SerializeField] private float minAttackDamage;

    public SupaPhill() : base(100, 15, 1, 3, true, true)
    {

    }

    protected void OnTriggerEnter(Collider other)
    {
        TowerBase tower = other.gameObject.GetComponent<TowerBase>();     
        
        if (tower)
        {
            tower.TakeDamage(Random.Range(minAttackDamage, attack));
            bCanMove = false;
            gameObject.SetActive(false);
        }

    }
}
