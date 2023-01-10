using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//using perelesoq;

public class CameraSwitch: MonoBehaviour, IPointerClickHandler
{
	//public Component[] Images;
	private GameObject Camera1;
	//public GameObject Camera2;
	//public GameObject Camera3;
	
   
 
	public GameObject[] CameraList;
	private int Current;
	
    // Start is called before the first frame update
    void Start()
    {
	//CameraList = new List<GameObject>();	
	
	 CameraList =  GameObject.FindGameObjectsWithTag("MainCamera");
	
	for(int i = 0; i < CameraList.Length; i++)	
	{
	CameraList[i].GetComponent<Camera>().enabled = false;
	}
	
	CameraList[0].GetComponent<Camera>().enabled = true;
	
	//CameraList.Add(Camera1);
	//CameraList.Add(Camera2);
	//CameraList.Add(Camera3);
	}
	
   public void OnPointerClick(PointerEventData eventData)
{
	//GameObject.FindWithTag("Player").GetComponent<PlayerAnim>().shake_flag = false;
	//GameObject.FindWithTag("Player").GetComponent<PlayerAnim>().rotateAround_flag = false;
	
	//Images = transform.parent.GetComponentsInChildren<Image>();
	
	//foreach (Image img in Images)
            //img.color = new Color(1f, 1f, 1f);
		CameraList[Current].GetComponent<Camera>().enabled = false;
		Current += 1;
		if (Current > CameraList.Length - 1)
		{
		Current = 0;	
		}
		CameraList[Current].GetComponent<Camera>().enabled = true;
			
}



}