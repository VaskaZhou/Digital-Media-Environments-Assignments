using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float idleTime = 0.5f;
    public float moveRange = 5f;

    private Vector3 targetPosition;
    private float idleTimer;

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        MoveTowardsTarget();

        if (IsAtTargetPosition())
        {
            idleTimer += Time.deltaTime;

            if (idleTimer >= idleTime)
            {
                SetRandomTargetPosition();
                idleTimer = 0f;
            }
        }
    }

    void MoveTowardsTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    bool IsAtTargetPosition()
    {
        return Vector3.Distance(transform.position, targetPosition) < 0.1f;
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-moveRange / 2f, moveRange / 2f);
        float randomZ = Random.Range(-moveRange / 2f, moveRange / 2f);

        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
        idleTime= Random.Range(0.05f, 0.9f);

    }
}
