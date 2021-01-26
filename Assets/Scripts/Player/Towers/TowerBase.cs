using UnityEngine;

public abstract class TowerBase : MonoBehaviour
{
    [Header("Gameplay control")]
    public bool bCanAttack;
    public Tiles tiles;
    public Vector3 initPos;

    [Header("General attributes")]
    [SerializeField] protected float health;
    [SerializeField] protected float attack;
    [SerializeField] protected float attackRate;

    [Header("Object references")]
    [SerializeField] protected GeneralHUD generalHUD;
    [SerializeField] protected Color color;
    [SerializeField] protected LayerMask layerMask;
    
    [Header("Debug properties")]
    [SerializeField] protected float rayLength;
    
    public TowerBase()
    {
        rayLength = 10f;
        initPos = new Vector3();
        tiles = null;
    }

    protected void OnEnable() => bCanAttack = true;

    protected void Update()
    {
        CheckIsDead();

        if(generalHUD)
            generalHUD.UpdateHealth(health);
    }    

    protected void CheckIsDead()
    {
        if (health <= 0)
            gameObject.SetActive(false);
    }

    public float TakeDamage(float _damage)
    {
        return health -= _damage;
    }

    protected virtual Collider EnemyData()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit, rayLength, layerMask))
            return hit.collider;
                      
        return null;       
    }

    private void OnTriggerStay(Collider other)
    {
        Tiles tileRef = other.gameObject.GetComponent<Tiles>();
        if (tileRef)
        {
            if (!tileRef.bTileOccupied)
                tiles = tileRef;
        }
    }

    public void MouseClick()
    {
        bCanAttack = false;
        if (tiles)
            tiles.bTileOccupied = false;

        tiles = null;
    }

}
