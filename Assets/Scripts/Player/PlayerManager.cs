using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Row
{
    public List<GameObject> rowData;
}

public class PlayerManager : MonoBehaviour
{
    [Header ("General attributes")]
    public List<GameObject> towerPrefabs;
    public List<int> inventory;    

    [SerializeField] private float yOffset;
    [SerializeField] private int selectObjecIndex;

    [SerializeField] private Row[] row;
    [SerializeField] private GameObject[] selectableGO;
    private PlayerManager()
    {
        yOffset = 1.5f;
        row = new Row[3];
    } 

    private void Awake() => ChangeColorOnSelected();

    public TowerBase PullTowerFromList(Vector3 _location)
    {
        if (inventory[selectObjecIndex] > 0)
        {
            TowerBase tower = row[selectObjecIndex].rowData[inventory[selectObjecIndex]].GetComponent<TowerBase>();
            tower.transform.position = new Vector3(_location.x, _location.y + yOffset, _location.z);
            row[selectObjecIndex].rowData[inventory[selectObjecIndex]].SetActive(true);

            if (selectObjecIndex >= 0 && selectObjecIndex <= towerPrefabs.Count - 1)
                inventory[selectObjecIndex]--;
                return tower;
        }

        return null;
    }

    public void SelectObject(int _index)
    {
        selectObjecIndex = _index;        
    }

    public void ChangeColorOnSelected()
    {
        for (int i = 0; i < selectableGO.Length; i++)
        {
            selectableGO[selectObjecIndex].GetComponent<Renderer>().material.color = Color.red;
            if(i != selectObjecIndex)      
                selectableGO[i].GetComponent<Renderer>().material.color = Color.white;
        }
    }

    public void PlaceObjectList(GameObject go, int index)
    {
        row[index].rowData.Add(go);   
    }

}
