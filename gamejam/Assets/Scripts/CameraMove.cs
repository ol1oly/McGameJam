using System.Collections;
using UnityEngine;
using WaypointSystem;

public class CameraMove : MonoBehaviour
{

    public float speed = 10f;

    public float timeBegin = 0;

    public WaypointAgent agent;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {

        Instruction wait = Instruction.Create(InstructionType.WaitSeconds, timeBegin);
        Instruction speedChange = Instruction.Create(InstructionType.ChangeSpeed, speed);
        Instruction next = Instruction.Create(InstructionType.GoNthWaypoints, 11);


        agent.InstructionList.Add(speedChange);
        agent.InstructionList.Add(wait);
        agent.InstructionList.Add(next);
        agent.OnObjectiveReached += AgentOnObjectiveReached;
        agent.ExecuteNextInstruction();

    }




    void AgentOnObjectiveReached()
    {
        Debug.Log("the camera has changed");
    }
}


