using UnityEngine;

/// <summary>
/// This class contains tile detection and process functionality to check the current state of tile
/// If tower can be placed, spawned etc
/// </summary>
public class Tiles : MonoBehaviour
{
    public bool bTileOccupied;

    [SerializeField] private TowerBase tower;

    private Color startColor;
    private PlayerManager playerManager;
            
    public Tiles()
    {
        bTileOccupied = false;        
    }

    private void Awake()
    {
        startColor = gameObject.GetComponent<Renderer>().material.color;
        playerManager = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
    }

    public void OnPointerClick()
    {
        if (playerManager.towerPrefabs.Count > 0 && !bTileOccupied)
        {
            tower = playerManager.PullTowerFromList(gameObject.transform.position);            
            if (tower)
            {
                bTileOccupied = true;
                tower.initPos = gameObject.transform.position;
                tower.tiles = gameObject.GetComponent<Tiles>();
                gameObject.GetComponent<Renderer>().material.color = startColor;
            }
        }
    }

    public void OnPointerEnter()
    {
        if (!bTileOccupied)
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

    public void OnPointerExit() => gameObject.GetComponent<Renderer>().material.color = startColor;
}
