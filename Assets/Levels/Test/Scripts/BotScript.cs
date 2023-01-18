using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotScript : MonoBehaviour
{
	public int MaximumPower;
	public int MyPower;
	[HideInInspector]
	public int MyState;
	private bool BreakVar = false;
	public float Timer;
	public bool ChooseMove = true;
	
	//public float[][][] room_coord_array = new float[20][][];
	//public List<List<float>> rooms_list;
	
	public List<float> TargetPositionList;
	//public List<List<float>> VisitedList;
	public List<float> VisitedList;
	//public List<List<List<float>>> PriorList;
	public List<float> PriorList;
	public int BotStep;
	private bool PowerRotateFlag = false;
	private bool PowerMoveFlag = false;
	
	List<List<float>> VisitedListOfLists = new List<List<float>>();
	List<List<float>> PriorListOfLists = new List<List<float>>();
	List<List<List<float>>> PriorListOfListsOfLists = new List<List<List<float>>>();
	
	
    // Start is called before the first frame update
    void Start()
    {
	
	//TargetPositionList = new List <float>(2);
	//VisitedList = new List<List<float>>(200);
	//PriorList = new List<List<List<float>>>(4);
	
	TargetPositionList = new List<float>() {-999,-999};
	VisitedList = new List<float>() {-999,-999};
	
	PriorList = new List<float>() {-999,-999};
	
	//List<float> VisitedList = new List<float>();

	for(int i = 0; i < 3; i++)	
	{
    PriorListOfLists.Add(PriorList);
	}    
	
	for(int i = 0; i < 4; i++)	
	{
    PriorListOfListsOfLists.Add(PriorListOfLists);
	}
	
	for(int i = 0; i < 200; i++)	
	{
    VisitedListOfLists.Add(VisitedList);
	}    
	
		
     VisitedListOfLists[0][0] = transform.position.x;
	 VisitedListOfLists[0][1] = transform.position.z;
	 
	 
	 
	 
	 
    }

    // Update is called once per frame
    void Update()
    {
    
	if ((MyState == 1) && (MyPower >= 15))
	{
	if (ChooseMove == true)
	{
	BotStep += 1;
    RaycastHit hit;
    //Ray ray = new Ray(transform.position, (transform.position + (transform.forward * (-1))) - transform.position);
    //Physics.Raycast(ray, out hit);

    //if (hit.collider != null)
	if (!Physics.Raycast(transform.position, (transform.forward * (-1)), out hit, 1))
	{
	for(int i = 0; i < VisitedListOfLists.Count; i++)	
	{
	
	if ( (((transform.position + (transform.forward * (-1))).x) == VisitedListOfLists[i][0]) && (((transform.position + (transform.forward * (-1))).z) == VisitedListOfLists[i][1]) )
	{
	PriorListOfListsOfLists[1][0][0] = (transform.position + (transform.forward * (-1))).x;
	PriorListOfListsOfLists[1][0][1] = (transform.position + (transform.forward * (-1))).z;
	break;
	}
	
	if ( i == (VisitedListOfLists.Count - 1) )
	{
	PriorListOfListsOfLists[3][0][0] = (transform.position + (transform.forward * (-1))).x;
	PriorListOfListsOfLists[3][0][1] = (transform.position + (transform.forward * (-1))).z;
	}
	

	}
	
    }
	
    //ray = new Ray(transform.position, (transform.position + (transform.right * (-1))) - transform.position);
    //Physics.Raycast(ray, out hit);

    if (!Physics.Raycast(transform.position, (transform.right * (-1)), out hit, 1))
	{
		
    for(int i = 0; i < VisitedListOfLists.Count; i++)	
	{
	
	if ( (((transform.position + (transform.right * (-1))).x) == VisitedListOfLists[i][0]) && (((transform.position + (transform.right * (-1))).z) == VisitedListOfLists[i][1]) )
	{
	PriorListOfListsOfLists[0][0][0] = (transform.position + (transform.right * (-1))).x;
	PriorListOfListsOfLists[0][0][1] = (transform.position + (transform.right * (-1))).z;
	break;
	}
	
	if ( i == (VisitedListOfLists.Count - 1) )
	{
	PriorListOfListsOfLists[2][0][0] = (transform.position + (transform.right * (-1))).x;
	PriorListOfListsOfLists[2][0][1] = (transform.position + (transform.right * (-1))).z;
	}
	

	}
            
    }
	
    //ray = new Ray(transform.position, (transform.position + transform.right) - transform.position);
    //Physics.Raycast(ray, out hit);

    if (!Physics.Raycast(transform.position, transform.right, out hit, 1))
	{
		
    for(int i = 0; i < VisitedListOfLists.Count; i++)	
	{
	
	if ( (((transform.position + transform.right).x) == VisitedListOfLists[i][0]) && (((transform.position + transform.right).z) == VisitedListOfLists[i][1]) )
	{
	PriorListOfListsOfLists[0][1][0] = (transform.position + transform.right).x;
	PriorListOfListsOfLists[0][1][1] = (transform.position + transform.right).z;
	break;
	}
	
	if ( i == (VisitedListOfLists.Count - 1) )
	{
	PriorListOfListsOfLists[2][1][0] = (transform.position + transform.right).x;
	PriorListOfListsOfLists[2][1][1] = (transform.position + transform.right).z;
	}
	

	}
            
    }
	
	//TargetPositionList = 
	
	for(int i = PriorListOfListsOfLists.Count - 1; i > -1; i--) //приоритет обратно
	{
	if (BreakVar == true) 
	{
	break;
	}
	for(int j = 0; j < PriorListOfListsOfLists[i].Count - 1; j++)	
	{
	if (PriorListOfListsOfLists[i][j][0] != -999 )
	{
	//TargetPositionList = PriorListOfListsOfLists[i][j];
	TargetPositionList[0] = PriorListOfListsOfLists[i][j][0];
	TargetPositionList[1] = PriorListOfListsOfLists[i][j][1];
	BreakVar = true;
	break;  //эта штука явно работает, но судя по всему не ломается. чзх? goto тоже не сработал
	}
	}
	}
	
	BreakVar = false;
	
	ChooseMove = false;
	
	Timer = 1;
	PowerMoveFlag = true;
	PowerRotateFlag = true;
	}
	
	//if (TargetPositionList[1] != null)
	//{
	if ((TargetPositionList[0] == ((transform.position + (transform.forward * (-1))).x)) && (TargetPositionList[1] == ((transform.position + (transform.forward * (-1))).z)) )
	{
	//Timer = 0;
	//var step =  1 * Time.deltaTime; // calculate distance to move
	}
	else
	{
	if (Timer > 0)
	{
	transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3(TargetPositionList[0] - transform.position.x, 0f, TargetPositionList[1] - transform.position.z)*(-1), 1.5f*Time.deltaTime, 0.0f));
	if (PowerRotateFlag == true)
	{
	MyPower = MyPower - 5;
	PowerRotateFlag = false;
	}
	}
	} //можно использовать корутины
	
	
	
	if (Timer <= 0)
	{
	transform.position = Vector3.MoveTowards(transform.position, new Vector3(TargetPositionList[0], transform.position.y, TargetPositionList[1]), Time.deltaTime);	
	if (PowerMoveFlag == true)
	{
	MyPower = MyPower - 10;
	PowerMoveFlag = false;
	}
	}
	
	if ((transform.position.x == TargetPositionList[0]) && (transform.position.z == TargetPositionList[1]))
	{
		
	VisitedListOfLists[BotStep][0] = transform.position.x;	
	VisitedListOfLists[BotStep][1] = transform.position.z;	
		
	ChooseMove = true;
	
	for(int i = 0; i < PriorListOfListsOfLists.Count; i++)
	{
	for(int j = 0; j < PriorListOfListsOfLists[i].Count - 1; j++)	//приоритет обратно
	{
	PriorListOfListsOfLists[i][j][0] = -999;
	}
	}
	
	
	}
	
	Debug.Log(PriorListOfListsOfLists[3][0][0].ToString());
	Debug.Log(PriorListOfListsOfLists[3][0][1].ToString());
	Debug.Log(PriorListOfListsOfLists[1][0][0].ToString());
	Debug.Log(PriorListOfListsOfLists[1][0][1].ToString());
	Debug.Log(transform.forward.x.ToString());
	Debug.Log(transform.forward.z.ToString());
	//}
	
	if (Timer > 0)
	{
	//if (ObjValue == 3)
	//{
    //gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*UseValue*SideValue, 0f, Space.Self);    
	//}
	//else
	//{
	//if (gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y > 0)
	//{
	//gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime)*(-1), 0f, Space.Self);    
	//}
	//if (gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.rotation.eulerAngles.y < 0)
	//{
	//gameObject.transform.parent.transform.parent.transform.GetChild(0).transform.Rotate(0f, ((90f/TimerValue) * Time.deltaTime), 0f, Space.Self);    
	//}
	//}
	Timer = Timer - Time.deltaTime;
	}
	//else if ((Timer <= 0) && (Timer > -1))
	//{
	//_pss.CurrentPower -= PowerUsage;
	//_pss.PowerUIupd();
	//Timer = -2;
	//}
	
    }
	
	
    }
	
	
    }
