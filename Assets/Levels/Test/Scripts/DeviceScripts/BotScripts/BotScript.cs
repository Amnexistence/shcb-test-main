using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BotScript : MonoBehaviour
{
	NavMeshAgent navMeshAgent;
	
	public int MaximumPower;
	public int MyPower;
	[HideInInspector]
	public int MyState;
	private bool BreakVar = false;
	private float Timer;
	private bool ChooseMove = true;
	private NavMeshPath path;

	
	//public List<float> TargetPositionList;

	//private List<float> VisitedList;

	//private List<float> PriorList;
	
	private List<float> MarkL;
	List<List<float>> MarkLists = new List<List<float>>();
	private List<float> PathfindMarkL;
	List<List<float>> PathfindMarkLists = new List<List<float>>();
	private List<float> PathfindVisitedL;
	List<List<float>> PathfindVisitedLists = new List<List<float>>();
	private List<float> PathL;
	List<List<float>> PathLists = new List<List<float>>();
	private int BotStep;
	private bool PowerRotateFlag = false;
	private bool PowerMoveFlag = false;
	public int OnlyVisited = 0;
	private bool hasPath = false;
	
	//List<List<float>> VisitedListOfLists = new List<List<float>>();
	//List<List<float>> PriorListOfLists = new List<List<float>>();
	
	//List<List<List<float>>> PriorListOfListsOfLists = new List<List<List<float>>>();
	
	//agent.destination = .position;
	
	public float[] TargetPositionArray = new float[2];
	public float[][] VisitedArray = new float[200][];
	public float[][] PriorArray = new float[6][];
	private NavMeshHit hit;
	
    // Start is called before the first frame update
    void Start()
    {
	navMeshAgent = GetComponent<NavMeshAgent>();
	path = new NavMeshPath();
	////TargetPositionList = new List<float>() {-999,-999};
	////VisitedList = new List<float>() {-999,-999};
	
	////PriorList = new List<float>() {-999,-999};
	
	MarkL = new List<float>() {-999,-999};
	MarkLists.Add(MarkL);
	
	//////PathfindMarkL = new List<float>() {-999,-999,0,0};
	//////PathfindMarkLists.Add(PathfindMarkL);
	
	///////PathfindVisitedL = new List<float>() {-999,-999,0,0};
	///////PathfindVisitedLists.Add(PathfindVisitedL);

	////for(int i = 0; i < 6; i++)	
	////{
    ////PriorListOfLists.Add(PriorList);
	////}    
	
	//for(int i = 0; i < 4; i++)	
	//{
    //PriorListOfListsOfLists.Add(PriorListOfLists);
	//}
	
	////for(int i = 0; i < 200; i++)	
	////{
    ////VisitedListOfLists.Add(VisitedList);
	////}    
	
		
     //VisitedList[0][0] = transform.position.x;
	 //VisitedList[0][1] = transform.position.z;
	 
	 for(int i = VisitedArray.Length - 1; i > -1; i--)
	{
	 VisitedArray[i] = new float[2];
	 VisitedArray[i][0] = -999;
	 VisitedArray[i][1] = -999;
	}
	 
	 VisitedArray[0] = new float[]{transform.position.x, transform.position.z};
	 TargetPositionArray = new float[]{ 0, 0 };
	 
	 for(int i = PriorArray.Length - 1; i > -1; i--)
	{
	 PriorArray[i] = new float[2];
	 PriorArray[i][0] = -999;
	 PriorArray[i][1] = -999;
	}
	
	PathL = new List<float>() {-999,-999,-999,-999};
	PathLists.Add(PathL);
	
	BotStep = 1;
    }

    // Update is called once per frame
    void Update()
    {
    
	if ((MyState == 1) && (MyPower >= 15)) //если запущен и энергия больше критически низкого заряда
	{
	if ((ChooseMove == true) && (OnlyVisited == 0) )
	{
    //RaycastHit hit;

	OnlyVisited = 1;

    //if (hit.collider != null)
	//if (!Physics.Raycast(transform.position, (transform.forward * (-1)), out hit, 1))
	//NavMesh.CalculatePath(transform.position, transform.position+(transform.forward * (-1)), 1, path);
	//hasPath = ((path.status != NavMeshPathStatus.PathInvalid) && (path.status != NavMeshPathStatus.PathPartial));
	if (!NavMesh.Raycast(transform.position, transform.position+(transform.forward * (-1)), out hit, 1))
	//if (hasPath == true)
	{
		
	
	MarkL = new List<float>() {(float)System.Math.Round((transform.position + (transform.forward * (-1))).x, 1), (float)System.Math.Round((transform.position + (transform.forward * (-1))).z, 1)};
	MarkLists.Add(MarkL);
	
	for(int i = 0; i < VisitedArray.Length; i++)
	{
	if ((MarkLists[MarkLists.Count - 1][0] == VisitedArray[i][0]) && (MarkLists[MarkLists.Count - 1][1] == VisitedArray[i][1]))
	{
	MarkLists.RemoveAt(MarkLists.Count - 1);
	break;
	}
	}
	
	for(int i = 0; i < VisitedArray.Length; i++)	
	{
	
	//if ( Mathf.Approximately((transform.position + (transform.forward * (-1))).x , VisitedArray[i][0]) && Mathf.Approximately(((transform.position + (transform.forward * (-1))).z) , VisitedArray[i][1]) )
	if ( ((transform.position + (transform.forward * (-1))).x >= (VisitedArray[i][0] - 0.2f)) && ((transform.position + (transform.forward * (-1))).x <= (VisitedArray[i][0] + 0.2f)) && ((transform.position + (transform.forward * (-1))).z >= (VisitedArray[i][1] - 0.2f)) && ((transform.position + (transform.forward * (-1))).z <= (VisitedArray[i][1] + 0.2f)) )
	{
	PriorArray[2][0] = (float)System.Math.Round((transform.position + (transform.forward * (-1))).x, 1);
	PriorArray[2][1] = (float)System.Math.Round((transform.position + (transform.forward * (-1))).z, 1);
	Debug.Log("!");
	break;
	}
	
	if ( i == (VisitedArray.Length - 1) )
	{
	PriorArray[5][0] = (float)System.Math.Round((transform.position + (transform.forward * (-1))).x, 1);
	PriorArray[5][1] = (float)System.Math.Round((transform.position + (transform.forward * (-1))).z, 1);
	OnlyVisited = 0;
	}
	

	}
	
    }
	

    //if ((!Physics.Raycast(transform.position, (transform.right * (-1)), out hit, 1)))
	//NavMesh.CalculatePath(transform.position, transform.position+(transform.right * (-1)), 1, path);
	//hasPath = ((path.status != NavMeshPathStatus.PathInvalid) && (path.status != NavMeshPathStatus.PathPartial));
	//if (hasPath == true)
	if (!NavMesh.Raycast(transform.position, transform.position+(transform.right * (-1)), out hit, 1))
	{
	
	MarkL = new List<float>() {(float)System.Math.Round((transform.position + (transform.right * (-1))).x, 1),(float)System.Math.Round((transform.position + (transform.right * (-1))).z, 1)};
	MarkLists.Add(MarkL);
	
	for(int i = 0; i < VisitedArray.Length; i++)
	{
	if ((MarkLists[MarkLists.Count - 1][0] == VisitedArray[i][0]) && (MarkLists[MarkLists.Count - 1][1] == VisitedArray[i][1]))
	{
	MarkLists.RemoveAt(MarkLists.Count - 1);
	break;
	}
	}
		
    for(int i = 0; i < VisitedArray.Length; i++)	
	{
	
	if ( ((transform.position + (transform.right * (-1))).x >= (VisitedArray[i][0] - 0.2f)) && ((transform.position + (transform.right * (-1))).x <= (VisitedArray[i][0] + 0.2f)) && ((transform.position + (transform.right * (-1))).z >= (VisitedArray[i][1] - 0.2f)) && ((transform.position + (transform.right * (-1))).z <= (VisitedArray[i][1] + 0.2f)) )
	{
	PriorArray[1][0] = (float)System.Math.Round((transform.position + (transform.right * (-1))).x, 1);
	PriorArray[1][1] = (float)System.Math.Round((transform.position + (transform.right * (-1))).z, 1);
	break;
	}
	
	if ( i == (VisitedArray.Length - 1) )
	{
	PriorArray[4][0] = (float)System.Math.Round((transform.position + (transform.right * (-1))).x, 1);
	PriorArray[4][1] = (float)System.Math.Round((transform.position + (transform.right * (-1))).z, 1);
	OnlyVisited = 0;
	
	}
	

	}
            
    }
	

    //if (!Physics.Raycast(transform.position, transform.right, out hit, 1))
	//NavMesh.CalculatePath(transform.position, transform.position+transform.right, 1, path);
	//hasPath = ((path.status != NavMeshPathStatus.PathInvalid) && (path.status != NavMeshPathStatus.PathPartial));
	//if (hasPath == true)
	if (!NavMesh.Raycast(transform.position, transform.position+transform.right, out hit, 1))
	{
	
	MarkL = new List<float>() {(float)System.Math.Round((transform.position + transform.right).x, 1), (float)System.Math.Round((transform.position + transform.right).z, 1)};
	MarkLists.Add(MarkL);
	
	for(int i = 0; i < VisitedArray.Length; i++)
	{
	if ((MarkLists[MarkLists.Count - 1][0] == VisitedArray[i][0]) && (MarkLists[MarkLists.Count - 1][1] == VisitedArray[i][1]))
	{
	MarkLists.RemoveAt(MarkLists.Count - 1);
	break;
	}
	}
		
    for(int i = 0; i < VisitedArray.Length; i++)	
	{
	
	if ( ((transform.position + (transform.right)).x >= (VisitedArray[i][0] - 0.2f)) && ((transform.position + (transform.right)).x <= (VisitedArray[i][0] + 0.2f)) && ((transform.position + (transform.right)).z >= (VisitedArray[i][1] - 0.2f)) && ((transform.position + (transform.right)).z <= (VisitedArray[i][1] + 0.2f)) )
	{
	PriorArray[0][0] = (float)System.Math.Round((transform.position + transform.right).x, 1);
	PriorArray[0][1] = (float)System.Math.Round((transform.position + transform.right).z, 1);
	break;
	}
	
	if ( i == (VisitedArray.Length - 1) )
	{
	PriorArray[3][0] = (float)System.Math.Round((transform.position + transform.right).x, 1);
	PriorArray[3][1] = (float)System.Math.Round((transform.position + transform.right).z, 1);
	OnlyVisited = 0;
	
	}
	

	}
            
    }
	
	
	for(int i = PriorArray.Length - 1; i > -1; i--) //приоритет обратно
	{
	//if (BreakVar == true) 
	//{
	//break;
	//}
	if (PriorArray[i][0] != -999 )
	{
	//TargetPositionList = PriorListOfListsOfLists[i][j];
	TargetPositionArray[0] = PriorArray[i][0];
	TargetPositionArray[1] = PriorArray[i][1];
	//BreakVar = true;
	break;
	}
	}
	
	for(int i = 0; i < MarkLists.Count; i++)
	{
	if ((MarkLists[i][0] == TargetPositionArray[0]) && (MarkLists[i][1] == TargetPositionArray[1]))
	{
	MarkLists.RemoveAt(i);
	}
	}
	
	BreakVar = false;
	
	
	Timer = 1;
	
	if ((Mathf.Approximately(TargetPositionArray[0] , (transform.position + (transform.forward)).x) && Mathf.Approximately(TargetPositionArray[1] , (transform.position + (transform.forward)).z)))
	{
	Timer = 2;	
	}
	
	PowerMoveFlag = true;
	PowerRotateFlag = true;
	//hasPath = false;
	}
	
	
	if ((OnlyVisited == 1) && (ChooseMove == true))
	{
	PathfindVisitedL = new List<float>() {transform.position.x,transform.position.z,0,999};
	PathfindVisitedLists.Add(PathfindVisitedL);	
	
	List<float> temp = new List<float>() {-999,-999};
	for(int i = 0; i < MarkLists.Count - 1; i++)
	{
	for (int j = i + 1; j < MarkLists.Count; j++)
	{
	//if (((MarkLists[i][0] - TargetPositionArray[0]) < (MarkLists[j][0] - TargetPositionArray[0])) && ((MarkLists[i][1] - TargetPositionArray[1]) < (MarkLists[j][1] - TargetPositionArray[1])))
	if (Vector3.Distance(new Vector3(MarkLists[i][0], 0 ,MarkLists[i][1]), transform.position) < Vector3.Distance(new Vector3(MarkLists[j][0], 0 ,MarkLists[j][1]), transform.position))
	{
	
	temp = MarkLists[i];
	MarkLists[i] = MarkLists[j];
	MarkLists[j] = temp;
	}
	}
	}
	
	
	
	TargetPositionArray[0] = MarkLists[MarkLists.Count - 1][0];
	TargetPositionArray[1] = MarkLists[MarkLists.Count - 1][1];
	
	for(int i = 1; i < 200; i++)
	{
	if (BreakVar == true)
	{
	break;	
	}
	BreakVar = false;
	for (int j = 0; j < PathfindVisitedLists.Count - 1; j++)
	{
	//if (!NavMesh.Raycast(transform.position, transform.position+(transform.forward * (-1)), out hit, 1))
	//NavMesh.CalculatePath(transform.position, transform.position+transform.forward, 1, path);
	//hasPath = ((path.status != NavMeshPathStatus.PathInvalid) && (path.status != NavMeshPathStatus.PathPartial));
	
	if ((!NavMesh.Raycast(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]), (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.forward), out hit, 1)) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.forward).x, PathfindVisitedLists[j][0])) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.forward).z, PathfindVisitedLists[j][1])))
	{
	PathfindVisitedL = new List<float>() {(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.forward).x, (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.forward).z, i, Vector3.Distance(new Vector3(TargetPositionArray[0], 0 ,TargetPositionArray[1]), (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.forward))};
	PathfindVisitedLists.Add(PathfindVisitedL);
	if (Mathf.Approximately(PathfindVisitedL[0], TargetPositionArray[0]) && Mathf.Approximately(PathfindVisitedL[1], TargetPositionArray[1]))
	{
	BreakVar = true;
	break;
	}
	}
	
	if ((!NavMesh.Raycast(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]), new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.back, out hit, 1)) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.back).x, PathfindVisitedLists[j][0])) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.back).z, PathfindVisitedLists[j][1])))
	{
	PathfindVisitedL = new List<float>() {(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.back).x, (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.back).z, i, Vector3.Distance(new Vector3(TargetPositionArray[0], 0 ,TargetPositionArray[1]), (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.back))};
	PathfindVisitedLists.Add(PathfindVisitedL);
	if (Mathf.Approximately(PathfindVisitedL[0], TargetPositionArray[0]) && Mathf.Approximately(PathfindVisitedL[1], TargetPositionArray[1]))
	{
	BreakVar = true;
	break;
	}
	}
	
	if ((!NavMesh.Raycast(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]), (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.right), out hit, 1)) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.right).x, PathfindVisitedLists[j][0])) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.right).z, PathfindVisitedLists[j][1])))
	{
	PathfindVisitedL = new List<float>() {(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.right).x, (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.right).z, i, Vector3.Distance(new Vector3(TargetPositionArray[0], 0 ,TargetPositionArray[1]), (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.right))};
	PathfindVisitedLists.Add(PathfindVisitedL);
	if (Mathf.Approximately(PathfindVisitedL[0], TargetPositionArray[0]) && Mathf.Approximately(PathfindVisitedL[1], TargetPositionArray[1]))
	{
	BreakVar = true;
	break;
	}
	}
	
	if ((!NavMesh.Raycast(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]), new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.left, out hit, 1)) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.left).x, PathfindVisitedLists[j][0])) && (!Mathf.Approximately((new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.left).z, PathfindVisitedLists[j][1])))
	{
	PathfindVisitedL = new List<float>() {(new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.left).x, (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.left).z, i, Vector3.Distance(new Vector3(TargetPositionArray[0], 0 ,TargetPositionArray[1]), (new Vector3 (PathfindVisitedLists[i][0], 0, PathfindVisitedLists[i][1]) + Vector3.left))};
	PathfindVisitedLists.Add(PathfindVisitedL);
	if (Mathf.Approximately(PathfindVisitedL[0], TargetPositionArray[0]) && Mathf.Approximately(PathfindVisitedL[1], TargetPositionArray[1]))
	{
	BreakVar = true;
	break;
	}
	}
	
	}
	
	
	}
	
	for(int i = Mathf.FloorToInt(PathfindVisitedLists[PathfindVisitedLists.Count - 1][2]); i > -1 ; i--)
	{
		
	if (i == Mathf.FloorToInt(PathfindVisitedLists[PathfindVisitedLists.Count - 1][2]))
	{
	//PathLists.Add(PathfindVisitedLists[i]);
	//PathLists[0] == new List<float>() {PathfindVisitedLists[i][0],PathfindVisitedLists[i][1],PathfindVisitedLists[i][2],PathfindVisitedLists[i][3]};
	PathLists[0][0] = PathfindVisitedLists[PathfindVisitedLists.Count - 1][0];
	PathLists[0][1] = PathfindVisitedLists[PathfindVisitedLists.Count - 1][1];
	PathLists[0][2] = PathfindVisitedLists[PathfindVisitedLists.Count - 1][2];
	PathLists[0][3] = PathfindVisitedLists[PathfindVisitedLists.Count - 1][3];
	for(int j = PathfindVisitedLists.Count - 2; j > -1 ; j--)
	{
	if (PathfindVisitedLists[j][2] == PathfindVisitedLists[PathfindVisitedLists.Count - 1][2])
	{
	PathfindVisitedLists.RemoveAt(j);
	}
	}
	}
	
	for(int j = PathfindVisitedLists.Count - 1; j > -1 ; j--)
	{
	if (((Vector3.Distance(new Vector3(PathfindVisitedLists[j][0], 0, PathfindVisitedLists[j][1]), new Vector3(PathLists[PathLists.Count - 1][0], 0, PathLists[PathLists.Count - 1][1])) >= 0.8f) && ((Vector3.Distance(new Vector3(PathfindVisitedLists[j][0], 0, PathfindVisitedLists[j][1]), new Vector3(PathLists[PathLists.Count - 1][0], 0, PathLists[PathLists.Count - 1][1])) <= 1.2f))) && (PathfindVisitedLists[j][2] == i)) //(PathLists[PathLists.Count - 1][2] - 1)))
	{
	PathL = new List<float>() {PathfindVisitedLists[j][0], PathfindVisitedLists[j][1], PathfindVisitedLists[j][2], PathfindVisitedLists[j][3]};
	PathLists.Add(PathL);
	}
	
	} //Длина PathfindVisitedLists оказалась 1 (на исправление)
	
	if (i == 0)
	{
	PathfindVisitedLists.Clear();
	Debug.Log(PathLists[0][0]);
	Debug.Log(PathLists[0][1]);
	Debug.Log(PathLists[1][0]);
	Debug.Log(PathLists[1][1]);
	Debug.Log(MarkLists[0][0]);
	Debug.Log(MarkLists[0][1]);
	Debug.Log(MarkLists[1][0]);
	Debug.Log(MarkLists[1][1]);
	}
	
	}
	
	ChooseMove = true;
	OnlyVisited = 2;
	}
	
	if(((PathLists.Count - 1) > 0) && (ChooseMove == true) && (OnlyVisited == 2))
	{
	TargetPositionArray[0] = PathLists[PathLists.Count - 1][0];
	TargetPositionArray[1] = PathLists[PathLists.Count - 1][1];
	if (PathLists.Count > 1)
	{
	PathLists.RemoveAt(PathLists.Count - 1);
	}
	
	Timer = 1;
	
	if ((Mathf.Approximately(TargetPositionArray[0] , (transform.position + (transform.forward)).x) && Mathf.Approximately(TargetPositionArray[1] , (transform.position + (transform.forward)).z)))
	{
	Timer = 2;	
	}
	
	PowerMoveFlag = true;
	PowerRotateFlag = true;
	}
	
	ChooseMove = false;
	//if (TargetPositionArray[1] != null)
	//{
	
	
	
	if (Mathf.Approximately(TargetPositionArray[0] , ((float)System.Math.Round((transform.position + (transform.forward * (-1))).x, 1))) && Mathf.Approximately(TargetPositionArray[1] , ((float)System.Math.Round((transform.position + (transform.forward * (-1))).z, 1))) )
	{
		Timer = 0;
		//var step =  1 * Time.deltaTime; // calculate distance to move
	}
	else 
	if ((Timer > 0) && (!Mathf.Approximately(TargetPositionArray[0] , (transform.position + (transform.forward * (-1))).x) || !Mathf.Approximately(TargetPositionArray[1] , (transform.position + (transform.forward * (-1))).z)))
	{
	transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(transform.forward, new Vector3((float)System.Math.Round(TargetPositionArray[0], 1) - (float)System.Math.Round(transform.position.x, 1), 0f, (float)System.Math.Round(TargetPositionArray[1], 1) - (float)System.Math.Round(transform.position.z, 1))*(-1), 2f*Time.deltaTime, 0.0f));
	
	if (Timer == 1)
	{
	PowerRotateFlag = true;
	}
	
	if (PowerRotateFlag == true)
	{
	MyPower = MyPower - 5;
	PowerRotateFlag = false;
	}
	}
	//} 
	
	
	
	if (Timer <= 0)
	{
	transform.position = Vector3.MoveTowards(transform.position, new Vector3(TargetPositionArray[0], transform.position.y, TargetPositionArray[1]), Time.deltaTime);	
	if (PowerMoveFlag == true)
	{
	
	MyPower = MyPower - 10;
	PowerMoveFlag = false;
	}
	}
	
	if (Mathf.Approximately(transform.position.x , TargetPositionArray[0]) && Mathf.Approximately(transform.position.z , TargetPositionArray[1]))
	{
		
	transform.position = new Vector3(TargetPositionArray[0],0,TargetPositionArray[1]);
		
	for(int i = 0; i < VisitedArray.Length; i++)
	{
	if (Mathf.Approximately(transform.position.x , VisitedArray[i][0]) && Mathf.Approximately(transform.position.z , VisitedArray[i][1]))
	{
	break;
	}
	if ( i == (VisitedArray.Length - 1))
	{
	VisitedArray[BotStep][0] = transform.position.x;	
	VisitedArray[BotStep][1] = transform.position.z;	
	BotStep += 1;	
	}
	}
	
	
	ChooseMove = true;
	
	for(int i = 0; i < PriorArray.Length; i++)
	{
	PriorArray[i][0] = -999;
	PriorArray[i][1] = -999;
	}
	
	
	//if(PathLists.Count == 1)
	//{
	//PathLists[0][0] = -999;
	//PathLists[0][1] = -999;
	//PathLists[0][2] = -999;
	//PathLists[0][3] = -999;
	//OnlyVisited = 0;	
	//}
	
	}
	//}
	
	if (Timer > 0)
	{
	
	Timer = Timer - Time.deltaTime;
	}
	
    }
	
	
    }
	
	
    }
