using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridListScript : MonoBehaviour
{
	public GameObject PowerSource;
	[HideInInspector]
	public List<int> GridList;
	[HideInInspector]
	public int GridCount;
	DeviceActionScript _das;
	
    void Awake()
    {
     GridList = new List<int>();
	_das = gameObject.GetComponent<DeviceActionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
        PowerSourceScript.ActionResetGrid += ResetGrid;
    }

    private void OnDisable()
    {
        PowerSourceScript.ActionResetGrid -= ResetGrid;
    }
	
	 private void ResetGrid()
    {
    GridList.Clear();
	transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
	_das.ConductVar = 0;
    }
}
