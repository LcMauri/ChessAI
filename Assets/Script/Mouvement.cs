using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouvement : MonoBehaviour
{
    private Vector3 positionActuel;
    public GameObject board;

    private JeuEchec script;
    // Start is called before the first frame update
    void Start()
    {
        positionActuel = transform.position;
        script = board.GetComponent<JeuEchec>();
    }

    // Update is called once per frame
    void OnMouseDrag()
    {
        gameObject.transform.position = getPosittionSouris();
    }
    
    
    private void OnMouseUp()
    {
        if (getPosittionSouris().x < -0.5f || getPosittionSouris().x > 7.5f || getPosittionSouris().y < -0.5f || getPosittionSouris().y > 7.5f)
        {
            gameObject.transform.position = positionActuel;
        }
        else
        {
            script.mouvementDemandé(gameObject,getPosittionSouris());
        }
    }
    
    Vector3 getPosittionSouris()
    {
        var positionSouris = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        positionSouris.z = -1;
        return positionSouris;
    }

    public Vector3 getPositionActuel()
    {
        return this.positionActuel;
    }
    public void setPositionActuel(Vector3 position)
    {
        gameObject.transform.position = position;
       this.positionActuel=position;
    }
    
    public void resetPosition()
    {
        gameObject.transform.position = positionActuel;
      
    }
}
