using UnityEngine;
using System.Collections;


public class PlayerMovementScript : MonoBehaviour
{
    public float StepSize = 1.0f; // m/s
    NavMeshAgent Agent;

    void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
        Debug.Assert(Agent != null);
    }

    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        InputData input = InputManager.Instance.GetInput();

        // move 
        Vector3 position = new Vector3();
        position.x = input.Horizontal * StepSize * Time.deltaTime;
        position.z = input.Vertical * StepSize * Time.deltaTime;
        //transform.position = position;

        Agent.Move(position);
    }
}
