using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class UIActionStatus : MonoBehaviour
{
	private int UIDeviceOrderIndex;
	[HideInInspector]
	public int DeviceOrderIndex;
	Component[] _HeaderStatuses;
	//public string DeviceRoom; // for UIDeviceScript
	
    // Start is called before the first frame update
    void Start()
    {
	_HeaderStatuses = gameObject.GetComponents(typeof(HeaderStatus)); 
	UIDeviceOrderIndex = transform.GetSiblingIndex();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	private void OnEnable()
    {
        DeviceActionScript.ActionUIStatusChange += CheckChange;
    }

    private void OnDisable()
    {
        DeviceActionScript.ActionUIStatusChange -= CheckChange;
    }
	

	private void CheckChange() //проверяем соответствие статуса устройства и меняем статус во всех объектах хедер-статуса
	{
	if (gameObject.name == "Device Block " + StaticValues._UISignalString)
	//if (StaticValues._DeviceOrderIndex == UIDeviceOrderIndex)
	{
	foreach (HeaderStatus _hs in _HeaderStatuses)
	_hs.ChangeStatus();
	}
	}
}
