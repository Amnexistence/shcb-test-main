using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateActionScript : MonoBehaviour
{
	public Material OffIndicatorMat;
	public Material OnIndicatorMat;
	MeshRenderer _mr;
	[HideInInspector]
	public bool StateFlag;
	DeviceActionScript _das;
	
	private int UIOrder;
	
	void Awake()
	{
	_mr = gameObject.transform.parent.GetComponent<MeshRenderer>();
	_das = transform.parent.gameObject.GetComponent<DeviceActionScript>();
	}
	
    void OnEnable()
    {
	_mr.material = OnIndicatorMat;
	_das.UISignal(_das.DeviceOrderIndex);
	}
	
	 void OnDisable()
    {  
	_mr.material = OffIndicatorMat;
	_das.UISignal(_das.DeviceOrderIndex);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
