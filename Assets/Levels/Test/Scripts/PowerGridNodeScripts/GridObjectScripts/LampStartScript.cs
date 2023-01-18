using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampStartScript : MonoBehaviour
{
	private GameObject PowerSource;
	public int PowerUsage;
	private int PresentState;
	private int PastState;
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
	
	PresentState = _das.ConductVar;
	
	if (PresentState != PastState)
	{
	if (PresentState == 1)
	{
		if ((_pss.CurrentPower + PowerUsage) <= _pss.TotalPower)
		{
		transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(true);
		_pss.CurrentPower += PowerUsage;
		}
		else
		{
		transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(false);	
		}
	}
	else
	{
		
	if (transform.parent.GetChild(transform.parent.childCount - 2).gameObject.activeInHierarchy == true)
	{
	transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(false);		
	_pss.CurrentPower -= PowerUsage;
	}
	}
	
	}
	
	PastState = PresentState;
	
	}

	gameObject.SetActive(false);	
    
    }
	
}
