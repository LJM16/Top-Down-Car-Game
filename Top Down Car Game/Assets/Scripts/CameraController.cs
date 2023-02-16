using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject ObjectToFollow;
    public float FollowOffset = 0;

    private CarController _carControllweScript;

    // Start is called before the first frame update
    void Start()
    {
        _carControllweScript = GameObject.Find("Player").GetComponent<CarController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_carControllweScript.CrossedFinishLine())
        {
            transform.position = new Vector3(0f, ObjectToFollow.transform.position.y + FollowOffset, -10f);
        }
    }
}
