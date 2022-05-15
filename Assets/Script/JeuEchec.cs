using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class JeuEchec : MonoBehaviour
{
    // Instance des pièces noires
    public GameObject bPionA;
    public GameObject bPionB;
    public GameObject bPionC;
    public GameObject bPionD;
    public GameObject bPionE;
    public GameObject bPionF;
    public GameObject bPionG;
    public GameObject bPionH;
    public GameObject bRoi;
    public GameObject bReine;
    public GameObject bFouC;
    public GameObject bFouF;
    public GameObject bCavalierB;
    public GameObject bCavalierG;
    public GameObject bTourA;
    public GameObject bTourH;
    
    // Instance des pièces blanches
    public GameObject wPionA;
    public GameObject wPionB;
    public GameObject wPionC;
    public GameObject wPionD;
    public GameObject wPionE;
    public GameObject wPionF;
    public GameObject wPionG;
    public GameObject wPionH;
    public GameObject wRoi;
    public GameObject wReine;
    public GameObject wFouC;
    public GameObject wFouF;
    public GameObject wCavalierB;
    public GameObject wCavalierG;
    public GameObject wTourA;
    public GameObject wTourH;
    
    //Représentation du board
    private GameObject[,] board;

    
    //trait au blanc ou noir
    private string trait;
    
    //Prefab de reine 
    public GameObject prefabWReine;
    public GameObject prefabBReine;
    // Start is called before the first frame update
    void Start()
    {
        this.trait = "blanc";
        board = new GameObject[8, 8];
        board[0, 0] = wTourA;
        board[1, 0] = wCavalierB;
        board[2, 0] = wFouC;
        board[3, 0] = wReine;
        board[4, 0] = wRoi;
        board[5, 0] = wFouF;
        board[6, 0] = wCavalierG;
        board[7, 0] = wTourH;
        
        board[0, 1] = wPionA;
        board[1, 1] = wPionB;
        board[2, 1] = wPionC;
        board[3, 1] = wPionD;
        board[4, 1] = wPionE;
        board[5, 1] = wPionF;
        board[6, 1] = wPionG;
        board[7, 1] = wPionH;
        
        board[0, 7] = bTourA;
        board[1, 7] = bCavalierB;
        board[2, 7] = bFouC;
        board[3, 7] = bReine;
        board[4, 7] = bRoi;
        board[5, 7] = bFouF;
        board[6, 7] = bCavalierG;
        board[7, 7] = bTourH;
        board[0, 6] = bPionA;
        board[1, 6] = bPionB;
        board[2, 6] = bPionC;
        board[3, 6] = bPionD;
        board[4, 6] = bPionE;
        board[5, 6] = bPionF;
        board[6, 6] = bPionG;
        board[7, 6] = bPionH;
        
        bPionA.name = "bPion";
        bPionB.name = "bPion";
        bPionC.name = "bPion";
        bPionD.name = "bPion";
        bPionE.name = "bPion";
        bPionF.name = "bPion";
        bPionG.name = "bPion";
        bPionH.name = "bPion";
        
        wPionA.name = "wPion";
        wPionB.name = "wPion";
        wPionC.name = "wPion";
        wPionD.name = "wPion";
        wPionE.name = "wPion";
        wPionF.name = "wPion";
        wPionG.name = "wPion";
        wPionH.name = "wPion";
        
        wFouF.name = "wFou";
        wFouC.name = "wFou";
        bFouF.name = "bFou";
        bFouC.name = "bFou";

        wCavalierB.name = "wCavalier";
        wCavalierG.name = "wCavalier";
        bCavalierB.name = "bCavalier";
        bCavalierG.name = "bCavalier";
        
        wTourA.name = "wTour";
        wTourH.name = "wTour";
        bTourA.name = "bTour";
        bTourH.name = "bTour";
    }

    
    
    //Entrée : Vector3 qui représente un point du plan
    //Fonctionnement : On vérifie quel est la case la plus proche de la position du plan donné en entrée 
    //Sortie : Vector3 qui représente la position de la case dans le plan
    private Vector3 caseLaPlusProche(Vector3 position)
    {
        float y = position.y;
        float x = position.x;
        int i=0, j=0;
        while (y > 0.5f)
        {
            y--;
            i++;
        }
        while (x > 0.5f)
        {
            x--;
            j++;
        }
        return new Vector3((float) j, (float) i, -1f);
    }

    private void promotionPion(GameObject piece)
    {
        Mouvement script=piece.GetComponent<Mouvement>();
        GameObject pref;
        if (piece.name[0] == 'w')
        {
            pref = this.prefabWReine;
        }
        else
        {
            pref = this.prefabBReine;
        }
        Vector3 positionActuel = piece.GetComponent<Mouvement>().getPositionActuel();
        Debug.Log(board[(int) positionActuel.x, (int) positionActuel.y]);
        board[(int) positionActuel.x,(int) positionActuel.y]=Instantiate(pref,positionActuel,piece.transform.rotation);
        board[(int) positionActuel.x,(int) positionActuel.y].GetComponent<Mouvement>().board = gameObject;
        if (piece.name[0] == 'w')
        {
            board[(int) positionActuel.x, (int) positionActuel.y].name = "wReine";
        }
        else
        {
            board[(int) positionActuel.x, (int) positionActuel.y].name = "bReine";
        }
        Destroy(piece);
    }
    //Entrée : rien
    //Fonctionnement : vérifie si le mouvement demandé est valide, si il ne l'est pas ne fais rien, si il l'est déclenche tout un tas de 
    // de fonction qui font avancé le jeu.
    //Sortie : rien
    public void mouvementDemandé(GameObject piece, Vector3 positionCurseur)
    {
        char pieceTeam = piece.name[0];
        if (this.trait != tourDeLequipe(pieceTeam))
        {
            piece.GetComponent<Mouvement>().resetPosition();
        }
        else
        {
                        string pieceName = piece.name;
            pieceName=pieceName.TrimStart('b', 'w');
            Vector3 mouvement = caseLaPlusProche(positionCurseur);
            Vector3 positionAvantMouvement = piece.GetComponent<Mouvement>().getPositionActuel();
            bool estLegale=false;
            switch (pieceName)
            {
                case "Pion" :
                    estLegale = pionMouvement(piece, mouvement);
                    if (estLegale)
                    {
                        pionOnJouerFaux();
                        if (positionAvantMouvement.y + 2 == mouvement.y || positionAvantMouvement.y - 2 == mouvement.y)
                        {
                            piece.GetComponent<PionException>().VientDeJouer = true;
                        }

                   
                        board[(int) positionAvantMouvement.x, (int) positionAvantMouvement.y] = null;
                        board[(int) mouvement.x, (int) mouvement.y] = piece;
                        if (mouvement.y == 7 || mouvement.y == 0)
                        {
                            promotionPion(piece);
                        }
                    }
                    break;
                case "Cavalier" : 
                    estLegale = cavalierMouvement(piece, mouvement);
                    if (estLegale)
                    {
                        pionOnJouerFaux();
                        board[(int) positionAvantMouvement.x, (int) positionAvantMouvement.y] = null;
                        board[(int) mouvement.x, (int) mouvement.y] = piece;
                    }
                    break;
                case "Fou" : 
                    estLegale = fouMouvement(piece, mouvement);
                    if (estLegale)
                    {
                        pionOnJouerFaux();
                        board[(int) positionAvantMouvement.x, (int) positionAvantMouvement.y] = null;
                        board[(int) mouvement.x, (int) mouvement.y] = piece;
                    }
                    break;
                case "Reine": 
                    estLegale = reineMouvement(piece, mouvement);
                    if (estLegale)
                    {
                        pionOnJouerFaux();
                        board[(int) positionAvantMouvement.x, (int) positionAvantMouvement.y] = null;
                        board[(int) mouvement.x, (int) mouvement.y] = piece;
                    }
                    break;
                case "Roi": 
                    estLegale = roiMouvement(piece, mouvement);
                    if (estLegale)
                    {
                        pionOnJouerFaux();
                        piece.GetComponent<RockException>().rockDisponible = false;
                    }
                    break;
                case "Tour" : 
                    estLegale = tourMouvement(piece, mouvement);
                    if (estLegale)
                    {
                        pionOnJouerFaux();
                        piece.GetComponent<RockException>().rockDisponible = false;

                    }
                    break;
            }

            if (estLegale)
            {
                changerDeTour();
            }
        }

    }
    
    //Entrée : Go piece ne pouvant pas être null représentant le pièce qui demande le mouvment qui lui est représenter par un Vector3
    //Fonctionnement : Vérifie si le mouvement est légal, si il l'est, applique les changements de position et prise et renvoi vrai pour que les différents mécanisme du jeu s'effectue
    //Sortie : un bool 
    private bool pionMouvement(GameObject piece, Vector3 mouvement)
    {
        Mouvement mouvementScript =piece.GetComponent<Mouvement>();
        Vector3 positionActuel = mouvementScript.getPositionActuel();
        if (memeEquipe(piece, board[(int) mouvement.x, (int) mouvement.y]))
        {
            mouvementScript.resetPosition();
            return false;
        }
        else
        {
            if (!estEnEchecApresMouvement(mouvement, piece))
            { int multiplieur=1;
                if (piece.name[0] == 'b')
                {
                    multiplieur = -1; 
                }
                // Je vérifie que ça soit un mouvement possible (+0 +2) (+1||-1||0 +1) sans vérifier les conditions plus complexe comme en passant
                if ((positionActuel.y + (2 * multiplieur) == mouvement.y)
                    ||(positionActuel.y + (1 * multiplieur) == mouvement.y
                       &&(positionActuel.x+1==mouvement.x||positionActuel.x-1==mouvement.x||positionActuel.x==mouvement.x)))
                {
                    if ((positionActuel.x + 1 == mouvement.x || positionActuel.x - 1 == mouvement.x)&& ((positionActuel.y + (2 * multiplieur) != mouvement.y)))
                    {
                        if (board[(int) mouvement.x, (int) mouvement.y] != null)
                        {
                   
                            Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                            mouvementScript.setPositionActuel(mouvement);
                            return true;
                        }
                        else
                        {
                            if (board[(int) mouvement.x, (int) mouvement.y - (1*multiplieur)] != null &&
                                (board[(int) mouvement.x, (int) mouvement.y - (1*multiplieur)].name == "wPion" ||
                                 board[(int) mouvement.x, (int) mouvement.y - (1*multiplieur)].name == "bPion"))
                            {
                               
                                if (board[(int) mouvement.x, (int) mouvement.y - (1*multiplieur)].GetComponent<PionException>()
                                    .VientDeJouer)
                                {
                                    Destroy(board[(int) mouvement.x, (int) mouvement.y - (1*multiplieur)]);
                                    mouvementScript.setPositionActuel(mouvement);
                                    return true;
                                }else
                                {
                                    mouvementScript.resetPosition();
                                    return false;
                                }
                            }
                            mouvementScript.resetPosition();
                            return false;
                        }
                    }
                    else
                    {
                        if (board[(int) mouvement.x, (int) mouvement.y] != null)
                        {
                            mouvementScript.resetPosition();
                            return false;
                        }
                        else
                        {
                            if ((positionActuel.y + (2 * multiplieur) == mouvement.y) && ((board[(int) positionActuel.x, (int) positionActuel.y + (1 * multiplieur)]) != null||positionActuel.y!=3.5f-(2.5f*(float)multiplieur)))
                            {
                                mouvementScript.resetPosition();
                                return false; 
                            }

                            mouvementScript.setPositionActuel(mouvement);
                            return true;
                        }
                    }
                
                }
                else
                {
                    mouvementScript.resetPosition();
                    return false;
                }
                    
            }
        }
        Debug.Log("je dois j'aimais finir ici");
        mouvementScript.resetPosition();
        return false;
    }

    //Entrée : Go piece ne pouvant pas être null représentant le pièce qui demande le mouvment qui lui est représenter par un Vector3
    //Fonctionnement : Vérifie si le mouvement est légal, si il l'est, applique les changements de position et prise et renvoi vrai pour que les différents mécanisme du jeu s'effectue
    //Sortie : un bool 
    private bool fouMouvement(GameObject piece, Vector3 mouvement)
    {
        Mouvement mouvementScript = piece.GetComponent<Mouvement>();
        Vector3 positionActuel = mouvementScript.getPositionActuel();
        if (memeEquipe(piece, board[(int) mouvement.x, (int) mouvement.y]))
        {
            mouvementScript.resetPosition();
            return false;
        }
        else
        {
            if (!estEnEchecApresMouvement(mouvement, piece))
            {


                if (Math.Abs(mouvement.x - positionActuel.x) == Math.Abs(mouvement.y - positionActuel.y))
                {

                    int multiplieurX = 1;
                    int multiplieurY = 1;
                    if (mouvement.y > positionActuel.y)
                    {
                        multiplieurY = -1;
                    }

                    if (mouvement.x > positionActuel.x)
                    {
                        multiplieurX = -1;
                    }

                    float i = Math.Abs(mouvement.x - positionActuel.x) - 1;
                    while (i > 0)
                    {
                        if (board[(int) (mouvement.x + (i * multiplieurX)), (int) (mouvement.y + (i * multiplieurY))] !=
                            null)
                        {
                            mouvementScript.resetPosition();
                            return false;
                        }

                        i--;
                    }

                    if (board[(int) mouvement.x, (int) mouvement.y])
                    {
                        Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                    }

                    mouvementScript.setPositionActuel(mouvement);
                    return true;
                }
            }

            mouvementScript.resetPosition();
            return false;
        }
    }

    //Entrée : Go piece ne pouvant pas être null représentant le pièce qui demande le mouvment qui lui est représenter par un Vector3
    //Fonctionnement : Vérifie si le mouvement est légal, si il l'est, applique les changements de position et prise et renvoi vrai pour que les différents mécanisme du jeu s'effectue
    //Sortie : un bool 
    private bool cavalierMouvement(GameObject piece, Vector3 mouvement)
    {
        Mouvement mouvementScript =piece.GetComponent<Mouvement>();
        Vector3 positionActuel = mouvementScript.getPositionActuel();
        if (memeEquipe(piece, board[(int) mouvement.x, (int) mouvement.y]))
        {
            
            mouvementScript.resetPosition();
            return false;
        }
        else
        {
            if (!estEnEchecApresMouvement(mouvement, piece))
            {
                bool mouvAccepté=false;
                if((mouvement.x==positionActuel.x+2||mouvement.x==positionActuel.x-2)&&(mouvement.y==positionActuel.y+1||mouvement.y==positionActuel.y-1))
                {
                     mouvAccepté=true;
                }
                if((mouvement.y==positionActuel.y+2||mouvement.y==positionActuel.y-2)&&(mouvement.x==positionActuel.x+1||mouvement.x==positionActuel.x-1))
                {
                    mouvAccepté=true;
                }

                if (mouvAccepté)
                {
                    if (board[(int) mouvement.x, (int) mouvement.y]!=null)
                    {
                        Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                    }
                    mouvementScript.setPositionActuel(mouvement);
                    return true;
                }
                
            }
        }
        mouvementScript.resetPosition();
        return false;
    }

    //Entrée : Go piece ne pouvant pas être null représentant le pièce qui demande le mouvment qui lui est représenter par un Vector3
    //Fonctionnement : Vérifie si le mouvement est légal, si il l'est, applique les changements de position et prise et renvoi vrai pour que les différents mécanisme du jeu s'effectue
    //Sortie : un bool 
    private bool reineMouvement(GameObject piece, Vector3 mouvement)
    {
        Mouvement mouvementScript =piece.GetComponent<Mouvement>();
        Vector3 positionActuel = mouvementScript.getPositionActuel();
        if (memeEquipe(piece, board[(int) mouvement.x, (int) mouvement.y]))
        {
            mouvementScript.resetPosition();
            return false;
        }
        else
        {
            if (!estEnEchecApresMouvement(mouvement, piece))
            {


                if (Math.Abs(mouvement.x-positionActuel.x) == Math.Abs(mouvement.y-positionActuel.y))
                {
                   
                    int multiplieurX=1;
                    int multiplieurY=1;
                    if (mouvement.y > positionActuel.y)
                    {
                        multiplieurY = -1;
                    }
                    if (mouvement.x > positionActuel.x)
                    {
                        multiplieurX = -1;
                    }

                    float i = Math.Abs(mouvement.x-positionActuel.x)-1;
                    while (i > 0)
                    {
                        if (board[(int) (mouvement.x + (i * multiplieurX)), (int) (mouvement.y + (i * multiplieurY))]!=null)
                        {
                            mouvementScript.resetPosition();
                            return false;
                        }
                        i--;
                    }
                    if (board[(int) mouvement.x, (int) mouvement.y])
                    {
                        Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                    }
                    mouvementScript.setPositionActuel(mouvement);
                    return true;
                }
                else
                {
                    if (mouvement.x == positionActuel.x && mouvement.y != positionActuel.y)
                    {
                        int multiplieur=1;
                        if (positionActuel.y < mouvement.y)
                        {
                            multiplieur = -1;
                        }
                        float i = Math.Abs(mouvement.y-positionActuel.y)-1;
                        while (i > 0)
                        {
                            if (board[(int) mouvement.x, (int) (mouvement.y + (i * multiplieur))]!=null)
                            {
                                mouvementScript.resetPosition();
                                return false;
                            }
                            i--;
                        }
                        if (board[(int) mouvement.x, (int) mouvement.y])
                        {
                            Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                        }
                        mouvementScript.setPositionActuel(mouvement);
                        return true;
                    }
                    if (mouvement.y == positionActuel.y && mouvement.x != positionActuel.x)
                    {
                       
                        int multiplieur=1;
                        if (positionActuel.x < mouvement.x)
                        {
                            multiplieur = -1;
                        }
                        float i = Math.Abs(mouvement.x-positionActuel.x)-1;
                        Debug.Log(Math.Abs(mouvement.x-positionActuel.x)-1);
                        while (i > 0)
                        {
                          if (board[(int) (mouvement.x + (i * multiplieur)), (int) mouvement.y]!=null)
                            {
                                mouvementScript.resetPosition();
                                return false;
                            } 
                            i--;
                          
                        }
                        if (board[(int) mouvement.x, (int) mouvement.y])
                        {
                            Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                        }
                        mouvementScript.setPositionActuel(mouvement);
                        return true;
                    }
                }
            }
        }
        mouvementScript.resetPosition();
        return false;
    }

    //Entrée : Go piece ne pouvant pas être null représentant le pièce qui demande le mouvment qui lui est représenter par un Vector3
    //Fonctionnement : Vérifie si le mouvement est légal, si il l'est, applique les changements de position et prise et renvoi vrai pour que les différents mécanisme du jeu s'effectue
    //Sortie : un bool 
    private bool roiMouvement(GameObject piece, Vector3 mouvement)
    {
        Mouvement mouvementScript = piece.GetComponent<Mouvement>();
        Vector3 positionActuel = mouvementScript.getPositionActuel();
        if (memeEquipe(piece, board[(int) mouvement.x, (int) mouvement.y]))
        {
            if (board[(int) mouvement.x, (int) mouvement.y].name[1] == 'T')
            {
                if (piece.GetComponent<RockException>().rockDisponible && board[(int) mouvement.x, (int) mouvement.y]
                        .GetComponent<RockException>().rockDisponible)
                {
              
                       
                        int multiplieur=1;
                        if (positionActuel.x < mouvement.x)
                        {
                            multiplieur = -1;
                        }
                        float i = Math.Abs(mouvement.x-positionActuel.x)-1;
                        while (i > 0)
                        {
                            Debug.Log(new Vector3(mouvement.x + (i * multiplieur), mouvement.y, mouvement.z));
                            if ((board[(int) (mouvement.x + (i * multiplieur)), (int) mouvement.y]!=null)||this.dangerSurLaCase(new Vector3(mouvement.x + (i * multiplieur),mouvement.y,mouvement.z)))
                            {
                                mouvementScript.resetPosition();
                                return false;
                             
                            } 
                            i--;
                          
                        }

                        int multiplieurR = 1;
                        if (positionActuel.x >mouvement.x)
                        {
                            multiplieurR = -1;
                        }
                        board[(int) positionActuel.x, (int) positionActuel.y] = null;
                        board[(int) positionActuel.x+(2*multiplieurR), (int) positionActuel.y] = piece;
                        board[(int) positionActuel.x+(1*multiplieurR), (int) positionActuel.y] = board[(int) mouvement.x, (int) mouvement.y];
                        
                        mouvementScript.setPositionActuel(new Vector3(positionActuel.x+(2*multiplieurR),positionActuel.y,positionActuel.z));
                        board[(int) mouvement.x, (int) mouvement.y].GetComponent<Mouvement>().setPositionActuel(new Vector3(positionActuel.x+(1*multiplieurR),positionActuel.y,positionActuel.z));
                        board[(int) mouvement.x, (int) mouvement.y] = null;
                
                        return true;
                    
                }
            }
            mouvementScript.resetPosition();
            return false;
        }
        else
        {
            if (!estEnEchecApresMouvement(mouvement, piece))
            {
                if ((mouvement.x == positionActuel.x + 1 || mouvement.x == positionActuel.x - 1 ||
                     mouvement.x == positionActuel.x) && (mouvement.y == positionActuel.y + 1 ||
                                                          mouvement.y == positionActuel.y - 1 ||
                                                          mouvement.y == positionActuel.y))
                {
                    if (board[(int) mouvement.x, (int) mouvement.y] != null)
                    {
                        Destroy(board[(int) mouvement.x, (int) mouvement.y]);

                    }
                    board[(int) positionActuel.x, (int) positionActuel.y] = null;
                    board[(int) mouvement.x, (int) mouvement.y] = piece;
                    mouvementScript.setPositionActuel(mouvement);
                    return true;
                }

            }

            mouvementScript.resetPosition();
            return false;
        }
    }

    //Entrée : Go piece ne pouvant pas être null représentant le pièce qui demande le mouvment qui lui est représenter par un Vector3
    //Fonctionnement : Vérifie si le mouvement est légal, si il l'est, applique les changements de position et prise et renvoi vrai pour que les différents mécanisme du jeu s'effectue
    //Sortie : un bool 
    private bool tourMouvement(GameObject piece, Vector3 mouvement)
    {
         Mouvement mouvementScript =piece.GetComponent<Mouvement>();
        Vector3 positionActuel = mouvementScript.getPositionActuel();
        if (memeEquipe(piece, board[(int) mouvement.x, (int) mouvement.y]))
        {
            Debug.Log(board[(int) mouvement.x, (int) mouvement.y].name[1]);
            Debug.Log(board[(int) mouvement.x, (int) mouvement.y].name[2]);
            if (board[(int) mouvement.x, (int) mouvement.y].name[1] == 'R'&&board[(int) mouvement.x, (int) mouvement.y].name[2] == 'o')
            {
                    if (piece.GetComponent<RockException>().rockDisponible && board[(int) mouvement.x, (int) mouvement.y]
                            .GetComponent<RockException>().rockDisponible)
                    {
                  
                        
                            int multiplieur=1;
                            if (positionActuel.x < mouvement.x)
                            {
                                multiplieur = -1;
                            }
                            float i = Math.Abs(mouvement.x-positionActuel.x)-1;
                            while (i > 0)
                            {
                                Debug.Log(new Vector3(mouvement.x + (i * multiplieur), mouvement.y, mouvement.z));
                                if ((board[(int) (mouvement.x + (i * multiplieur)), (int) mouvement.y]!=null)||this.dangerSurLaCase(new Vector3(mouvement.x + (i * multiplieur),mouvement.y,mouvement.z)))
                                {
                                    mouvementScript.resetPosition();
                                    return false;
                                 
                                } 
                                i--;
                              
                            }

                            int multiplieurR = 1;
                            if (positionActuel.x <mouvement.x)
                            {
                                multiplieurR = -1;
                            }

                            Mouvement scriptTour =
                                board[(int) mouvement.x, (int) mouvement.y].GetComponent<Mouvement>();
                            Vector3 positionRoiActuel = scriptTour.getPositionActuel();
                            board[(int) positionRoiActuel.x, (int) positionRoiActuel.y] = null;
                            board[(int) positionRoiActuel.x+(1*multiplieurR), (int) positionRoiActuel.y] = piece;
                            board[(int) positionRoiActuel.x+(2*multiplieurR), (int) positionRoiActuel.y] = board[(int) mouvement.x, (int) mouvement.y];
                            
                            mouvementScript.setPositionActuel(new Vector3(positionRoiActuel.x+(2*multiplieurR),positionRoiActuel.y,positionRoiActuel.z));
                            scriptTour.setPositionActuel(new Vector3(positionRoiActuel.x+(1*multiplieurR),positionRoiActuel.y,positionRoiActuel.z));
                            board[(int) mouvement.x, (int) mouvement.y] = null;
                            return true;
                    
                }
            }
            mouvementScript.resetPosition();
            return false;
        }
        else
        {
            if (!estEnEchecApresMouvement(mouvement, piece))
            {
                if (mouvement.x == positionActuel.x && mouvement.y != positionActuel.y)
                {
                        int multiplieur=1;
                        if (positionActuel.y < mouvement.y)
                        {
                            multiplieur = -1;
                        }
                        float i = Math.Abs(mouvement.y-positionActuel.y)-1;
                        while (i > 0)
                        {
                            if (board[(int) mouvement.x, (int) (mouvement.y + (i * multiplieur))]!=null)
                            {
                                mouvementScript.resetPosition();
                                return false;
                            }
                            i--;
                        }
                        if (board[(int) mouvement.x, (int) mouvement.y])
                        {
                            Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                        }
                        mouvementScript.setPositionActuel(mouvement);
                        return true;
                }
                
                if (mouvement.y == positionActuel.y && mouvement.x != positionActuel.x) {
                       
                        int multiplieur=1;
                        if (positionActuel.x < mouvement.x)
                        {
                            multiplieur = -1;
                        }
                        float i = Math.Abs(mouvement.x-positionActuel.x)-1;
                        Debug.Log(Math.Abs(mouvement.x-positionActuel.x)-1);
                        while (i > 0)
                        {
                          if (board[(int) (mouvement.x + (i * multiplieur)), (int) mouvement.y]!=null)
                            {
                                mouvementScript.resetPosition();
                                return false;
                            } 
                            i--;
                          
                        }
                        if (board[(int) mouvement.x, (int) mouvement.y])
                        {
                            Destroy(board[(int) mouvement.x, (int) mouvement.y]);
                        }
                        mouvementScript.setPositionActuel(mouvement);
                        board[(int) positionActuel.x, (int) positionActuel.y] = null;
                        board[(int) mouvement.x, (int) mouvement.y] = piece;
                        return true;
                }
            }
        }
        mouvementScript.resetPosition();
        return false;
    }
    
    //TODO
    //Entrée : Vector3 étant le mouvement effectué et Go piece étant la piece bougé
    //Fonctionnement : Vérifie si après avoir effectué un mouvement la personne ayant joué n'est pas en echéc si oui, return true
    //Sortie :
    bool estEnEchecApresMouvement(Vector3 mouvement, GameObject piece)
    {
        
        return false;
    }

    //TODO
    //Entrée :Un vecteur 3 représentant la case a vérifier
    //Fonctionnement : regarde si cette case est en danger
    //Sortie :
    bool dangerSurLaCase(Vector3 position)
    {
        return false;
    }
    
    //Entrée :Un vecteur 3 représentant la case a vérifier
    //Fonctionnement : regarde si cette case est en danger
    //Sortie :
    string tourDeLequipe (char equipe)
    {
        if (equipe=='w')
        {
            return "blanc";
        }
        else
        {
            return "noir";
        }
    }

    void changerDeTour()
    {
        if (this.trait == "blanc")
        {
            this.trait = "noir";
        }
        else
        {
            this.trait = "blanc";
        }
    }
    //TODO
    //Entrée :rien 
    //Fonctionnement : Vérifie si dans l'état actuel du board il y a échec et matt
    //Sortie :
    bool echecEtMatt()
    {
        return false; 
    }
    
    //Entrée : rien
    //Fonctionnement : met toute les élèments ontJoué a faux de chaque pions
    //Sortie : un bool 
    private void pionOnJouerFaux()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int y = 0; y < 8; y++)
            {
                if (board[i, y] != null)
                {
                    if (board[i, y].name[1]=='P')
                    {
                        board[i, y].GetComponent<PionException>().VientDeJouer = false;
                    }
                }
            }
        }
    }
    //Entrée : Deux Go pouvant être null 
    //Fonctionnement : Regarde si la première lettres de chaques pièces est la même
    //Sortie : un bool 
    bool memeEquipe(GameObject piece1, GameObject piece2)
    {
   
        if (piece1 != null && piece2 != null)
        {
            if (piece1.name[0] == piece2.name[0])
            {
                return true;
            }
        }

        return false;
    }
    
}
