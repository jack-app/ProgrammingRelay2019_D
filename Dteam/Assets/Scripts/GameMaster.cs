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
                pos.z -= Camera.main.transform.position.z;
                Vector3 worldpos = Camera.main.ScreenToWorldPoint(pos);
                Ray ray = Camera.main.ScreenPointToRay(pos);
                //Debug.DrawRay(ray.origin, ray.direction);
                //Debug.Log(ray.origin);
                
                RaycastHit2D hit = Physics2D.Raycast(worldpos, new Vector3(0,0,1));
                //Debug.DrawRay(worldpos, new Vector3(0, 0, 1));
                
                if (hit)
                {

                    Debug.Log(hit.transform.gameObject.name);

                    if (hit.transform.tag == "chessman")
                    {
                        select = hit.transform.gameObject;
                    }
                }
            }
        }
    }
}
