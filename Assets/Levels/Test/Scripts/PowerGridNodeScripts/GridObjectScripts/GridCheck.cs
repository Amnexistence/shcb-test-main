using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridCheck : MonoBehaviour
{
	
	public GameObject ConnectedObject1;
	public GameObject ConnectedObject2;
	public GameObject ConnectedObject3;
	public GameObject ConnectedObject4;
	public GameObject ConnectedObject5;
	public bool State;
	GridListScript _gls;
	DeviceActionScript _das;
	

    void Awake()
    {
	
	if (ConnectedObject1 != null)
	{
	_gls = ConnectedObject1.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject2 != null)
	{
	_gls = ConnectedObject2.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject3 != null)
	{
	_gls = ConnectedObject3.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject4 != null)
	{
	_gls = ConnectedObject4.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject5 != null)
	{
	_gls = ConnectedObject5.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	_das = transform.parent.GetComponent<DeviceActionScript>();
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
	
	State = transform.parent.GetChild(transform.parent.childCount - 2).gameObject.activeInHierarchy;
	
	if (_das.ConductVar == Convert.ToInt32(!State))
	{
	_das.ConductVar = 0;
	}
	
	if (ConnectedObject1 != null)
	{
	_gls = ConnectedObject1.GetComponent<GridListScript>();
	_gls.GridList.Add(_das.ConductVar);
	ConnectedObject1.transform.GetChild(ConnectedObject1.transform.childCount - 1).gameObject.SetActive(true);
	}
	
	if (ConnectedObject2 != null)
	{
	_gls = ConnectedObject2.GetComponent<GridListScript>();
	_gls.GridList.Add(_das.ConductVar);
	ConnectedObject2.transform.GetChild(ConnectedObject2.transform.childCount - 1).gameObject.SetActive(true);
	}
	
	if (ConnectedObject3 != null)
	{
	_gls = ConnectedObject3.GetComponent<GridListScript>();
	_gls.GridList.Add(_das.ConductVar);
	ConnectedObject3.transform.GetChild(ConnectedObject3.transform.childCount - 1).gameObject.SetActive(true);
	}
	
	if (ConnectedObject4 != null)
	{
	_gls = ConnectedObject4.GetComponent<GridListScript>();
	_gls.GridList.Add(_das.ConductVar);
	ConnectedObject4.transform.GetChild(ConnectedObject4.transform.childCount - 1).gameObject.SetActive(true);
	}
	
	if (ConnectedObject5 != null)
	{
	_gls = ConnectedObject5.GetComponent<GridListScript>();
	_gls.GridList.Add(_das.ConductVar);
	ConnectedObject5.transform.GetChild(ConnectedObject5.transform.childCount - 1).gameObject.SetActive(true);
	}
	
	}

	gameObject.SetActive(false);
		
    
    }
}
