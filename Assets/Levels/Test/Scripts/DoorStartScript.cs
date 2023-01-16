using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStartScript : MonoBehaviour
{
	
	GridListScript _gls;
	DeviceActionScript _das;
	
	//public int PowerUsage;
	private int PresentState;
	private int PastState;
	private GameObject PowerSource;
	PowerSourceScript _pss;
	DoorDriverScript _dds;
	
    // Start is called before the first frame update
    void Awake()
    {
	_gls = transform.parent.GetComponent<GridListScript>();
    _das = transform.parent.GetComponent<DeviceActionScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
	
		
	
	
	if (_gls.GridList.Count == _gls.GridCount)
	{
	//_gls = transform.parent.GetComponent<GridListScript>();
	//_das = transform.parent.GetComponent<DeviceActionScript>();
	//transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(false);		
	for(int i = 0; i < _gls.GridList.Count; i++)	
	{
	if (_gls.GridList[i] == 1)
	{
	_das.ConductVar = 1;
	}
	/*
	if ((_das.ConductVar == 1) && (i == (_gls.GridList.Count - 1)))
	{
		
	if (transform.parent.GetChild(transform.parent.childCount - 2).gameObject.activeInHierarchy == true)
	{
	_dds = transform.parent.GetChild(transform.parent.childCount - 2).GetComponent<DoorDriverScript>();
	_dds.DoorWork();
	}
	
	if (transform.parent.GetChild(transform.parent.childCount - 3).gameObject.activeInHierarchy == true)
	{
	_dds = transform.parent.GetChild(transform.parent.childCount - 3).GetComponent<DoorDriverScript>();
	_dds.DoorWork();
	}	
	
	}
	*/
	}	
	
	//foreach (int i in _gls.GridList)
	//{
	//if (i == 1)
	//{
	//
	//_das.ConductVar = 1;
	//	
	//}
	//}
	
	
	
	//transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(true);
	/*
	State = transform.parent.GetChild(transform.parent.childCount - 2).gameObject.activeInHierarchy;
	
	if (_das.ConductVar == Convert.ToInt32(!State))
	{
	_das.ConductVar = 0;
	}
	
	PresentState = _das.ConductVar;
	
	if ((PresentState != PastState) && ())
	{
	if (PresentState == 1)
	{
		if ((_pss.CurrentPower + PowerUsage) <= _pss.TotalPower)
		{
		transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(true);
		transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(false);
		}
		else
		{
		transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(false);	
		transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(true);	
		}
	}
	else
	{
		
	if (transform.parent.GetChild(transform.parent.childCount - 2).gameObject.activeInHierarchy == true)
	{
	transform.parent.GetChild(transform.parent.childCount - 2).gameObject.SetActive(false);		
	transform.parent.GetChild(transform.parent.childCount - 3).gameObject.SetActive(true);		
	//_das.UISignal(_das.DeviceOrderIndex);
	}
	}
	
	}
	
	PastState = PresentState;
	*/
	
	}
	//else
	//{
	gameObject.SetActive(false);
	//}
		
    
    }
	
}
