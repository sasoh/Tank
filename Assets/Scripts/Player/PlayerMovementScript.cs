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
        
        Vector3 position = new Vector3();
        position.x = input.Movement.x * StepSize * Time.deltaTime;
        position.z = input.Movement.y * StepSize * Time.deltaTime;

        Agent.Move(position);
    }
}
