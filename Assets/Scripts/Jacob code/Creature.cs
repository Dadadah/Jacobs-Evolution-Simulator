﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creature : MonoBehaviour
{
    
    public Leg[] legs;
    Transform tran;
    Vector3 startLoc;
    Quaternion startRot;
    [HideInInspector]
    public bool dead = false;
    [HideInInspector]
    public float survivalChance = 0.0f;

    // Use this for initialization
    void Start () {
        tran = gameObject.GetComponent(typeof(Transform)) as Transform;
        startLoc = tran.position;
        startRot = tran.rotation;
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].SetMove(new Move[2] { new Move(Random.rotation, Mathf.Clamp(Random.value, 0.1f, 1)*10), new Move(Random.rotation, Mathf.Clamp(Random.value, 0.1f, 1) * 10) });
        }
    }

    public void Randomize ()
    {
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].SetMove(new Move[2] { new Move(Random.rotation, Mathf.Clamp(Random.value, 0.1f, 1) * 10), new Move(Random.rotation, Mathf.Clamp(Random.value, 0.1f, 1) * 10) });
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Reset ()
    {
        dead = false;
        Rigidbody rb = gameObject.GetComponent(typeof(Rigidbody)) as Rigidbody;
        rb.isKinematic = true;
        tran.position = startLoc;
        tran.rotation = startRot;
        rb.isKinematic = false;

        foreach (Leg leg in legs)
        {
            leg.Reset();
        }

    }

    public void ChangeLegs(Move[] mv)
    {
        for (int i = 0; i < legs.Length; i++)
        {
            legs[i].SetMove(new Move[2] { mv[i*2], mv[(i*2)+1]});
        }
    }

    public Move[] WatRMyLegs()
    {
        Move[] mvs = new Move[legs.Length*2];
        for (int i = 0; i < legs.Length; i++)
        {
            mvs[i*2] = legs[i].GetMove()[0];
            mvs[i*2 + 1] = legs[i].GetMove()[1];
        }
        return mvs;
    }

    public float GetDistanceTraveled()
    {
        return Vector3.Distance(new Vector3(tran.position.x,0,tran.position.z), new Vector3(startLoc.x,0,startLoc.z));
    }

    public static Creature Breed(Creature A , Creature B)
    {
        Debug.LogError("Creature Breed is Unimplemented!");
        return null;
    }
}
