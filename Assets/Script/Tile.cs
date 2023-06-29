using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tile : MonoBehaviour
{
    public static Tile instance;
    [SerializeField] private Material _base, _offset;
    [SerializeField] private MeshRenderer _meshRenderer;

    [SerializeField] private GameObject _highlight;
    private LevelEditor _leveleditor;
    [SerializeField] private Vector3 _extra;
    private UIManager _uimanger;
    [SerializeField]public static List<Vector3> _cagepos = new List<Vector3>();
    [SerializeField]public static List<Vector3> _minepos = new List<Vector3>(); 
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        _uimanger = GameObject.FindObjectOfType<UIManager>();
        _leveleditor = LevelEditor.Instance;
        _leveleditor.onCaptureCagePlaced.AddListener(OnCaptureCagePlaced);
        _leveleditor.onMinePlaced.AddListener(OnMinePlaced);
        

    }
    public static void AddItemCage(Vector3 item)
    {
        _cagepos.Add(item);
    }
    public static void AddItemMine(Vector3 item)
    {
        _minepos.Add(item);
    }
    public void Init(bool offset)
    {
        _meshRenderer.material = offset ? _offset : _base;
    }

    private void OnMouseEnter ()
    {
        _highlight.SetActive(true);
        
    }
    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_uimanger.placingCage)
            { 
                var position = gameObject.transform.position + _extra; 
                _leveleditor.PlaceCaptureCage(position);
                AddItemCage(position);
                
            }
            else if (_uimanger.placingMine)
            {
                var position = gameObject.transform.position + _extra;
                _leveleditor.PlaceMine(position);
                AddItemMine(position);
                
                
            }
        }
       

    }
    private void OnMouseExit()
    {
        _highlight.SetActive(false);
    }
    private void OnCaptureCagePlaced(Vector3 position)
    {
        Debug.Log("Event"+"Cage");
        
    }
    private void OnMinePlaced(Vector3 position)
    {
        Debug.Log("Event" + "Mine");
        
    }

    private void OnDisable()
    {
        _leveleditor.onCaptureCagePlaced.RemoveListener(OnCaptureCagePlaced);
        _leveleditor.onCaptureCagePlaced.RemoveListener(OnMinePlaced);
    }

}
