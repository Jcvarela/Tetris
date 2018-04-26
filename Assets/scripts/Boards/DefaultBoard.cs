using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBoard : Board
{

    //TODO: MUST FOLLOW THIS STANDARD!!!!!!!!!!!!!!!!!!!!!
    //row by col
    //x -> row 
    //y -> col
    [SerializeField] private Transform[,] elementsInBoard = new Transform[20,10];


    [SerializeField] private GameObject s;

    // Use this for initialization
    void Start ()
    {

        GameObject obj = Instantiate(s, new Vector3(0,1,0), Quaternion.identity);


        GetChildrenFromShape(obj.GetComponent<Shape>());

        GameObject obj2 = Instantiate(s, new Vector3(0, 3, 0), Quaternion.identity);
        Shape sha = obj2.GetComponent<Shape>();

        Debug.Log("Can IT Move " + CanShapeMoveTo(sha,new Vector3(0,2,0)));

    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public bool GetChildrenFromShape(Shape shape)
    {
        Transform[] elements = shape.GetAllChildTransform();
        if (elements == null || elements.Length == 0) return true;

        foreach (Transform i in elements)
        {
            i.parent = null;

            if (IsBoardEmptyAt(i.position))
            {
                AddElementAt(i, i.position);
            }

        }

        Destroy(shape);
        return true;
    }

    public bool AddElementAt(Transform ele, Vector3 pos)
    {
        int row = GetRow(pos);
        int col = GetCol(pos);

        if (IsOutOfBound(row, col)) return true;

        elementsInBoard[row, col] = ele;

        return true;
    }

    public bool CanShapeMoveTo(Shape shape, Vector3 incPos)
    {
        Vector3[] positions = shape.GetVectorSpace();
        if (positions == null || positions.Length == 0) return true;


        foreach (Vector3 i in positions)
        {
            Vector3 newPos = i + incPos;
            if (!IsBoardEmptyAt(newPos))
            {
                return false;
            }
        }

        return true;
    }

    public bool RemoveElementAt(Vector2 pos)
    {
        int row = GetRow(pos);
        int col = GetCol(pos);

        if (!IsBoardEmptyAt(row, col))
        {
            Transform ele = elementsInBoard[row, col];
            Destroy(ele);
            elementsInBoard[row, col] = null;
        }

        return true;
    }

    public bool IsBoardEmptyAt(Vector2 pos)
    {
        int row = GetRow(pos);
        int col = GetCol(pos);
        return IsBoardEmptyAt(row, col);
    }

    public bool IsBoardEmptyAt(int row, int col)
    {
        if (IsOutOfBound(row, col)) return false;

        return (elementsInBoard[row, col] == null);
    }

    public bool IsOutOfBound(int row, int col)
    {

        if (row < 0 || row >= elementsInBoard.Length)  return true;
        
        if (col < 0 || col >= elementsInBoard.GetLength(1))  return true;
        
        return false;
    }

    private int GetRow(Vector3 pos)
    {
        return Mathf.RoundToInt(pos.x);
    }

    private int GetCol(Vector3 pos)
    {
        return Mathf.RoundToInt(pos.y);
    }
}
