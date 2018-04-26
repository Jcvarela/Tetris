using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class Shape : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
	    bool a = RemoveIfEmpty();

        Debug.Log(a);

        RemoveElementAt(new Vector3(1, 11, 0));

        Vector3[] b = GetVectorSpace();

	  

	    foreach (var i in b)
	    {
	        Debug.Log(i);
	    }

	}

    public bool RemoveElementAt(Vector3 pos)
    {
        Transform[] chiTransforms = GetAllObjects();
        if (chiTransforms == null || chiTransforms.Length == 0)
        {
            return false;
        }

        foreach (var i in chiTransforms)
        {
            if (EqualToEachOther(i.position,pos))
            {
                Destroy(i.gameObject);
                return true;
            }
        }

        return false;
    }

    private bool EqualToEachOther(Vector3 a1, Vector3 a2)
    {
        Vector3 dif = a1 - a2;

        return dif.magnitude < 0.10;
    }

    public Vector3[] GetVectorSpace()
    {
        Transform[] childrenTransforms = GetAllObjects();
        
        if (childrenTransforms == null || childrenTransforms.Length == 0)
        {
            return null;
        }

        Vector3[] output = new Vector3[childrenTransforms.Length];

        for (int i =0; i < output.Length; i++)
        {
            output[i] = childrenTransforms[i].position;
        }

        return output;

    }

    public bool RemoveIfEmpty()
    {
        Transform[] temp = GetAllObjects();

        if (temp == null || temp.Length == 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    private Transform[] GetAllObjects()
    {
        Transform[] temp = GetComponentsInChildren<Transform>();
        Transform[] output = new Transform[temp.Length - 1];

        int inc = 0;
        foreach (var i in temp)
        {
            if (i.gameObject != gameObject)
            {
                output[inc++] = i;
            }
        }

        return output;
    }

}
