using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class setupBoard : MonoBehaviour
{
    public GameObject bPawn;
    public GameObject bKing;
    public GameObject bQueen;
    public GameObject bBishop;
    public GameObject bKnight;
    public GameObject bRook;
    
    public GameObject wPawn;
    public GameObject wKing;
    public GameObject wQueen;
    public GameObject wBishop;
    public GameObject wKnight;
    public GameObject wRook;
    // Start is called before the first frame update
    void Start()
    {
        //White part of the board
        Instantiate(wPawn, Position.A2, Quaternion.identity);
        Instantiate(wPawn, Position.B2, Quaternion.identity);
        Instantiate(wPawn, Position.C2, Quaternion.identity);
        Instantiate(wPawn, Position.D2, Quaternion.identity);
        Instantiate(wPawn, Position.E2, Quaternion.identity);
        Instantiate(wPawn, Position.F2, Quaternion.identity);
        Instantiate(wPawn, Position.G2, Quaternion.identity);
        Instantiate(wPawn, Position.H2, Quaternion.identity);
        
        Instantiate(wRook, Position.A1, Quaternion.identity);
        Instantiate(wKnight, Position.B1, Quaternion.identity);
        Instantiate(wBishop, Position.C1, Quaternion.identity);
        Instantiate(wQueen, Position.D1, Quaternion.identity);
        Instantiate(wKing, Position.E1, Quaternion.identity);
        Instantiate(wBishop, Position.F1, Quaternion.identity);
        Instantiate(wKnight, Position.G1, Quaternion.identity);
        Instantiate(wRook, Position.H1, Quaternion.identity);
        
        
        //Black part of the board
        Instantiate(bPawn, Position.A7, Quaternion.identity);
        Instantiate(bPawn, Position.B7, Quaternion.identity);
        Instantiate(bPawn, Position.C7, Quaternion.identity);
        Instantiate(bPawn, Position.D7, Quaternion.identity);
        Instantiate(bPawn, Position.E7, Quaternion.identity);
        Instantiate(bPawn, Position.F7, Quaternion.identity);
        Instantiate(bPawn, Position.G7, Quaternion.identity);
        Instantiate(bPawn, Position.H7, Quaternion.identity);
        
        Instantiate(bRook, Position.A8, Quaternion.identity);
        Instantiate(bKnight, Position.B8, Quaternion.identity);
        Instantiate(bBishop, Position.C8, Quaternion.identity);
        Instantiate(bQueen, Position.D8, Quaternion.identity);
        Instantiate(bKing, Position.E8, Quaternion.identity);
        Instantiate(bBishop, Position.F8, Quaternion.identity);
        Instantiate(bKnight, Position.G8, Quaternion.identity);
        Instantiate(bRook, Position.H8, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
