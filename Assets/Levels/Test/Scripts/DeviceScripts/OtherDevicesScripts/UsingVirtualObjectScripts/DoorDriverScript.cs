using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro; 

public class DoorDriverScript : MonoBehaviour
{
	private GameObject PowerSource;
	public float OurTimer;
	private float Timer;
	private float TimerValue;
	public bool UseOpen;
	private int UseValue;
	private int ObjValue;
	[HideInInspector]
	public int SideValue = 1; //переменная для открывания двери роботом в ту или иную сторону
	public int UIOrder;
	public int PowerUsage;
	private TMP_Text m_TextComponent;
	DeviceActionScript _das;
	PowerSourceScript _pss;
    
	void Awake()
	{
	UseValue = UseOpen ? 1 : -1;
	ObjValue = UseOpen ? 3 : 2;
	m_TextComponent = gameObject.transform.parent.transform.GetChild(2).GetComponent<TMP_Text>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	PowerSource = transform.parent.GetComponent<GridListScript>().PowerSource;
	_pss = PowerSource.GetComponent<PowerSourceScript>();
	}
	
    void OnEnable()
    {
	
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
		}
		//тут чёто неочевидное, в первом случае нужен обязательно просто ротейшен, а во втором обязательно эйлер
	
	m_TextComponent.text = "OPENED";
	}
	if (ObjValue == 2)
	{
	Timer = Mathf.Abs(gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y) / (90/OurTimer);
	m_TextComponent.text = "CLOSED";
	}
	
	
	TimerValue = OurTimer;
	_das.UISignal(UIOrder);
	
	}	
	gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(false);
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
		
	
    }
	
}
