using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 

public class DoorDriverScript : MonoBehaviour
{
	
	
	public float OurTimer;
	public float Timer;
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
	//GridWaitFlag = true;
	
	if (_das.ConductVar == 1)
	{
	if ((Timer <= 0) && ((_pss.CurrentPower + PowerUsage) <= _pss.TotalPower))
	{
	_pss.CurrentPower += PowerUsage;
	}
	
	if (ObjValue == 3)
	{
	if (gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.y < 0)
	{
	Timer = (90 - Mathf.Abs(gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.y)) / (90/OurTimer);
	}
	else
	{
	Timer = (90 - Mathf.Abs(gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y)) / (90/OurTimer);
	//because 90 / 5(*is our opened/closed time*) = 18 is (90/OurTimer)
	}
	//тут чёто неочевидное, в первом случае нужен обязательно просто ротейшен, а во втором обязательно эйлер
	}
	if (ObjValue == 2)
	{
	Timer = Mathf.Abs(gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y) / (90/OurTimer);
	//because 90 / 5(*is our opened/closed time*) = 18 is (90/OurTimer)
	}
	
	
	
	//когда переключаем во время закрытия обратно в открытие получается фигня
	
	TimerValue = OurTimer;
	//PowerFlag = false;
	if (UseValue == 1)
	{
	
	//m_TextComponent.text="OPENED";
	//_pus.DeviceCounter += 1;
	//_pus.ConductCheck();
	
	}
	_das.UISignal(UIOrder);
	
	
	
	}	
	
	gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(false);

	//else
	//{
	//gameObject.SetActive(false);
	//}
	
	
	}
	
	
	void OnDisable()
    {
	if (Timer > 0)
	{
	_pss.CurrentPower -= PowerUsage;
	_pss.PowerUIupd();	
	}
	Timer = 0;
	gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(true);
	}
	

    // Update is called once per frame
    void Update()
    {
		
	if (Timer > 0)
	{
	if (ObjValue == 3)
	{
    gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*UseValue*SideValue, 0f, Space.Self);    
	}
	else
	{
	if (gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y > 0)
	{
	gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*(-1), 0f, Space.Self);    
	}
	if (gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y < 0)
	{
	gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime), 0f, Space.Self);    
	}
	}
	Timer = Timer - Time.deltaTime;
	}
	else if ((Timer <= 0) && (Timer > -1))
	{
	_pss.CurrentPower -= PowerUsage;
	_pss.PowerUIupd();
	Timer = -2;
	}
		
    
	
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
	
	GridWaitFlag = false;
	//gameObject.SetActive(false); //?
	}
		

	
	}
}
