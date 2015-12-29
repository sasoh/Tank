using UnityEngine;

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
        Vector3 position = new Vector3
        {
            x = input.Horizontal*StepSize*Time.deltaTime,
            z = input.Vertical*StepSize*Time.deltaTime
        };

        Agent.Move(position);
    }
}
