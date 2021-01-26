using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private PlayerControl playerControl;
    public Vector3 tilePos;
    public bool bCanPlace;

    private PlayerInput()
    {
        playerControl = null;
        bCanPlace = false;
    }

    private void Awake()
    {
        playerControl = new PlayerControl();
    }

    private void OnEnable()
    {
        playerControl.Enable();
    }

    private void OnDisable()
    {
        playerControl.Disable();
    }

    private void OnClick()
    {
        float interactMouseValue = playerControl.Terrain.Interact.ReadValue<float>();
        
        if (interactMouseValue > 0)
        {
            Vector2 screenPos = Mouse.current.position.ReadValue();
            Vector3 worldPos = new Vector3(screenPos.x, screenPos.y, 0f);
            Ray myRay = Camera.main.ScreenPointToRay(worldPos);
            RaycastHit hit;

            if (Physics.Raycast(myRay, out hit))
            {
                Tiles tiles = hit.collider.GetComponent<Tiles>();
                if (tiles)
                {
                    bCanPlace = !tiles.bTileOccupied;
                    tilePos = tiles.transform.position;                    
                }
                
            }
        }
    }

    private void Update()
    {
        OnClick();
    }
      
}
