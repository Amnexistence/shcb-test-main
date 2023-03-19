using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraSwitch: MonoBehaviour, IPointerClickHandler
{
	private GameObject Camera1;
	public GameObject[] CameraList;
	private int Current;
	
    // Start is called before the first frame update
    void Start()
    {
	
	CameraList =  GameObject.FindGameObjectsWithTag("MainCamera");
	
	for(int i = 0; i < CameraList.Length; i++)	
	{
	CameraList[i].GetComponent<Camera>().enabled = false;
	CameraList[i].GetComponent<AudioListener>().enabled = false;
	}
	
	CameraList[0].GetComponent<Camera>().enabled = true;
	CameraList[0].GetComponent<AudioListener>().enabled = true;
	
	}
	
   public void OnPointerClick(PointerEventData eventData)
{

		CameraList[Current].GetComponent<Camera>().enabled = false;
		CameraList[Current].GetComponent<AudioListener>().enabled = false;
		Current += 1;
		if (Current > CameraList.Length - 1)
		{
		Current = 0;	
		}
		CameraList[Current].GetComponent<Camera>().enabled = true;
		CameraList[Current].GetComponent<AudioListener>().enabled = true;
			
}



}