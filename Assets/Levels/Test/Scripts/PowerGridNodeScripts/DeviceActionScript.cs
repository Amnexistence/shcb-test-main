using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Events;

public class DeviceActionScript : MonoBehaviour
{
	private GameObject PowerSource;
	//public int DeviceOrderIndex;
	//[HideInInspector]
	//public int UIDeviceOrderIndex;
	[HideInInspector]
	public int ConductVar; //при 1 ток передан в текущий узел сети, при 0 нет
	PowerSourceScript _pss;
	//private GameObject RoomFromUI;
	//private GameObject[] Rooms;
	
	public static event Action ActionUIStatusChange;
	
	
	void Awake()
    {
	PowerSource = GetComponent<GridListScript>().PowerSource;
    _pss = PowerSource.GetComponent<PowerSourceScript>();
	//Rooms = GameObject.FindGameObjectsWithTag("Room");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	 private void OnEnable()
    {
        UIDeviceScript.ActionChange += CheckChange;
    }

    private void OnDisable()
    {
        UIDeviceScript.ActionChange -= CheckChange;
    }
	
	
	public void CheckChange()
	{
		
	if (gameObject.name == StaticValues._UILinkString)
	{
	transform.GetChild(transform.childCount - 2).gameObject.SetActive(!transform.GetChild(transform.childCount - 2).gameObject.activeInHierarchy);
	_pss.ResetGrid(); //при совпадении назначенного индекса и сиблинг индекса ui данного объекта выполняем действие и обновляем сеть
	}
	
	}

public void UISignal() //при совпадении поданного индекса и сиблинг индекса ui данного объекта обновляем статус ui объекта
{	


//StaticValues._DeviceOrderIndex = Index;


//StaticValues._UILinkString = gameObject.name;
StaticValues._UISignalString = gameObject.name;

ActionUIStatusChange?.Invoke();

}
}
