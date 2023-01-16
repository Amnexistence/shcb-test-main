using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActionScript : MonoBehaviour
{
	public Material OffIndicatorMat;
	public Material OnIndicatorMat;
	MeshRenderer _mr;
	[HideInInspector]
	public bool StateFlag;
	
	private int UIOrder;
	
	void Awake()
	{
	_mr = gameObject.transform.parent.transform.GetChild(2).GetComponent<MeshRenderer>();
	}
	
    void OnEnable()
    {
	_mr.material = OnIndicatorMat;
	}
	
	 void OnDisable()
    {  
	_mr.material = OffIndicatorMat;
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
