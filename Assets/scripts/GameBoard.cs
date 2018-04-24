using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;



public class GameBoard : MonoBehaviour
{

    [SerializeField] private GameObject[] pieces;

    private GameObject active;
    private GameObject nextPiece;



    // Use this for initialization
    void Start ()
    {
        CreateNewPiece();
        CreateNewPiece();
    }
	
	// Update is called once per frame
	void Update () {



        if (ActiveStopMoving())
	    {
            CreateNewPiece();
	    }
	}


    public void UpdateActivePieceVel()
    {
        Vector3 velocity = new Vector3(0, -1.5f, 0);
        Vector3 acceleration = velocity / 3f;

        Rigidbody ridB = active.GetComponent<Rigidbody>();
        Vector3 ActiveVel = ridB.velocity;

        if (ActiveVel.y < velocity.y)
        {
            ridB.velocity -= acceleration;
        }

       
    }

    public bool ActiveStopMoving()
    {
        Rigidbody ridB = active.GetComponent<Rigidbody>();
        if (ridB.velocity.magnitude == 0)
        {
            return true;
        }

        return false;
    }

    public void CreateNewPiece()
    {
        GameObject obj = GetRandomPiece();

        SetActive(nextPiece);
        SetNextPiece(obj);
    }

    private void SetNextPiece(GameObject obj)
    {
        if (obj == null) return;

        nextPiece = obj;
        Vector3 position = new Vector3(0, -4, 0);

        nextPiece.transform.position = position;

    }

    private void SetActive(GameObject obj)
    {
        if (obj == null) return;

        active = obj;
        Vector3 position = new Vector3(0, 10, 0);
        Vector3 velocity = new Vector3(0, -1.5f, 0);

        active.transform.position = position;
        Rigidbody ridB = active.GetComponent<Rigidbody>();
        ridB.velocity = velocity;
    }

    public GameObject GetRandomPiece()
    {
        int index = Random.Range(0,pieces.Length);
        Vector3 position = new Vector3(0,10,0);

        GameObject obj = Instantiate(pieces[index], position, Quaternion.identity);

        Rigidbody ridB = obj.GetComponent<Rigidbody>();

        ridB.useGravity = false;       
        
        return obj;
    }
}
