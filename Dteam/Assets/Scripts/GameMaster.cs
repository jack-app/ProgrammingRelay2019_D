using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{



    public GameObject select;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Click();
    }

    void Click()
    {
        Vector3 pos = Input.mousePosition;

        if (Input.GetMouseButtonDown(0))
        {
            if (select != null)
            {
                pos.z -= Camera.main.transform.position.z;
                Vector3 world_pos = Camera.main.ScreenToWorldPoint(pos);
                select.GetComponent<Chessman>().Move(world_pos);
                Debug.Log(world_pos);
                select = null;
            }
            else
            {
                //オブジェクトが格納されてないとき
                Ray ray = Camera.main.ScreenPointToRay(pos);
                Debug.Log(ray.origin);
                RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);
                if (hit)
                {

                    Debug.Log("ヒットしました");

                    if (hit.transform.tag == "chessman")
                    {
                        select = hit.transform.gameObject;
                    }
                }
            }
        }
    }
}
