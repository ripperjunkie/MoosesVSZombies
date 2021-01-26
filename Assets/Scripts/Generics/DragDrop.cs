using UnityEngine;

public class DragDrop : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private TowerBase tower;
    [SerializeField] private Color initialGOColor;

    private PlayerControl inputActions;

    public DragDrop()
    {
        playerInput = null;
        initialGOColor = new Color();
    }

    private void Awake()
    {
        playerInput = GameObject.Find("PlayerManager").GetComponent<PlayerInput>();
        inputActions = new PlayerControl();
        tower = gameObject.GetComponent<TowerBase>();
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public void MouseDrag()
    {       
        if (playerInput)
        {
            //transform.position = playerInput.tilePos;
            Vector3 newPos = new Vector3(playerInput.tilePos.x, transform.position.y, playerInput.tilePos.z);
            transform.position = newPos;
        }
    }

    public void MouseDrop()
    {
        tower.bCanAttack = true;
        if (!playerInput.bCanPlace)
        {
            Vector3 newPos = new Vector3(tower.initPos.x, transform.position.y, tower.initPos.z);
            transform.position = newPos;
            if (tower.tiles)
            {
                tower.tiles.bTileOccupied = true;
            }
        }
        else
        {
            tower.initPos = playerInput.tilePos;
            if (tower.tiles)
            {
                tower.tiles.bTileOccupied = true;
            }
        }

    }


}
