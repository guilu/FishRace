using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalera : MonoBehaviour
{
    private enum LadderPart { complete, bottom, top };
    [SerializeField] LadderPart part = LadderPart.complete;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collider de la escalera entry.....");
        //si la colisiion es con el Player
        if (collision.GetComponent<PlayerMovement>())
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            switch (part)
            {
                case LadderPart.complete:
                    player.canClimb = true;
                    break;
                case LadderPart.bottom:
                    player.bottomLadder = true;
                    break;
                case LadderPart.top:
                    player.topLadder = true;
                    break;
                default:
                    Debug.Log("en la escalera pero estado fail");
                    break;
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Collider de la escalera sale....");

        //si la colisiion es con el Player
        if (collision.GetComponent<PlayerMovement>())
        {
            PlayerMovement player = collision.GetComponent<PlayerMovement>();
            switch (part)
            {
                case LadderPart.complete:
                    player.canClimb = false;
                    break;
                case LadderPart.bottom:
                    player.bottomLadder = false;
                    break;
                case LadderPart.top:
                    player.topLadder = false;
                    break;
                default:
                    Debug.Log("en la escalera pero estado fail");
                    break;
            }
        }
    }
}
