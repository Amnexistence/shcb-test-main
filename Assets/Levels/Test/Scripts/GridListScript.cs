using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GridListScript : MonoBehaviour
{
	[HideInInspector]
	public List<int> GridList;
	
	public GameObject PowerSource;
	//PowerSourceScript _pss;
	
	//public GameObject GridObject;
	
	[HideInInspector]
	public int GridCount;
	
	DeviceActionScript _das;
	
    // Start is called before the first frame update
    void Awake()
    {
     GridList = new List<int>();
	//_pss = PowerSource.GetComponent<PowerSourceScript>();
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
	// обнулять conduct var в device action?
    }
}
