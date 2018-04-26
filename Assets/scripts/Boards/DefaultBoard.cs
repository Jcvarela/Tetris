using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBoard : Board
{

    //row by col
    [SerializeField] private Transform[,] elementsInBoard = new Transform[20,10];

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
