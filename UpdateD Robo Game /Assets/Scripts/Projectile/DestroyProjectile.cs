﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyProjectile : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
	void Awake () {
        Destroy(this.gameObject,aliveTime);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}