using UnityEngine;

public abstract class MonsterBase : MonoBehaviour
{
    [Space(5)]
    [Header("General attributes")]
    [SerializeField] protected float currentHealth;
    [SerializeField] protected float attack;
    [SerializeField] protected int attackRate;
    [SerializeField] protected float movementSpeed;
    [SerializeField] protected bool bCanAttack;
    [SerializeField] protected bool bCanMove;

    [Space (5)]
    [Header ("Object references")]
    [SerializeField] protected Color initColor;
    [SerializeField] protected LayerMask layerMask;
    [SerializeField] protected GeneralHUD generalHUD;

    [Space(5)]
    [Header("Debug properties")]
    public float timer;
    public Spawner spawner;

    protected MonsterBase(float _currentHealth, float _attack, int _attackRate, float _movementSpeed,  bool _bCanAttack, bool _bCanMove)
    {
        currentHealth = _currentHealth;
        attack = _attack;
        attackRate = _attackRate;
        movementSpeed = _movementSpeed;
        bCanAttack = _bCanAttack;
        bCanMove = _bCanMove;

        initColor = new Color();
        layerMask = new LayerMask();
        generalHUD = null;
        attackRate = 2;
    }

    protected void OnEnable() => bCanMove = true;

    protected void OnDisable()
    {
        if(spawner)
            transform.position = spawner.ChooseRandomLocation();
    } 

    protected void Update()
    {
        Move();
        CheckIsDead();
        generalHUD.UpdateHealth(currentHealth);
        timer -= Time.deltaTime;
    }

    public float TakeDamage(float _damage)
    {
        return currentHealth -= _damage;
    }

    protected void Move()
    {
        if (CanMove())
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
    }

    protected void CheckIsDead()
    {
        if (currentHealth <= 0)
        {           
            gameObject.SetActive(false);
            PullMonsters pullMonster = gameObject.GetComponent<PullMonsters>();
            
            bCanMove = false;
        }
    }

    public void TemporarilyStopMovement(float _timer)
    {
        timer = _timer;
    }

    protected bool CanMove()
    {
        if(timer <= 0 && bCanMove)
        {
            return true;
        }
        return false;
    }


}
