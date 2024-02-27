using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : MonoBehaviour
{
    public struct DragonInfo
    {
        public bool gender;
        public bool grown;
        public bool interactive;//turn true after get out egg, turn false when mating/fighting
        public float age;
    }
    public DragonInfo dragonInfo;

    public GameObject Blood;
    public GameObject Heart;

    public float moveSpeed = 2f;
    public float idleTime = 0.5f;
    public float moveRange = 8f;

    private Vector3 targetPosition;
    private float idleTimer;

    void Start()
    {
        DragonsManager.instance.Dragons.Add(this);

        dragonInfo.grown = false;
        dragonInfo.interactive = false;
        dragonInfo.age = 0;
        SetRandomTargetPosition();
        GetComponent<BoxCollider>().enabled = true;
    }

    void Update()
    {
        dragonInfo.age += Time.deltaTime;

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
        idleTime = Random.Range(0.05f, 0.9f);
        transform.LookAt(targetPosition);
    }
    void OnTriggerEnter(Collider other)
    {
        if (dragonInfo.age < 1f || other.GetComponent<Dragon>().dragonInfo.age < 1f) return;//save kids
        if (Random.Range(0, 100) > 90f)//attack
        {
            Destroy(other.gameObject);
            GameObject b = Instantiate(Blood);
            b.transform.position= other.transform.position;
            b.transform.rotation = other.transform.rotation;
            return;
        }

        if (Random.Range(0, 100) > 80f&& other.GetComponent<Dragon>().dragonInfo.gender!=dragonInfo.gender&& DragonsManager.instance.Dragons.Count<18)//mate
        {
            DragonsManager.instance.CreateDragon();
            GameObject h = Instantiate(Heart);
            h.transform.position = other.transform.position;
            return;
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("YourLayerName"))
        {
            Debug.Log("Collision with object on specified layer!");
        }

        
    }
    private void OnDestroy()
    {
        DragonsManager.instance.Dragons.Remove(this);
    }
}
