using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.AnimatedValues;
using UnityEngine;

public class Shape : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
//	    bool a = RemoveIfEmpty();
//
//        Debug.Log(a);
//
//        //RemoveElementAt(new Vector3(1, 11, 0));
//	    RotateShapeBy(new Vector3(0, 0, 90));
//	    RotateShapeBy(new Vector3(0, 0, 90));
//        Vector3[] b = GetVectorSpace();
//
//	    foreach (var i in b)
//	    {
//	        Debug.Log(i);
//	    }

	}

    //    public bool RemoveElementAt(Vector3 pos)
    //    {
    //        Transform[] chiTransforms = GetAllChildTransform();
    //        if (chiTransforms == null || chiTransforms.Length == 0)
    //        {
    //            return false;
    //        }
    //
    //        foreach (var i in chiTransforms)
    //        {
    //            if (EqualToEachOther(i.position,pos))
    //            {
    //                Destroy(i.gameObject);
    //                return true;
    //            }
    //        }
    //
    //        return false;
    //    }

    /// <summary>
    /// Rotate Shape by givin degree 
    ///     exp new Vector(0,0,180);
    /// </summary>
    /// <param name="eulerVector3"></param>
    /// <returns>Returns true if it was able to rotate</returns>
    public bool RotateShapeBy(Vector3 eulerVector3)
    {
        eulerVector3 += transform.rotation.eulerAngles;
        transform.rotation = Quaternion.Euler(eulerVector3);

        return true;
    }

    private bool EqualToEachOther(Vector3 a1, Vector3 a2)
    {
        Vector3 dif = a1 - a2;

        return dif.magnitude < 0.10;
    }

    /// <summary>
    /// Get an array of Vector3 that represent the spaces the shape occupies
    /// </summary>
    /// <returns></returns>
    public Vector3[] GetVectorSpace()
    {
        Transform[] childrenTransforms = GetAllChildTransform();
        
        if (IsEmpty(childrenTransforms))
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

    /// <summary>
    /// Delete shape if it doesn't have any children
    /// </summary>
    /// <returns></returns>
    public bool RemoveIfEmpty()
    {
        Transform[] temp = GetAllChildTransform();

        if (temp == null || temp.Length == 0)
        {
            Destroy(gameObject);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Get all the child for this shape GameObject 
    /// </summary>
    /// <returns></returns>
    public Transform[] GetAllChildTransform()
    {
        Transform[] temp = GetComponentsInChildren<Transform>();
        if (IsEmpty(temp))
        {
            return null;
        }

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

    private bool IsEmpty(System.Object[] objA)
    {
        if (objA == null || objA.Length == 0)
        {
            return true;
        }

        return false;
    }
}
