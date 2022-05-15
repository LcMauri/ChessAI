using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class MoveRules : MonoBehaviour
{
    
    //reference to GO in the scene 
    public GameObject bPawnA;
    public GameObject bPawnB;
    public GameObject bPawnC;
    public GameObject bPawnD;
    public GameObject bPawnE;
    public GameObject bPawnF;
    public GameObject bPawnG;
    public GameObject bPawnH;
    public GameObject bKing;
    public GameObject bQueen;
    public GameObject bBishopC;
    public GameObject bBishopF;
    public GameObject bKnightB;
    public GameObject bKnightG;
    public GameObject bRookA;
    public GameObject bRookH;
    
    public GameObject wPawnA;
    public GameObject wPawnB;
    public GameObject wPawnC;
    public GameObject wPawnD;
    public GameObject wPawnE;
    public GameObject wPawnF;
    public GameObject wPawnG;
    public GameObject wPawnH;
    public GameObject wKing;
    public GameObject wQueen;
    public GameObject wBishopC;
    public GameObject wBishopF;
    public GameObject wKnightB;
    public GameObject wKnightG;
    public GameObject wRookA;
    public GameObject wRookH;
    public GameObject[,] board;
    private bool WhiteTurn=true;
    private Vector3[,] boardToWorldPos;
    private bool bKingMoved;
    private bool bRookAMoved;
    private bool bRookHMoved;
    private bool wKingMoved;
    private bool wRookAMoved;
    private bool wRookHMoved;
    
    
    
    //Reference to prefab
    public GameObject wQueenPrefab;
    public GameObject bQueenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        board = new GameObject[8, 8];
        boardToWorldPos = new Vector3[8, 8];
        board[0, 0] = wRookA;
        board[1, 0] = wKnightB;
        board[2, 0] = wBishopC;
        board[3, 0] = wQueen;
        board[4, 0] = wKing;
        board[5, 0] = wBishopF;
        board[6, 0] = wKnightG;
        board[7, 0] = wRookH;
        
        board[0, 1] = wPawnA;
        board[1, 1] = wPawnB;
        board[2, 1] = wPawnC;
        board[3, 1] = wPawnD;
        board[4, 1] = wPawnE;
        board[5, 1] = wPawnF;
        board[6, 1] = wPawnG;
        board[7, 1] = wPawnH;
        
        board[0, 7] = bRookA;
        board[1, 7] = bKnightB;
        board[2, 7] = bBishopC;
        board[3, 7] = bQueen;
        board[4, 7] = bKing;
        board[5, 7] = bBishopF;
        board[6, 7] = bKnightG;
        board[7, 7] = bRookH;
        
        board[0, 6] = bPawnA;
        board[1, 6] = bPawnB;
        board[2, 6] = bPawnC;
        board[3, 6] = bPawnD;
        board[4, 6] = bPawnE;
        board[5, 6] = bPawnF;
        board[6, 6] = bPawnG;
        board[7, 6] = bPawnH;
        for (int i = 2; i < 6;i++)
        {
            for (int y = 0; y < 8;y++)
            {
                board[y, i] = null;
            }
        }
        
        

        
        for (int i = 0; i < 8;i++)
        {
            for (int y = 0; y < 8;y++)
            {
            boardToWorldPos[i, y] = new Vector3(-3.5f+i,-3.5f+y,-1);
             }
        }
    }



    void promotePiece(GameObject piece,Vector3 move)
    {
        switch (piece.name)
        {
            case "wPawnA" :
                this.wPawnA = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnA.GetComponent<Move>().board = gameObject;
                this.wPawnA.name = "wQueen";
                break;
            case "wPawnB" :    this.wPawnB = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnB.GetComponent<Move>().board = gameObject;
                this.wPawnB.name = "wQueen";

                break;
            case "wPawnC" :     this.wPawnC = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnC.GetComponent<Move>().board = gameObject;
                this.wPawnC.name = "wQueen";
                break;
            case "wPawnD" :     this.wPawnD = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnD.GetComponent<Move>().board = gameObject;
                this.wPawnD.name = "wQueen";
                break;
            case "wPawnE" :     this.wPawnE = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnE.GetComponent<Move>().board = gameObject;
                this.wPawnE.name = "wQueen";
                break;
            case "wPawnF" :     this.wPawnF = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnF.GetComponent<Move>().board = gameObject;
                this.wPawnF.name = "wQueen";
                break;
            case "wPawnG" :     this.wPawnG = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnG.GetComponent<Move>().board = gameObject;
                this.wPawnG.name = "wQueen";
                break;
            case "wPawnH" :     this.wPawnH = (GameObject) Instantiate(wQueenPrefab, move, piece.transform.rotation);
                this.wPawnH.GetComponent<Move>().board = gameObject;
                this.wPawnH.name = "wQueen";
                break;
            case "bPawnA" :     this.bPawnA = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnA.GetComponent<Move>().board = gameObject;
                this.bPawnA.name = "wQueen";
                break;
            case "bPawnB" : this.bPawnB = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnB.GetComponent<Move>().board = gameObject;
                this.bPawnB.name = "wQueen";

                break;
            case "bPawnC" : this.bPawnC = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnC.GetComponent<Move>().board = gameObject;
                this.bPawnC.name = "wQueen";

                break;
            case "bPawnD" : this.bPawnD = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnD.GetComponent<Move>().board = gameObject;
                this.bPawnD.name = "wQueen";

                break;
            case "bPawnE" :this.bPawnE = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnE.GetComponent<Move>().board = gameObject;
                this.bPawnE.name = "wQueen";

                break;
            case "bPawnF" : this.bPawnF = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnF.GetComponent<Move>().board = gameObject;
                this.bPawnF.name = "wQueen";

                break;
            case "bPawnG" :this.bPawnG = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnG.GetComponent<Move>().board = gameObject;
                this.bPawnG.name = "wQueen";

                break;
            case "bPawnH" :this.bPawnH = (GameObject) Instantiate(bQueenPrefab, move, piece.transform.rotation);
                this.bPawnH.GetComponent<Move>().board = gameObject;
                this.bPawnH.name = "wQueen";

                break;
        }
    }
     private bool isCheckedAfterMove(Vector3 move, GameObject piece)
    {
        return false;
    }
    
     
     public static float distance(Vector3 v1, Vector3 v2)
     {
         float a = (v1.x - v2.x);
         a = a * a;
         float b = (v1.y - v2.y);
         b = b * b;
        
         return (float) Math.Sqrt((a+b));
     }
     public Vector3 closestCell(Vector3 mousePos)
     {
         Vector3 closest = boardToWorldPos[0, 0];
         float minDist = distance(mousePos,boardToWorldPos[0, 0]);
         for (int i = 0; i < 8;i++)
         {
             for (int y = 0; y < 8;y++)
             {
                 if (distance(mousePos, boardToWorldPos[i, y]) < minDist)
                 {
                     closest = boardToWorldPos[i, y];
                     minDist = distance(mousePos, boardToWorldPos[i, y]);
                 }
             }
         }

         return closest;
     }

     private void setPLayedFalse()
     {
         for (int i = 0; i < 8;i++)
         {
             for (int y = 0; y < 8;y++)
             {
                 if (board[i, y] !=null)
                 {
                
                     board[i, y].GetComponent<Move>().played = false;
                 }
             }
         }
     }
     private void updateBoard(Vector3 actualPos,Vector3 move, GameObject piece)
     {
         for (int i = 0; i < 8;i++)
         {
             for (int y = 0; y < 8;y++)
             {
                 if (boardToWorldPos[i, y] == actualPos)
                 {
                     board[i, y] = null;
                 }
             }
         }
         
         for (int i = 0; i < 8;i++)
         {
             for (int y = 0; y < 8;y++)
             {
                 if (boardToWorldPos[i, y] == move)
                 {
                     board[i, y] = piece;
                 }
             }
         }
     }

     public GameObject posToBoard(Vector3 pos)
     {
         for (int i = 0; i < 8;i++)
         {
             for (int y = 0; y < 8;y++)
             {
                 if (boardToWorldPos[i, y] == pos)
                 {
                     return board[i, y];
                 }
             }
         }
         return null;
     }
     private bool sameTeam(GameObject go1, GameObject go2)
     {
         if (go1 != null && go2 != null)
         {
             char team1 = go1.name[0];
             char team2 = go2.name[0];
             if (team1 == team2)
             {
                 return true;
             }
         }

         return false;
     }

     private bool rockPermited(GameObject rook)
     {
         return true;
     }

     private bool attacked(Vector3 square)
     {
         return false;
     }
     public bool legalMoove(Vector3 move, GameObject piece)
     {
         switch (piece.name)
        {
            case "wPawnA" :
                if (!sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnB" :   if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnC" : if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnD" : if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnE" : if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnF" : if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnG" : if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wPawnH" :  if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 5].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,4].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y-1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y-1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y-1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y + 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y + 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[0, 1].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == 3.5f)
                                    {
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y+1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                
                        
                                if (move.y == 3.5f)
                                {
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "wKing" :
                if (!sameTeam(piece, posToBoard(move)))
                {
              
                }
                else
                {
                    if (isCheckedAfterMove(move, piece))
                    {
                        return false;
                    }
                    else
                    {
                        
                    }
                }

                break;
            case "wQueen" : 
                if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool diagHD=false;
                        bool diagHG = false;
                        bool diagBG = false;
                        bool diagBD = false;
                        bool haut = false;
                        bool bas = false;
                        bool gauche = false;
                        bool droite = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;
 
                        if (Math.Abs(difx) == Math.Abs(dify))
                        {
                            if (difx < 0) 
                            {
                                    if (dify < 0)
                                    {
                                        diagBG = true;
                                    }

                                    if (dify > 0)
                                    {
                                        diagHG = true;
                                    }
                                    
                            }else if (difx > 0)
                            {
                                if (dify < 0)
                                {
                                    diagBD = true;
                                }

                                if (dify > 0)
                                {
                                    diagHD = true;
                                }
                            }
                        }

                        if (difx == 0)
                        {
                            if (dify > 0)
                            {
                                haut = true;
                            }
                            if (dify < 0)
                            {
                                bas = true;
                            }
                        }

                        if (dify == 0)
                        {
                            if (difx > 0)
                            {
                                droite = true;
                            }
                            if (difx < 0)
                            {
                                gauche = true;
                            }
                        }

                        if (haut)
                        {
                            int i=1;
                            while (i < dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (bas)
                        {
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (gauche)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        
                        if (droite)
                        {
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        
                        if (diagBG)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHG)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+Math.Abs(i) , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagBD)
                        {

                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ Math.Abs(i), actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHD)
                        {
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                    }
                }
                break;
            case "wBishopC" :  if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool diagHD=false;
                        bool diagHG = false;
                        bool diagBG = false;
                        bool diagBD = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;
                        if (Math.Abs(difx) == Math.Abs(dify))
                        {
                            if (difx < 0) 
                            {
                                    if (dify < 0)
                                    {
                                        diagBG = true;
                                    }

                                    if (dify > 0)
                                    {
                                        diagHG = true;
                                    }
                                    
                            }else if (difx > 0)
                            {
                                if (dify < 0)
                                {
                                    diagBD = true;
                                }

                                if (dify > 0)
                                {
                                    diagHD = true;
                                }
                            }
                        }
                        
                        if (diagBG)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHG)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+Math.Abs(i) , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagBD)
                        {
                
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ Math.Abs(i), actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHD)
                        {
                      
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                    }
                }
                break;
            case "wBishopF" : if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool diagHD=false;
                        bool diagHG = false;
                        bool diagBG = false;
                        bool diagBD = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;
            
                        if (Math.Abs(difx) == Math.Abs(dify))
                        {
                            if (difx < 0) 
                            {
                                    if (dify < 0)
                                    {
                                        diagBG = true;
                                    }

                                    if (dify > 0)
                                    {
                                        diagHG = true;
                                    }
                                    
                            }else if (difx > 0)
                            {
                                if (dify < 0)
                                {
                                    diagBD = true;
                                }

                                if (dify > 0)
                                {
                                    diagHD = true;
                                }
                            }
                        }
                        
                        if (diagBG)
                        {
                         
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHG)
                        {
                        
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+Math.Abs(i) , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagBD)
                        {
                 
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ Math.Abs(i), actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHD)
                        {
                           
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                    }
                }
                break;
            case "wKnightB" :if (sameTeam(piece, posToBoard(move))){
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        float pieceX = piece.GetComponent<Move>().actualPos.x;
                        float pieceY = piece.GetComponent<Move>().actualPos.y;
                        if ((move.x == pieceX + 2 || move.x == pieceX - 2)&&(move.y==pieceY+1||move.y==pieceY-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                        if ((move.y == pieceY + 2 || move.y == pieceY - 2)&&(move.x==pieceX+1||move.x==pieceX-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                    }
                }
                break;
            case "wKnightG" :if (sameTeam(piece, posToBoard(move))){
               
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        float pieceX = piece.GetComponent<Move>().actualPos.x;
                        float pieceY = piece.GetComponent<Move>().actualPos.y;
                        if ((move.x == pieceX + 2 || move.x == pieceX - 2)&&(move.y==pieceY+1||move.y==pieceY-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                        if ((move.y == pieceY + 2 || move.y == pieceY - 2)&&(move.x==pieceX+1||move.x==pieceX-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                    }
                }
                break;
            case "wRookA" : if (sameTeam(piece, posToBoard(move)))
                {
                    if (posToBoard(move).name == "wKing" && !this.wRookHMoved && !this.wKingMoved)
                    {
                        int i = 1;
                        Vector3 pieceTransform = piece.GetComponent<Move>().actualPos;
                        while (i < 4)
                        {
                            if (posToBoard(new Vector3(pieceTransform.x + i, pieceTransform.y, pieceTransform.z)) !=
                                null)
                            {
                                return false;
                            }

                            if (attacked(new Vector3(pieceTransform.x + i, pieceTransform.y, pieceTransform.z)))
                            {
                                return false;
                            }

                            i++;
                        }

                        //TODO
                        if (rockPermited(piece))
                        {
                            board[0, 0] = null;
                            board[4, 0] = null;
                            board[3, 0] = wRookH;
                            board[2, 0] = wKing;
                            wKing.GetComponent<Move>().actualPos = new Vector3(move.x - 2, move.y,
                                move.z);
                            wKing.transform.position = new Vector3(move.x - 2, move.y,
                                move.z);
                            wRookA.GetComponent<Move>().actualPos = new Vector3(move.x - 1, move.y, move.z);
                            wKingMoved = true;
                            wRookAMoved = true;
                            return false;
                        }
                    }
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                 
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool haut = false;
                        bool bas = false;
                        bool gauche = false;
                        bool droite = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;

                        if (difx == 0)
                        {
                            if (dify > 0)
                            {
                                haut = true;
                            }
                            if (dify < 0)
                            {
                                bas = true;
                            }
                        }

                        if (dify == 0)
                        {
                            if (difx > 0)
                            {
                                droite = true;
                            }
                            if (difx < 0)
                            {
                                gauche = true;
                            }
                        }

                        if (haut)
                        {
                      
                            int i=1;
                            while (i < dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (bas)
                        {
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                   
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (gauche)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        
                        if (droite)
                        {
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                    }
                }
                break;
            case "wRookH" : if (sameTeam(piece, posToBoard(move)))
                {
                    if (posToBoard(move).name=="wKing"&&!this.wRookHMoved&&!this.wKingMoved)
                    {
                        int i=1;
                        Vector3 pieceTransform=piece.GetComponent<Move>().actualPos;
                        while (i < 4)
                        {
                            if (posToBoard(new Vector3(pieceTransform.x + i, pieceTransform.y, pieceTransform.z)) != null)
                            {
                                return false;
                            }

                            if (attacked(new Vector3(pieceTransform.x + i, pieceTransform.y, pieceTransform.z)))
                            {
                                return false;
                            }

                            i++;
                        }
                        //TODO
                        if (rockPermited(piece))
                        {
                            board[7, 0] = null;
                            board[4, 0] = null;
                            board[5, 0] = wRookH;
                            board[6, 0] = wKing;
                            wKing.GetComponent<Move>().actualPos = new Vector3(move.x + 2, move.y,
                                move.z);
                            wKing.transform.position = new Vector3(move.x + 2, move.y,
                                move.z);
                            wRookH.GetComponent<Move>().actualPos = new Vector3(move.x + 1, move.y, move.z);
                            wKingMoved = true;
                            wRookHMoved = true;
                            return false;
                        }
                    }
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                 
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool haut = false;
                        bool bas = false;
                        bool gauche = false;
                        bool droite = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;

                        if (difx == 0)
                        {
                            if (dify > 0)
                            {
                                haut = true;
                            }
                            if (dify < 0)
                            {
                                bas = true;
                            }
                        }

                        if (dify == 0)
                        {
                            if (difx > 0)
                            {
                                droite = true;
                            }
                            if (difx < 0)
                            {
                                gauche = true;
                            }
                        }

                        if (haut)
                        {
                      
                            int i=1;
                            while (i < dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.wRookHMoved = true;
                                return true;
                            }
                        }
                        if (bas)
                        {
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                   
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.wRookHMoved = true;
                                return true;
                            }
                        }
                        if (gauche)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.wRookHMoved = true;
                                return true;
                            }
                        }
                        
                        if (droite)
                        {
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.wRookHMoved = true;
                                return true;
                            }
                        }
                    }
                }
                break;
            case "bPawnA" :  if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                               
                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                               

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnB" :   if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                                 

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                                    

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnC" :  if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                                  

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                     
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                                  

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnD" :  if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                                 

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                  
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                                 

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnE" : if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                                 

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                   
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                               

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnF" :  if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                                 

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                    
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                             

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnG" :  if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                                   

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                  
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {
                                

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bPawnH" :  if (isCheckedAfterMove(move, piece))
                {
                    return false;
                }
                else
                {
                    if (move.y == boardToWorldPos[0, 2].y&&(move.x==piece.GetComponent<Move>().actualPos.x+1||move.x==piece.GetComponent<Move>().actualPos.x-1)&&piece.GetComponent<Move>().actualPos.y==boardToWorldPos[0,3].y)
                    {
                        if (posToBoard(new Vector3(move.x,move.y+1,move.z))!=null)
                        {
                            if (posToBoard(new Vector3(move.x,move.y+1,move.z)).GetComponent<Move>().played)
                            {
                                Destroy(posToBoard(new Vector3(move.x,move.y+1,move.z)));
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    if (move.x == piece.GetComponent<Move>().actualPos.x)
                    {
                        
                        if ((move.y == piece.GetComponent<Move>().actualPos.y - 1))
                        {
                            GameObject go = posToBoard(move);
                            if (go == null)
                            {
                                if (move.y == -3.5f)
                                {
                              

                                    promotePiece(piece,move);
                                    Destroy(piece);
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                setPLayedFalse();
                                return true;
                            }
                            else
                            {

                                return false;
                            }

                        } else if ((move.y == piece.GetComponent<Move>().actualPos.y - 2))
                        {
                            if (piece.GetComponent<Move>().actualPos.y == boardToWorldPos[1, 6].y)
                            {

                                GameObject go = posToBoard(move);
                                if (go == null)
                                {
                                    if (move.y == -3.5f)
                                    {
                                    
                                        promotePiece(piece,move);
                                        Destroy(piece);
                                    }
                                    updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                    setPLayedFalse();
                                    return true;
                                }
                                else
                                {

                                    return false;
                                }
                            }
                            else
                            {
                    
                                return false;
                            }
                        }
                    }else if ((move.x == piece.GetComponent<Move>().actualPos.x + 1 || move.x == piece.GetComponent<Move>().actualPos.x - 1)&&move.y==piece.GetComponent<Move>().actualPos.y-1)
                    {
                        GameObject go = posToBoard(move);
                        if (go == null)
                        {
                            return false;
                        }
                        else
                        {
                            if (!sameTeam(go, piece))
                            {
                                if (move.y == -3.5f)
                                {

                                    promotePiece(piece, move);
                                    Destroy(piece);
                                }

                                Destroy(go);
                                updateBoard(piece.GetComponent<Move>().actualPos, move, piece);
                                setPLayedFalse();
                                return true;
                            }
                        }
                    }
                    
                }
                break;
            case "bKing" :
                break;
            case "bQueen" : if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool diagHD=false;
                        bool diagHG = false;
                        bool diagBG = false;
                        bool diagBD = false;
                        bool haut = false;
                        bool bas = false;
                        bool gauche = false;
                        bool droite = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;
                        if (Math.Abs(difx) == Math.Abs(dify))
                        {
                            if (difx < 0) 
                            {
                                    if (dify < 0)
                                    {
                                        diagBG = true;
                                    }

                                    if (dify > 0)
                                    {
                                        diagHG = true;
                                    }
                                    
                            }else if (difx > 0)
                            {
                                if (dify < 0)
                                {
                                    diagBD = true;
                                }

                                if (dify > 0)
                                {
                                    diagHD = true;
                                }
                            }
                        }

                        if (difx == 0)
                        {
                            if (dify > 0)
                            {
                                haut = true;
                            }
                            if (dify < 0)
                            {
                                bas = true;
                            }
                        }

                        if (dify == 0)
                        {
                            if (difx > 0)
                            {
                                droite = true;
                            }
                            if (difx < 0)
                            {
                                gauche = true;
                            }
                        }

                        if (haut)
                        {
                            int i=1;
                            while (i < dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (bas)
                        {
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (gauche)
                        {
                     
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        
                        if (droite)
                        {
                   
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        
                        if (diagBG)
                        {
                       
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHG)
                        {
                    
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+Math.Abs(i) , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagBD)
                        {
          
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ Math.Abs(i), actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHD)
                        {
                       
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                    }
                }
                break;
           
            case "bBishopC" : if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                           Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                         bool diagHD=false;
                         bool diagHG = false;
                         bool diagBG = false;
                         bool diagBD = false;
                         float xPiece=actualpos.x;
                         float yPiece=actualpos.y;
                         float difx = move.x-xPiece;
                         float dify = move.y-yPiece;
                       
                                        if (Math.Abs(difx) == Math.Abs(dify))
                                        {
                                            if (difx < 0) 
                                            {
                                                    if (dify < 0)
                                                    {
                                                        diagBG = true;
                                                    }
                
                                                    if (dify > 0)
                                                    {
                                                        diagHG = true;
                                                    }
                                                    
                                            }else if (difx > 0)
                                            {
                                                if (dify < 0)
                                                {
                                                    diagBD = true;
                                                }
                
                                                if (dify > 0)
                                                {
                                                    diagHD = true;
                                                }
                                            }
                                        }
                                      
                                        if (diagBG)
                                        {
                                         
                                            int i=-1;
                                            while (i > difx)
                                            {
                                               
                                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                                {
                                                    break;
                                                }
                                                i--;
                                            }
                                            
                                         
                                            if (i == difx)
                                            {
                                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                                {
                                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                                }
                                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                                return true;
                                            }
                                        }
                                        if (diagHG)
                                        {
                                        
                                            int i=-1;
                                            while (i > difx)
                                            {
                                               
                                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+Math.Abs(i) , actualpos.z)) != null)
                                                {
                                                    break;
                                                }
                                                i--;
                                            }
                                            
                                         
                                            if (i == difx)
                                            {
                                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                                {
                                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                                }
                                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                                return true;
                                            }
                                        }
                                        if (diagBD)
                                        {
                              
                                            int i=-1;
                                            while (i > dify)
                                            {
                                               
                                                if (posToBoard(new Vector3(actualpos.x+ Math.Abs(i), actualpos.y+i , actualpos.z)) != null)
                                                {
                                                    break;
                                                }
                                                i--;
                                            }
                                            
                                         
                                            if (i == dify)
                                            {
                                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                                {
                                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                                }
                                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                                return true;
                                            }
                                        }
                                        if (diagHD)
                                        {
                                       
                                            int i=1;
                                            while (i < difx)
                                            {
                                               
                                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                                {
                                                    break;
                                                }
                                                i++;
                                            }
                                            
                                         
                                            if (i == difx)
                                            {
                                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                                {
                                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                                }
                                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                                return true;
                                            }
                                        }
                    }
                }
                break;
            case "bBishopF" : if (sameTeam(piece, posToBoard(move)))
                {
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool diagHD=false;
                        bool diagHG = false;
                        bool diagBG = false;
                        bool diagBD = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;
         
                        if (Math.Abs(difx) == Math.Abs(dify))
                        {
                            if (difx < 0) 
                            {
                                    if (dify < 0)
                                    {
                                        diagBG = true;
                                    }

                                    if (dify > 0)
                                    {
                                        diagHG = true;
                                    }
                                    
                            }else if (difx > 0)
                            {
                                if (dify < 0)
                                {
                                    diagBD = true;
                                }

                                if (dify > 0)
                                {
                                    diagHD = true;
                                }
                            }
                        }
                        
                        if (diagBG)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHG)
                        {
                        
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+Math.Abs(i) , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagBD)
                        {
                
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ Math.Abs(i), actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                        if (diagHD)
                        {
                          
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y+i , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y+dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                return true;
                            }
                        }
                    }
                }
                break;
            case "bKnightB" : if (sameTeam(piece, posToBoard(move))){
               
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        float pieceX = piece.GetComponent<Move>().actualPos.x;
                        float pieceY = piece.GetComponent<Move>().actualPos.y;
                        if ((move.x == pieceX + 2 || move.x == pieceX - 2)&&(move.y==pieceY+1||move.y==pieceY-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                        if ((move.y == pieceY + 2 || move.y == pieceY - 2)&&(move.x==pieceX+1||move.x==pieceX-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                    }
                }
                break;
            case "bKnightG" :if (sameTeam(piece, posToBoard(move))){
               
                    return false;
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                        float pieceX = piece.GetComponent<Move>().actualPos.x;
                        float pieceY = piece.GetComponent<Move>().actualPos.y;
                        if ((move.x == pieceX + 2 || move.x == pieceX - 2)&&(move.y==pieceY+1||move.y==pieceY-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                        if ((move.y == pieceY + 2 || move.y == pieceY - 2)&&(move.x==pieceX+1||move.x==pieceX-1))
                        {
                            GameObject go = posToBoard(move);
                            if (go != null)
                            {
                                Destroy(go);
                            }
                            updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                            return true;
                        }
                    }
                }
                break;
            case "bRookA" :if (sameTeam(piece, posToBoard(move)))
                {
                    if (posToBoard(move).name=="bKing"&&!this.bRookAMoved&&!this.bKingMoved)
                        {
                            int i=1;
                            Vector3 pieceTransform=piece.GetComponent<Move>().actualPos;
                            while (i < 4)
                            {
                                if (posToBoard(new Vector3(pieceTransform.x + i, pieceTransform.y, pieceTransform.z)) != null)
                                {
                                    return false;
                                }

                                if (attacked(new Vector3(pieceTransform.x + i, pieceTransform.y, pieceTransform.z)))
                                {
                                    return false;
                                }

                                i++;
                            }
                            //TODO 
                            if (rockPermited(piece))
                            {


                                board[0, 7] = null;
                                board[4, 7] = null;
                                board[3, 7] = wRookH;
                                board[2, 7] = wKing;
                                piece.GetComponent<Move>().actualPos = new Vector3(move.x - 1, move.y,
                                    move.z);
                                bKing.GetComponent<Move>().actualPos = new Vector3(move.x - 2, move.y,
                                    move.z);
                                bKing.transform.position = new Vector3(move.x - 2, move.y,
                                    move.z);
                                bKingMoved = true;
                                bRookAMoved = true;
                                return false;
                            }

                            return false;
                        }
                }else{
                    if (isCheckedAfterMove(move, piece))
                    {
                 
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool haut = false;
                        bool bas = false;
                        bool gauche = false;
                        bool droite = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;

                        if (difx == 0)
                        {
                            if (dify > 0)
                            {
                                haut = true;
                            }
                            if (dify < 0)
                            {
                                bas = true;
                            }
                        }

                        if (dify == 0)
                        {
                            if (difx > 0)
                            {
                                droite = true;
                            }
                            if (difx < 0)
                            {
                                gauche = true;
                            }
                        }

                        if (haut)
                        {
                      
                            int i=1;
                            while (i < dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookAMoved = true;
                                return true;
                            }
                        }
                        if (bas)
                        {
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                   
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookAMoved = true;
                                return true;
                            }
                        }
                        if (gauche)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookAMoved = true;
                                return true;
                            }
                        }
                        
                        if (droite)
                        {
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookAMoved = true;
                                return true;
                            }
                        }
                    }
                }
                break;
            case "bRookH" :if (!sameTeam(piece, posToBoard(move)))
                {
                    if (posToBoard(move).name=="bKing"&&!this.bRookHMoved&&!this.bKingMoved)
                        {
                            int i=-1;
                            Vector3 pieceTransform=piece.GetComponent<Move>().actualPos;
                            while (i > 4)
                            {
                                if (posToBoard(new Vector3(pieceTransform.x - i, pieceTransform.y, pieceTransform.z)) != null)
                                {
                                    return false;
                                }
                                i--;
                            }

                            if (rockPermited(piece))
                            {
                                //TODO a compléter pour faire tout ce qu'il doit etre fait normalement en cas de return true CEST DEGUEULASSE XOXO
                                board[7, 7] = null;
                                board[4, 7] = null;
                                board[5, 7] = bRookH;
                                board[6, 7] = bKing;
                                piece.GetComponent<Move>().actualPos = new Vector3(move.x +1, move.y,
                                    move.z);
                                bKing.GetComponent<Move>().actualPos = new Vector3(move.x +2, move.y,
                                    move.z);
                                bKing.transform.position = new Vector3(move.x +2, move.y,
                                    move.z);
                                bKingMoved = true;
                                bRookHMoved = true;
                                return false;
                            }
                        }
                }else{
                    if (!sameTeam(piece, posToBoard(move)))
                    {
                 
                        Vector3 actualpos = piece.GetComponent<Move>().actualPos;
                        bool haut = false;
                        bool bas = false;
                        bool gauche = false;
                        bool droite = false;
                        float xPiece=actualpos.x;
                        float yPiece=actualpos.y;
                        float difx = move.x-xPiece;
                        float dify = move.y-yPiece;

                        if (difx == 0)
                        {
                            if (dify > 0)
                            {
                                haut = true;
                            }
                            if (dify < 0)
                            {
                                bas = true;
                            }
                        }

                        if (dify == 0)
                        {
                            if (difx > 0)
                            {
                                droite = true;
                            }
                            if (difx < 0)
                            {
                                gauche = true;
                            }
                        }

                        if (haut)
                        {
                      
                            int i=1;
                            while (i < dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookHMoved = true;
                                return true;
                            }
                        }
                        if (bas)
                        {
                            int i=-1;
                            while (i > dify)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + i, actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                   
                            if (i == dify)
                            {
                                if (posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x, actualpos.y + dify, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookHMoved = true;
                                return true;
                            }
                        }
                        if (gauche)
                        {
                            int i=-1;
                            while (i > difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i--;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookHMoved = true;
                                return true;
                            }
                        }
                        
                        if (droite)
                        {
                            int i=1;
                            while (i < difx)
                            {
                               
                                if (posToBoard(new Vector3(actualpos.x+ i, actualpos.y , actualpos.z)) != null)
                                {
                                    break;
                                }
                                i++;
                            }
                            
                         
                            if (i == difx)
                            {
                                if (posToBoard(new Vector3(actualpos.x+ difx, actualpos.y , actualpos.z)) != null)
                                {
                                    Destroy(posToBoard(new Vector3(actualpos.x+ difx, actualpos.y, actualpos.z)));
                                }
                                updateBoard(piece.GetComponent<Move>().actualPos,move,piece);
                                this.bRookHMoved = true;
                                return true;
                            }
                        }
                    }
                }
                break;
        }
        return false;
    }
}


// TODO FAIRE UNE FONCTION DE VERIFICATION SI LE ROCK EST PERMIT, elle prendra en entrée que la tour avec laquel il veut rock
