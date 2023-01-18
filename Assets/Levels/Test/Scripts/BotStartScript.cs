using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotStartScript : MonoBehaviour
{
	
	GridListScript _gls;
	DeviceActionScript _das;
	
	public int PowerUsage;
	private GameObject PowerSource;
	PowerSourceScript _pss;
	
    // Start is called before the first frame update
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
	
		
	//for(int i = 0; i < _gls.GridList.Count; i++)	
	//{
	//if (_gls.GridList[i] == 1)
	//{
	//_das.ConductVar = 1;
	//}
	//}
	
	foreach (int i in _gls.GridList)
	{
	if (i == 1)
	{
	_das.ConductVar = 1;
	}
	}
	
	
	
	}
	//else
	//{
	gameObject.SetActive(false);
	//}
		
    
    }
	
}
