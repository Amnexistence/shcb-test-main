using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 

public class DoorDriverScript : MonoBehaviour
{
	
	
	
	private float Timer;
	private float TimerValue;
	public bool UseOpen;
	private int UseValue;
	private int ObjValue;
	private bool GridWaitFlag = false;
	[HideInInspector]
	public int SideValue = 1;

	//PowerUsageScript _pus;
	
	//private TMP_Text m_TextComponent;
	
	//public GameObject CommandText;
	
	public int UIOrder;
	
	DeviceActionScript _das;
	
	public int PowerUsage;
	private GameObject PowerSource;
	PowerSourceScript _pss;
    
	void Awake()
	{
	UseValue = UseOpen ? 1 : -1;
	ObjValue = UseOpen ? 3 : 2;
	//_pus = gameObject.transform.parent.gameObject.GetComponent<PowerUsageScript>();
	//m_TextComponent = CommandText.GetComponent<TMP_Text>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	PowerSource = transform.parent.GetComponent<GridListScript>().PowerSource;
	_pss = PowerSource.GetComponent<PowerSourceScript>();
	}
	
    void OnEnable()
    {
	GridWaitFlag = true;
		
	
	//else
	//{
	//gameObject.SetActive(false);
	//}
	
	
	}
	
	
	void OnDisable()
    {
	gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(true);
	}
	

    // Update is called once per frame
    void Update()
    {
		
	if (Timer > 0)
	{
	if (UseValue >= 1)
	{
    gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*UseValue*SideValue, 0f, Space.Self);    
	}
	else
	{
	if (gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.y > 0)
	{
	gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*UseValue*SideValue, 0f, Space.Self);    
	}
	}
	}
		
    Timer = Timer - Time.deltaTime; 
	
	/*
	if ((Timer <= 0) && (Timer > -1f)) 
	{
	if (PowerFlag == false)
	{
	//_pus.PowerReduce();
	PowerFlag = true;
	}
	
    //_pus.enabled = false; 
	}
	
	*/
	
    }
	
	public void DoorWork()
	{
	if (GridWaitFlag == true)
	{
	if (((_pss.CurrentPower + PowerUsage) <= _pss.TotalPower) && (_das.ConductVar == 1))
	{
	_pss.CurrentPower += PowerUsage*UseValue;		
	Timer = 5;
	TimerValue = Timer;
	//PowerFlag = false;
	if (UseValue == 1)
	{
	
	//m_TextComponent.text="OPENED";
	//_pus.DeviceCounter += 1;
	//_pus.ConductCheck();
	
	}
	_das.UISignal(UIOrder);
	
	
	
	}	
	GridWaitFlag = false;
	//gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(false);
	gameObject.SetActive(false); //?
	}
		

	
	}
}
