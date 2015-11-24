using UnityEngine;
using System.Collections;
using System.Threading;

public enum MoveType
{
    MoveForward,
    MoveBack,
    MoveLeft,
    MoveRight
}

public class MoveScript : MonoBehaviour 
{
    const int MAX_X = 10;
    const int MAX_Z = 10;

    Thread moveThread;

    bool moving = false;

	void Start () 
    {
        
	}
	
	
	void Update () 
    {
             
	}

    void SetupMove()
    {
        float moveTime = 5;

        Vector3 start = transform.position;
        Vector3 target = transform.position;

        int movement = Random.Range(0, 4);

        moving = true;

        switch (movement)
        {
            case ((int)MoveType.MoveForward):
                target = target + (Vector3.forward * moveTime);
                break;
            case ((int)MoveType.MoveBack):
                target = target + (Vector3.back * moveTime);
                break;
            case ((int)MoveType.MoveRight):
                target = target + (Vector3.right * moveTime);
                break;
            case ((int)MoveType.MoveLeft):
                target = target + (Vector3.left * moveTime);
                break;
        }
        moveThread = new Thread(() => Move(moveTime, start, target));
        moveThread.Start();
    }

    void Move(float moveTime, Vector3 startPos, Vector3 endPos)
    {
        float elapsedTime = 0;

        while (elapsedTime < moveTime)
        {
            transform.position = Vector3.Lerp(startPos, endPos, (elapsedTime / moveTime));
            CheckBounds();
            elapsedTime += Time.deltaTime;
        }
        moving = false;
        Debug.Log("Movement complete");
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