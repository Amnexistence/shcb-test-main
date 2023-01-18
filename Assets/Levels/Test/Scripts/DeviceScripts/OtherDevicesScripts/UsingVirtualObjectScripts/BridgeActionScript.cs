using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeActionScript : MonoBehaviour
{
	private int UIOrder;
	public Material OffIndicatorMat;
	public Material OnIndicatorMat;
	MeshRenderer _mr;
	
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
