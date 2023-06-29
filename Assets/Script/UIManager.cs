using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public  bool placingCage; 
    public bool placingMine;
    public Tile tile;
    public CageData cageData;
    public MineData mineData;

    private void Start()
    {
        tile = Tile.instance;
    }
    public void OnCageButtonClicked()
        {
          placingCage = true;
          placingMine = false;
        }

    public void OnMineButtonClicked()
    {
        placingCage = false;
        placingMine = true;
    }
    public void OnclickDestroy()
    {
        GameObject[] gameobjectscage = GameObject.FindGameObjectsWithTag("Cage");
        foreach(GameObject gameobject in gameobjectscage)
        {
            Destroy(gameobject);
        }
        GameObject[] gameobjectsmine = GameObject.FindGameObjectsWithTag("Mine");
        foreach(GameObject gameobject in gameobjectsmine)
        {
            Destroy(gameobject);
        }

       
    }

    public void SaveData()
    {
        SaveSystem.SaveData(tile);



    }
    public void LoadData()
    {
        GameData data = SaveSystem.loadGameData();

        for (int i = 0; i < data._cageposition.Length; i += 3)
        {
            Vector3 cagePosition = new Vector3(data._cageposition[i], data._cageposition[i + 1], data._cageposition[i + 2]);


            GameObject cageObject = Instantiate(cageData._prefab, cagePosition, Quaternion.identity); 
            
        }

        for (int i = 0; i < data._mineposition.Length; i += 3)
        {
            Vector3 minePosition = new Vector3(data._mineposition[i], data._mineposition[i + 1], data._mineposition[i + 2]);

            
            GameObject mineObject = Instantiate(mineData._prefab, minePosition, Quaternion.identity);
           
        }

    }


}
