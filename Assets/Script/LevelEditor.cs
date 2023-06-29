using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelEditor : MonoBehaviour
{

    public static LevelEditor Instance { get; private set;}
    public CageData cageData;
    public MineData mineData;

    public UnityEvent<Vector3> onCaptureCagePlaced;
    public UnityEvent<Vector3> onMinePlaced;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            foreach (Vector3 vec in Tile._cagepos)
                Debug.Log(vec);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            foreach(Vector3 vec in Tile._minepos)
                Debug.Log(vec);

        }
    }
    public void Awake()
    {
        if(Instance != null&& Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        
    }
    public void PlaceCaptureCage(Vector3 position)
    {
        
        GameObject captureCagePrefab = cageData._prefab; 
        GameObject captureCageInstance = Instantiate(captureCagePrefab, position, Quaternion.identity);
        
       
        onCaptureCagePlaced?.Invoke(position);
    }

    public void PlaceMine(Vector3 position)
    {
        
        GameObject minePrefab = mineData._prefab; 
        GameObject mineInstance = Instantiate(minePrefab,position, Quaternion.identity);

        
        onMinePlaced?.Invoke(position);
    }

    public void DestroyHurdles()
    {
        Debug.Log("qwerty");
        Destroy(gameObject);
    }
  
}


