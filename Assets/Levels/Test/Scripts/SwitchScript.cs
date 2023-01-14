using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
	public GameObject PowerSource;
	PowerSourceScript _pss;
	public GameObject ConnectedObject1;
	public GameObject ConnectedObject2;
	public GameObject ConnectedObject3;
	public GameObject ConnectedObject4;
	public GameObject ConnectedObject5;
	PowerUsageScript _pus1, _pus2, _pus3, _pus4, _pus5;
	
	public int ConductedPower;
	[HideInInspector]
	public bool State;
	
	[HideInInspector]
	public int isCharged;
	
    // Start is called before the first frame update
    void Awake()
    {
	_pss = PowerSource.GetComponent<PowerSourceScript>();
	
	if (ConnectedObject1 != null)
	{
	_pus1 = ConnectedObject1.GetComponent<PowerUsageScript>();
	_pus1.DevicesCount += 1;
	}
	if (ConnectedObject2 != null)
	{
	_pus2 = ConnectedObject2.GetComponent<PowerUsageScript>();
	_pus2.DevicesCount += 1;
	}
	if (ConnectedObject3 != null)
	{
	_pus3 = ConnectedObject3.GetComponent<PowerUsageScript>();
	_pus3.DevicesCount += 1;
	}
	if (ConnectedObject4 != null)
	{
	_pus4 = ConnectedObject4.GetComponent<PowerUsageScript>();
	_pus4.DevicesCount += 1;
	}
	if (ConnectedObject5 != null)
	{
	_pus5 = ConnectedObject5.GetComponent<PowerUsageScript>();
	_pus5.DevicesCount += 1;
	}
	
	}
	
	public void SwitchOn()
	{
	if (ConnectedObject1 != null)
	{
	_pus1 = ConnectedObject1.GetComponent<PowerUsageScript>();
	_pus1.DeviceCounter += 1;
	_pus1.ConductCheck();
	//ConductedPower = ConductedPower + _pus1.PowerUsage;
	
	//isCharged = 1;
	}
	
	if (ConnectedObject2 != null)
	{
	_pus2 = ConnectedObject2.GetComponent<PowerUsageScript>();
	_pus2.DeviceCounter += 1;
	_pus2.ConductCheck();
	}
	
	if (ConnectedObject3 != null)
	{
	_pus3 = ConnectedObject3.GetComponent<PowerUsageScript>();
	_pus3.DeviceCounter += 1;
	_pus3.ConductCheck();
	}
	
	if (ConnectedObject4 != null)
	{
	_pus4 = ConnectedObject4.GetComponent<PowerUsageScript>();
	_pus4.DeviceCounter += 1;
	_pus4.ConductCheck();
	}
	
	if (ConnectedObject5 != null)
	{
	_pus5 = ConnectedObject5.GetComponent<PowerUsageScript>();
	_pus5.DeviceCounter += 1;
	_pus5.ConductCheck();
	}
	
	_pss = PowerSource.GetComponent<PowerSourceScript>();
    _pss.CurrentPower = _pss.CurrentPower + ConductedPower;	
	}
	
	public void SwitchOff()
	{
	if (ConnectedObject1 != null)
	{
	_pus1 = ConnectedObject1.GetComponent<PowerUsageScript>();
	//ConductedPower = ConductedPower - _pus1.PowerUsage;
	//_pus1.enabled = false;
	_pus1.DeviceCounter -= 1;
	_pus1.ConductCheck();
	}
	
	if (ConnectedObject2 != null)
	{
	_pus2 = ConnectedObject2.GetComponent<PowerUsageScript>();
	_pus2.DeviceCounter -= 1;
	_pus2.ConductCheck();
	}
	
	if (ConnectedObject3 != null)
	{
	_pus3 = ConnectedObject3.GetComponent<PowerUsageScript>();
	_pus3.DeviceCounter -= 1;
	_pus3.ConductCheck();
	}
	
	if (ConnectedObject4 != null)
	{
	_pus4 = ConnectedObject4.GetComponent<PowerUsageScript>();
	_pus4.DeviceCounter -= 1;
	_pus4.ConductCheck();
	}
	
	if (ConnectedObject5 != null)
	{
	_pus5 = ConnectedObject5.GetComponent<PowerUsageScript>();
	_pus5.DeviceCounter -= 1;
	_pus5.ConductCheck();
	}
	
	//_pss = PowerSource.GetComponent<PowerSourceScript>();
    //_pss.CurrentPower = _pss.CurrentPower - ConductedPower;		
	//ConductedPower = 0;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
