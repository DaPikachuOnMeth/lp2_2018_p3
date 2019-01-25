using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script used to lock the rotation of the child object. DO NOT USE PHYSICS IT
/// WITH PHYSICS MOVEMENT OR IT BREAKS.
/// </summary>
public class Lock : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = Quaternion.LookRotation(Vector3.down, Vector3.forward);
        transform.rotation = rotation;
    }
}
