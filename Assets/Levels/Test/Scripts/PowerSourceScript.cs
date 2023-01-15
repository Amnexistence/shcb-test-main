using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerSourceScript : MonoBehaviour
{
	public int TotalPower;
	public int CurrentPower;
	
	public static event Action ActionResetGrid;
	public static event Action ActionPowerUI;
	
	public GameObject ConnectedObject1;
	public GameObject ConnectedObject2;
	public GameObject ConnectedObject3;
	public GameObject ConnectedObject4;
	public GameObject ConnectedObject5;
	
	GridListScript _gls;
	
    // Start is called before the first frame update
    void Start()
    {
     
	
	 
	//TotalPower = 1200;
	
	if (ConnectedObject1 != null)
	{
	_gls = ConnectedObject1.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject2 != null)
	{
	_gls = ConnectedObject2.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject3 != null)
	{
	_gls = ConnectedObject3.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject4 != null)
	{
	_gls = ConnectedObject4.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	if (ConnectedObject5 != null)
	{
	_gls = ConnectedObject5.GetComponent<GridListScript>();
	_gls.GridCount += 1;
	}
	
	ResetGrid();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	
	
	public void ResetGrid()
	{
	ActionResetGrid?.Invoke();
	if (ConnectedObject1 != null)
	{
	_gls = ConnectedObject1.GetComponent<GridListScript>();
	_gls.GridList.Add(1);
	ConnectedObject1.transform.GetChild(ConnectedObject1.transform.childCount - 1).gameObject.SetActive(true);
	}
	if (ConnectedObject2 != null)
	{
	_gls = ConnectedObject2.GetComponent<GridListScript>();
	_gls.GridList.Add(1);
	ConnectedObject2.transform.GetChild(ConnectedObject2.transform.childCount - 1).gameObject.SetActive(true);
	}
	if (ConnectedObject3 != null)
	{
	_gls = ConnectedObject3.GetComponent<GridListScript>();
	_gls.GridList.Add(1);
	ConnectedObject3.transform.GetChild(ConnectedObject3.transform.childCount - 1).gameObject.SetActive(true);
	}
	if (ConnectedObject4 != null)
	{
	_gls = ConnectedObject4.GetComponent<GridListScript>();
	_gls.GridList.Add(1);
	ConnectedObject4.transform.GetChild(ConnectedObject4.transform.childCount - 1).gameObject.SetActive(true);
	}
	if (ConnectedObject5 != null)
	{
	_gls = ConnectedObject5.GetComponent<GridListScript>();
	_gls.GridList.Add(1);
	ConnectedObject5.transform.GetChild(ConnectedObject5.transform.childCount - 1).gameObject.SetActive(true);
	}
	StartCoroutine(GridAnswerWait());
	}
	
	IEnumerator GridAnswerWait()
	{
    yield return new WaitForSeconds(0.01f);
	StaticValues._CurrentPower = CurrentPower;
    ActionPowerUI?.Invoke();
	}
	
	
}
