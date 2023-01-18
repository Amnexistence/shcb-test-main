using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStartScript : MonoBehaviour
{
	private GameObject PowerSource;
	private int PresentState;
	private int PastState;
	GridListScript _gls;
	DeviceActionScript _das;
	PowerSourceScript _pss;
	DoorDriverScript _dds;
	
   
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
		for(int i = 0; i < _gls.GridList.Count; i++)	
		{
		if (_gls.GridList[i] == 1)
		{
		_das.ConductVar = 1;
		}
		}	
	}

	gameObject.SetActive(false);

		
    
    }
	
}
