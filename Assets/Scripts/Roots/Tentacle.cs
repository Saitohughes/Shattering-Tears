using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Tentacle : MonoBehaviour
{
    [SerializeField]
    int lenght;
    [SerializeField]
    private LineRenderer myTail;
    [SerializeField] private Vector3[] SegmentPoses;
    private Vector3[] SegmentsV;
    [SerializeField] float maxLength;
    [SerializeField] Transform targetDir;
    [SerializeField] Transform lastSegment;
    [SerializeField] float targetDist;
    [SerializeField] float smoothSpeed;
    [SerializeField] float trailspeed;

    float distancetoPoint;
    RotateToTarget myRoot;

    [SerializeField] Transform[] bodyParts;
    private void Awake()
    {
        myRoot = GetComponentInParent<RotateToTarget>();
    }
    // Start is called before the first frame update
    void Start()
    {
        myTail.positionCount = lenght;
        SegmentPoses = new Vector3[lenght];
        SegmentsV = new Vector3[lenght];
        distancetoPoint = maxLength / lenght;
    
    }

    // Update is called once per frame
    void Update()
    {
        SegmentPoses[0] = targetDir.position;
        SegmentPoses[SegmentPoses.Length-1] = lastSegment.position;
        for (int i = 1; i < SegmentPoses.Length; i++)
        {
            float d = Vector3.Distance(SegmentPoses[i], SegmentPoses[i - 1]);
            if (d>=distancetoPoint)
            {
                SegmentPoses[i] = Vector3.SmoothDamp(SegmentPoses[i], SegmentPoses[i - 1] + targetDir.right * targetDist, ref SegmentsV[i], smoothSpeed + i / trailspeed);
                //bodyParts[i - 1].transform.position = SegmentPoses[i]; 
            }
        }
        myTail.SetPositions(SegmentPoses);
        float distance = Vector3.Distance(myTail.GetPosition(0), myTail.GetPosition(SegmentPoses.Length - 1));
        if (distance >=maxLength)
        {
            myRoot.Follow = false;
        }
        else
        {
            myRoot.Follow = true;   
        }

       //myTail.GetPosition(SegmentPoses.Length - 1).Set(lastSegment.position.x,lastSegment.position.y,lastSegment.position.z);
        //lastSegment.position = SegmentPoses[SegmentPoses.Length - 1];
        
    }
}
