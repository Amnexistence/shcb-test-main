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
	private bool PowerFlag = false;

	PowerUsageScript _pus;
	
	//private TMP_Text m_TextComponent;
	
	//public GameObject CommandText;
	
	public int UIOrder;
	
	DeviceActionScript _das;
    
	void Awake()
	{
	UseValue = UseOpen ? 1 : -1;
	ObjValue = UseOpen ? 2 : 1;
	_pus = gameObject.transform.parent.gameObject.GetComponent<PowerUsageScript>();
	//m_TextComponent = CommandText.GetComponent<TMP_Text>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	Timer = 5;
	TimerValue = Timer;
	PowerFlag = false;
	if (UseValue == 1)
	{
	gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(false);	
	//m_TextComponent.text="OPENED";
	_pus.DeviceCounter += 1;
	_pus.ConductCheck();
	_das.UISignal(UIOrder);
	}
	}
	
	void OnDisable()
    {
	if (transform.GetSiblingIndex() == (gameObject.transform.parent.transform.childCount - 1))
	{
	_pus.DeviceCounter -= 1;
	_pus.ConductCheck();	
		
	_pus.PowerIncrease();
	_pus.PowerIncrease();
	//m_TextComponent.text="CLOSED";
	_das.UISignal(UIOrder);
	}
	gameObject.transform.parent.transform.GetChild(gameObject.transform.parent.transform.childCount - ObjValue).gameObject.SetActive(true);
	}

    // Update is called once per frame
    void Update()
    {
		
	if (Timer > 0)
	{
     gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*UseValue, 0f, Space.Self);    
	}
		
    Timer = Timer - Time.deltaTime; 
	
	if ((Timer <= 0) && (Timer > -1f)) 
	{
	if (PowerFlag == false)
	{
	_pus.PowerReduce();
	PowerFlag = true;
	}
	
    _pus.enabled = false; 
	}
	
    }
}
