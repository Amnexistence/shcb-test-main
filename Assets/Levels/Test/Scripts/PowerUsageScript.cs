using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUsageScript : MonoBehaviour
{
	//public GameObject MySwitch;
	//SwitchScript _ss;
	public int PowerUsage;
	//public bool State;
	
	public GameObject PowerSource;
	
	public GameObject ConductObject;
	
	public int DevicesCount;
	public int DeviceCounter;
	private int WasDevicesOn;
	
	PowerSourceScript _pss;
	
	void Awake()
	{
	_pss = PowerSource.GetComponent<PowerSourceScript>();	
	}
	
    void OnEnable()
    {
	//transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
	}

	void OnDisable()
    {
	//transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);
	}

	public void ConductCheck()
	{
	//if (ConductObject.transform.GetChild(transform.childCount - 1).gameObject.activeInHierarchy == true)	
	if (WasDevicesOn == DevicesCount)
	{
	PowerReduce();
	}


	if (DeviceCounter == DevicesCount)
	{
	transform.GetChild(transform.childCount - 1).gameObject.SetActive(true);
	PowerIncrease();
	}
	else
	{
	transform.GetChild(transform.childCount - 1).gameObject.SetActive(false);	
	}
	WasDevicesOn = DeviceCounter;
	}

	public void PowerReduce()
	{
	_pss.CurrentPower = _pss.CurrentPower - PowerUsage;		
	}
	
	public void PowerIncrease()
	{
	_pss.CurrentPower = _pss.CurrentPower + PowerUsage;		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}

