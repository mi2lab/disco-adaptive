using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target2Mover : MonoBehaviour
{
    public Transform target;
    public float moveSpeed = 2.5f;
    private Player2Controller playerController;

    void Start()
    {
        playerController = FindObjectOfType<Player2Controller>();
    }

    void Update()
    {
        if (playerController.positionData.neutral == 1)
        {
            MoveTarget(playerController.neutralVector);
        }
        if (playerController.positionData.speaker1 == 1)
        {
            MoveTarget(playerController.speaker1Vector);
        }
        else if (playerController.positionData.speaker2 == 1)
        {
            MoveTarget(playerController.speaker2Vector);
        }
        else if (playerController.positionData.speaker3 == 1)
        {
            MoveTarget(playerController.speaker3Vector);
        }
    }

    public void MoveTarget(Vector3 targetPosition)
    {
        if (target != null)
        {
            target.position = targetPosition;
            //Quaternion targetRotation = Quaternion.LookRotation(targetPosition - target.position);
            //target.rotation = Quaternion.Lerp(target.rotation, targetRotation, moveSpeed * Time.deltaTime);
        }
    }
}
