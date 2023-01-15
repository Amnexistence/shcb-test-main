using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class CeilLampScript : MonoBehaviour
{
	
	public Material OffLampMat;
	public Material OnLampMat;
	//public int UIOrder;
	MeshRenderer _mr;
	DeviceActionScript _das;
	public int LightIndex;
    
	public static event Action ActionCeilLamp0;
	public static event Action ActionCeilLamp1;
	
	void Awake()
	{
	_mr = transform.parent.gameObject.GetComponent<MeshRenderer>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	_mr.material = OnLampMat;
	_das.UISignal(_das.DeviceOrderIndex);
	MyEvent();
	}
	
	void OnDisable()
    {
	_mr.material = OffLampMat;
	_das.UISignal(_das.DeviceOrderIndex);
	MyEvent();
	}
	
	private void MyEvent()
	{
	if (LightIndex == 0)
	{
	ActionCeilLamp0?.Invoke();
	}
	else if (LightIndex == 1)
	{
	ActionCeilLamp1?.Invoke();	
	}	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
