using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TentacleTo : MonoBehaviour
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

    [SerializeField] float wiggleSpeed;
    [SerializeField] float wiggleMagnitude;
    [SerializeField] Transform wiggleDir;


    RotateToTarget myRoot;

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

    }

    // Update is called once per frame
    void Update()
    {
        SegmentPoses[0] = targetDir.position;
        SegmentPoses[SegmentPoses.Length - 1] = lastSegment.position;

        wiggleDir.localRotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * wiggleSpeed) * wiggleMagnitude);

        for (int i = 1; i < SegmentPoses.Length; i++)
        {
            Vector3 targetPos = SegmentPoses[i - 1] + (SegmentPoses[i] - SegmentPoses[i - 1]).normalized * targetDist;
            SegmentPoses[i] = Vector3.SmoothDamp(SegmentPoses[i], targetPos, ref SegmentsV[i], smoothSpeed);
        }
        myTail.SetPositions(SegmentPoses);
        float distance = Vector3.Distance(myTail.GetPosition(0), myTail.GetPosition(SegmentPoses.Length - 1));
        if (distance >= maxLength)
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
