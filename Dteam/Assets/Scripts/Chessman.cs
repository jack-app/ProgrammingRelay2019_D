using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chessman : MonoBehaviour
{
    public Vector3 position;

    public Vector2[] movablePositions;

    public int team;

    private Vector2 fieldSize = new Vector2(3, 4);

    public void Move(Vector3 moveposition)
    {
        Vector3 correct_pos = new Vector3(Mathf.Round(moveposition.x), Mathf.Round(moveposition.y), 0);
        if (canMove(correct_pos) == false) return;

        transform.position = correct_pos;
        position = correct_pos;
    }

    public bool canMove(Vector3 moveposition){
        if(0 <= moveposition.x && moveposition.x < fieldSize.x && 0 <= moveposition.y && moveposition.y < fieldSize.y){
            //範囲内
        }else{
            //範囲外
            return false;
        }

        foreach (Vector2 movablePosition in movablePositions)
        {
            Vector2 correct_movablePosition = (Vector2)transform.position + movablePosition;
            Debug.Log(correct_movablePosition);
            if((Vector2)moveposition == correct_movablePosition){
                Vector3 pos = Input.mousePosition;
                pos.z -= Camera.main.transform.position.z;
                Vector3 worldpos = Camera.main.ScreenToWorldPoint(pos);
               
                RaycastHit2D hit = Physics2D.Raycast(worldpos, new Vector3(0, 0, 1));
                if (hit)
                {
                    if (hit.transform.GetComponent<Chessman>().team == team)
                    {
                        Debug.Log("自分のコマがあります");
                        return false;
                    }
                }
                return true;
            }
        }
        return false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if(collision.tag == "chessman"){
            Destroy(collision.gameObject);
        }
    }
}
