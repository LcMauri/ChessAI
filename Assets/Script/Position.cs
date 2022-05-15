
using System;
using System.Reflection;
using UnityEngine;

public static class Position
{

//La correspondance entre chaque position d'échec et leur coordonnée sur l'échéquier
    public static readonly Vector3 A1 = new Vector3(-3.5f, -3.5f, -1f);
    public static readonly Vector3 A2 = new Vector3(-3.5f, -2.5f, -1f);
    public static readonly Vector3 A3 = new Vector3(-3.5f, -1.5f, -1f);
    public static readonly Vector3 A4 = new Vector3(-3.5f, -0.5f, -1f);
    public static readonly Vector3 A5 = new Vector3(-3.5f, 0.5f, -1f);
    public static readonly Vector3 A6 = new Vector3(-3.5f, 1.5f, -1f);
    public static readonly Vector3 A7 = new Vector3(-3.5f, 2.5f, -1f);
    public static readonly Vector3 A8 = new Vector3(-3.5f, 3.5f, -1f);

    public static readonly Vector3 B1 = new Vector3(-2.5f, -3.5f, -1f);
    public static readonly Vector3 B2 = new Vector3(-2.5f, -2.5f, -1f);
    public static readonly Vector3 B3 = new Vector3(-2.5f, -1.5f, -1f);
    public static readonly Vector3 B4 = new Vector3(-2.5f, -0.5f, -1f);
    public static readonly Vector3 B5 = new Vector3(-2.5f, 0.5f, -1f);
    public static readonly Vector3 B6 = new Vector3(-2.5f, 1.5f, -1f);
    public static readonly Vector3 B7 = new Vector3(-2.5f, 2.5f, -1f);
    public static readonly Vector3 B8 = new Vector3(-2.5f, 3.5f, -1f);

    public static readonly Vector3 C1 = new Vector3(-1.5f, -3.5f, -1f);
    public static readonly Vector3 C2 = new Vector3(-1.5f, -2.5f, -1f);
    public static readonly Vector3 C3 = new Vector3(-1.5f, -1.5f, -1f);
    public static readonly Vector3 C4 = new Vector3(-1.5f, -0.5f, -1f);
    public static readonly Vector3 C5 = new Vector3(-1.5f, 0.5f, -1f);
    public static readonly Vector3 C6 = new Vector3(-1.5f, 1.5f, -1f);
    public static readonly Vector3 C7 = new Vector3(-1.5f, 2.5f, -1f);
    public static readonly Vector3 C8 = new Vector3(-1.5f, 3.5f, -1f);
    //
    public static readonly Vector3 D1 = new Vector3(-0.5f, -3.5f, -1f);
    public static readonly Vector3 D2 = new Vector3(-0.5f, -2.5f, -1f);
    public static readonly Vector3 D3 = new Vector3(-0.5f, -1.5f, -1f);
    public static readonly Vector3 D4 = new Vector3(-0.5f, -0.5f, -1f);
    public static readonly Vector3 D5 = new Vector3(-0.5f, 0.5f, -1f);
    public static readonly Vector3 D6 = new Vector3(-0.5f, 1.5f, -1f);
    public static readonly Vector3 D7 = new Vector3(-0.5f, 2.5f, -1f);
    public static readonly Vector3 D8 = new Vector3(-0.5f, 3.5f, -1f);

    public static readonly Vector3 E1 = new Vector3(0.5f, -3.5f, -1f);
    public static readonly Vector3 E2 = new Vector3(0.5f, -2.5f, -1f);
    public static readonly Vector3 E3 = new Vector3(0.5f, -1.5f, -1f);
    public static readonly Vector3 E4 = new Vector3(0.5f, -0.5f, -1f);
    public static readonly Vector3 E5 = new Vector3(0.5f, 0.5f, -1f);
    public static readonly Vector3 E6 = new Vector3(0.5f, 1.5f, -1f);
    public static readonly Vector3 E7 = new Vector3(0.5f, 2.5f, -1f);
    public static readonly Vector3 E8 = new Vector3(0.5f, 3.5f, -1f);

    public static readonly Vector3 F1 = new Vector3(1.5f, -3.5f, -1f);
    public static readonly Vector3 F2 = new Vector3(1.5f, -2.5f, -1f);
    public static readonly Vector3 F3 = new Vector3(1.5f, -1.5f, -1f);
    public static readonly Vector3 F4 = new Vector3(1.5f, -0.5f, -1f);
    public static readonly Vector3 F5 = new Vector3(1.5f, 0.5f, -1f);
    public static readonly Vector3 F6 = new Vector3(1.5f, 1.5f, -1f);
    public static readonly Vector3 F7 = new Vector3(1.5f, 2.5f, -1f);
    public static readonly Vector3 F8 = new Vector3(1.5f, 3.5f, -1f);


    public static readonly Vector3 G1 = new Vector3(2.5f, -3.5f, -1f);
    public static readonly Vector3 G2 = new Vector3(2.5f, -2.5f, -1f);
    public static readonly Vector3 G3 = new Vector3(2.5f, -1.5f, -1f);
    public static readonly Vector3 G4 = new Vector3(2.5f, -0.5f, -1f);
    public static readonly Vector3 G5 = new Vector3(2.5f, 0.5f, -1f);
    public static readonly Vector3 G6 = new Vector3(2.5f, 1.5f, -1f);
    public static readonly Vector3 G7 = new Vector3(2.5f, 2.5f, -1f);
    public static readonly Vector3 G8 = new Vector3(2.5f, 3.5f, -1f);

    public static readonly Vector3 H1 = new Vector3(3.5f, -3.5f, -1f);
    public static readonly Vector3 H2 = new Vector3(3.5f, -2.5f, -1f);
    public static readonly Vector3 H3 = new Vector3(3.5f, -1.5f, -1f);
    public static readonly Vector3 H4 = new Vector3(3.5f, -0.5f, -1f);
    public static readonly Vector3 H5 = new Vector3(3.5f, 0.5f, -1f);
    public static readonly Vector3 H6 = new Vector3(3.5f, 1.5f, -1f);
    public static readonly Vector3 H7 = new Vector3(3.5f, 2.5f, -1f);
    public static readonly Vector3 H8 = new Vector3(3.5f, 3.5f, -1f);


    // Je dois admettre que cette implémentation est vraiment a
    // chier en plus d'être longue a faire mais pour l'instant j'ai pas trouvé d'autre moyen de le faire
    public static Vector3 closestCell(Vector3 mousePos)
    {
        Vector3 closest = A1;
        float minDist = distance(A1, mousePos);

        if (distance(A2, mousePos) < minDist)
        {
            minDist = distance(A2, mousePos);
            closest = A2;
        }
        
        if (distance(A3, mousePos) < minDist)
        {
            minDist = distance(A3, mousePos);
            closest = A3;
        }
        
        if (distance(A4, mousePos) < minDist)
        {
            minDist = distance(A4, mousePos);
            closest = A4;
        }
        
        if (distance(A5, mousePos) < minDist)
        {
            minDist = distance(A5, mousePos);
            closest = A5;
        }
        
        if (distance(A6, mousePos) < minDist)
        {
            minDist = distance(A6, mousePos);
            closest = A6;
        }
        
        if (distance(A7, mousePos) < minDist)
        {
            minDist = distance(A7, mousePos);
            closest = A7;
        }
        
        if (distance(A8, mousePos) < minDist)
        {
            minDist = distance(A8, mousePos);
            closest = A8;
        }
        
        if (distance(B1, mousePos) < minDist)
        {
            minDist = distance(B1, mousePos);
            closest = B1;
        }
        
        if (distance(B2, mousePos) < minDist)
        {
            minDist = distance(B2, mousePos);
            closest = B2;
        }
        
        if (distance(B3, mousePos) < minDist)
        {
            minDist = distance(B3, mousePos);
            closest = B3;
        }
        
        if (distance(B4, mousePos) < minDist)
        {
            minDist = distance(B4, mousePos);
            closest = B4;
        }
        
        if (distance(B5, mousePos) < minDist)
        {
            minDist = distance(B5, mousePos);
            closest = B5;
        }
        
        if (distance(B6, mousePos) < minDist)
        {
            minDist = distance(B6, mousePos);
            closest = B6;
        }
        
        if (distance(B7, mousePos) < minDist)
        {
            minDist = distance(B7, mousePos);
            closest = B7;
        }
        
        if (distance(B8, mousePos) < minDist)
        {
            minDist = distance(B8, mousePos);
            closest = B8;
        }
        
        if (distance(C1, mousePos) < minDist)
        {
            minDist = distance(C1, mousePos);
            closest = C1;
        }
        
        if (distance(C2, mousePos) < minDist)
        {
            minDist = distance(C2, mousePos);
            closest = C2;
        }
        
        if (distance(C3, mousePos) < minDist)
        {
            minDist = distance(C3, mousePos);
            closest = C3;
        }
        
        if (distance(C4, mousePos) < minDist)
        {
            minDist = distance(C4, mousePos);
            closest = C4;
        }
        
        if (distance(C5, mousePos) < minDist)
        {
            minDist = distance(C5, mousePos);
            closest = C5;
        }

        if (distance(C6, mousePos) < minDist)
        {
            minDist = distance(C6, mousePos);
            closest = C6;
        }

        if (distance(C7, mousePos) < minDist)
        {
            minDist = distance(C7, mousePos);
            closest = C7;
        }
        
        if (distance(C8, mousePos) < minDist)
        {
            minDist = distance(C8, mousePos);
            closest = C8;
        }
        
        if (distance(D1, mousePos) < minDist)
        {
            minDist = distance(D1, mousePos);
            closest = D1;
        }
        
        if (distance(D2, mousePos) < minDist)
        {
            minDist = distance(D2, mousePos);
            closest = D2;
        }
        
        if (distance(D3, mousePos) < minDist)
        {
            minDist = distance(D3, mousePos);
            closest = D3;
        }
        
        if (distance(D4, mousePos) < minDist)
        {
            minDist = distance(D4, mousePos);
            closest = D4;
        }
        
        if (distance(D5, mousePos) < minDist)
        {
            minDist = distance(D5, mousePos);
            closest = D5;
        }
        
        if (distance(D6, mousePos) < minDist)
        {
            minDist = distance(D6, mousePos);
            closest = D6;
        }
        
        if (distance(D7, mousePos) < minDist)
        {
            minDist = distance(D7, mousePos);
            closest = D7;
        }
        
        if (distance(D8, mousePos) < minDist)
        {
            minDist = distance(D8, mousePos);
            closest = D8;
        }
        
        if (distance(E1, mousePos) < minDist)
        {
            minDist = distance(E1, mousePos);
            closest = E1;
        }
        
        if (distance(E2, mousePos) < minDist)
        {
            minDist = distance(E2, mousePos);
            closest = E2;
        }
        
        if (distance(E3, mousePos) < minDist)
        {
            minDist = distance(E3, mousePos);
            closest = E3;
        }
        
        if (distance(E4, mousePos) < minDist)
        {
            minDist = distance(E4, mousePos);
            closest = E4;
        }
        
        if (distance(E5, mousePos) < minDist)
        {
            minDist = distance(E5, mousePos);
            closest = E5;
        }
        
        if (distance(E6, mousePos) < minDist)
        {
            minDist = distance(E6, mousePos);
            closest = E6;
        }
        
        if (distance(E7, mousePos) < minDist)
        {
            minDist = distance(E7, mousePos);
            closest = E7;
        }
        
        if (distance(E8, mousePos) < minDist)
        {
            minDist = distance(E8, mousePos);
            closest = E8;
        }
        
        if (distance(F1, mousePos) < minDist)
        {
            minDist = distance(F1, mousePos);
            closest = F1;
        }
        
        if (distance(F2, mousePos) < minDist)
        {
            minDist = distance(F2, mousePos);
            closest = F2;
        }
        
        if (distance(F3, mousePos) < minDist)
        {
            minDist = distance(F3, mousePos);
            closest = F3;
        }
        
        if (distance(F4, mousePos) < minDist)
        {
            minDist = distance(F4, mousePos);
            closest = F4;
        }
        
        if (distance(F5, mousePos) < minDist)
        {
            minDist = distance(F5, mousePos);
            closest = F5;
        }
        
        if (distance(F6, mousePos) < minDist)
        {
            minDist = distance(F6, mousePos);
            closest = F6;
        }
        
        if (distance(F7, mousePos) < minDist)
        {
            minDist = distance(F7, mousePos);
            closest = F7;
        }
        
        if (distance(F8, mousePos) < minDist)
        {
            minDist = distance(F8, mousePos);
            closest = F8;
        }
        
        if (distance(G1, mousePos) < minDist)
        {
            minDist = distance(G1, mousePos);
            closest = G1;
        }
        
        if (distance(G2, mousePos) < minDist)
        {
            minDist = distance(G2, mousePos);
            closest = G2;
        }
        
        if (distance(G3, mousePos) < minDist)
        {
            minDist = distance(G3, mousePos);
            closest = G3;
        }
        
        if (distance(G4, mousePos) < minDist)
        {
            minDist = distance(G4, mousePos);
            closest = G4;
        }
        
        if (distance(G5, mousePos) < minDist)
        {
            minDist = distance(G5, mousePos);
            closest = G5;
        }
        
        if (distance(G6, mousePos) < minDist)
        {
            minDist = distance(G6, mousePos);
            closest = G6;
        }
        
        if (distance(G7, mousePos) < minDist)
        {
            minDist = distance(G7, mousePos);
            closest = G7;
        }
        
        if (distance(G8, mousePos) < minDist)
        {
            minDist = distance(G8, mousePos);
            closest = G8;
        }
        
        if (distance(H1, mousePos) < minDist)
        {
            minDist = distance(H1, mousePos);
            closest = H1;
        }
        
        if (distance(H2, mousePos) < minDist)
        {
            minDist = distance(H2, mousePos);
            closest = H2;
        }
        
        if (distance(H3, mousePos) < minDist)
        {
            minDist = distance(H3, mousePos);
            closest = H3;
        }
        
        if (distance(H4, mousePos) < minDist)
        {
            minDist = distance(H4, mousePos);
            closest = H4;
        }
        
        if (distance(H5, mousePos) < minDist)
        {
            minDist = distance(H5, mousePos);
            closest = H5;
        }
        
        if (distance(H6, mousePos) < minDist)
        {
            minDist = distance(H6, mousePos);
            closest = H6;
        }
        
        if (distance(H7, mousePos) < minDist)
        {
            minDist = distance(H7, mousePos);
            closest = H7;
        }
        
        if (distance(H8, mousePos) < minDist)
        {
            minDist = distance(H8, mousePos);
            closest = H8;
        }
        return closest;
    }

    public static float distance(Vector3 v1, Vector3 v2){
        float a = (v1.x - v2.x);
        a = a * a;
        float b = (v1.y - v2.y);
        b = b * b;
        
        return (float) Math.Sqrt((a+b));
    }
}