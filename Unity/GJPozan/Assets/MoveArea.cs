using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveArea : MonoBehaviour
{
    public PlayerController player;
    private void OnMouseDown()
    {
        Debug.Log("muszyka");
        if (player.canCollect)
        {
            player.onTheWay = true;
            player.animator.SetBool("walk", true);
            player.elapsedTime = 0;
            player.startPosition = new Vector3(player.transform.position.x, player.transform.position.y, -2.75f);
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            player.targetPosition = new Vector3(mousePos.x, mousePos.y, -2.75f);
        }
    }
}
