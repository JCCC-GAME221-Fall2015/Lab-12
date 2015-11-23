using UnityEngine;
using System.Collections;

public class NonThreadedMoveScript : MonoBehaviour
{
    const int MAX_X = 10;
    const int MAX_Z = 10;

    bool moving = false;

    void Start()
    {
        StartCoroutine(Move());
    }

    void Update()
    {
        if (!moving) { StartCoroutine(Move()); }
    }

    IEnumerator Move()
    {
        float moveTime = 5;
        MoveType moveType;

        Vector3 start = transform.position;
        Vector3 target = transform.position;
        moveType = (MoveType)Random.Range(0, 4);

        //Debug.Log("Start position:  " + start);
        //Debug.Log("Move type: " + moveType);

        switch (moveType)
        {
            case (MoveType.MoveForward):
                target = target + (Vector3.forward * moveTime);
                break;
            case (MoveType.MoveBack):
                target = target + (Vector3.back * moveTime);
                break;
            case (MoveType.MoveRight):
                target = target + (Vector3.right * moveTime);
                break;
            case (MoveType.MoveLeft):
                target = target + (Vector3.left * moveTime);
                break;
        }

        //Debug.Log("Target position: " + target);
        
        float elapsedTime = 0;
        moving = true;
        //Debug.Log("Moving . . . . . . ");

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(start, target, (elapsedTime / moveTime));
            elapsedTime += Time.deltaTime;
            yield return null;
            if (transform.position.x > MAX_X || transform.position.x < -MAX_X || transform.position.z > MAX_Z || transform.position.z < -MAX_Z)
                CheckBounds();
        }

        moving = false;
        //Debug.Log("Movement complete");
    }

    void CheckBounds()
    {
        Vector3 mirrorPos = transform.position;

        if (transform.position.x > MAX_X)
        {
            mirrorPos.x = -MAX_X;
            transform.position = mirrorPos;
        }
        if (transform.position.x < -MAX_X)
        {
            mirrorPos.x = MAX_X;
            transform.position = mirrorPos;
        }
        if (transform.position.z > MAX_Z)
        {
            mirrorPos.z = -MAX_Z;
            transform.position = mirrorPos;
        }
        if (transform.position.z < -MAX_Z)
        {
            mirrorPos.z = MAX_Z;
            transform.position = mirrorPos;
        }
    }
}
