using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStartScript : MonoBehaviour
{
	private GameObject PowerSource;
	public int PowerUsage;
	GridListScript _gls;
	DeviceActionScript _das;
	PowerSourceScript _pss;
	
    
    void Awake()
    {
    _das = transform.parent.GetComponent<DeviceActionScript>();
	PowerSource = transform.parent.GetComponent<GridListScript>().PowerSource;
	_pss = PowerSource.GetComponent<PowerSourceScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
	_gls = transform.parent.GetComponent<GridListScript>();
	
	if (_gls.GridList.Count == _gls.GridCount)
	{
	
	foreach (int i in _gls.GridList)
	{
	if (i == 1)
	{
	_das.ConductVar = 1;
	}
	}
	
	}

	gameObject.SetActive(false);
		
    
    }
	
}
