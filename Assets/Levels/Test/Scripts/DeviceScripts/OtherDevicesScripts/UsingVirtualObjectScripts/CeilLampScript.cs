using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class CeilLampScript : MonoBehaviour
{
	public int LightIndex; //устанавливаем индекс нужного лайт подобъекта объекта PointLight на сцене Light
	public Material OffLampMat;
	public Material OnLampMat;
	MeshRenderer _mr;
	DeviceActionScript _das;
    
	public static event Action ActionCeilLamp;
	
	void Awake()
	{
	_mr = transform.parent.gameObject.GetComponent<MeshRenderer>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	_mr.material = OnLampMat;
	_das.UISignal();
	MyEvent();
	}
	
	void OnDisable()
    {
	_mr.material = OffLampMat;
	_das.UISignal();
	MyEvent();
	}
	
	private void MyEvent()
	{
	StaticValues._LampOrderIndex = LightIndex;
	ActionCeilLamp?.Invoke();	
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
