using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour
{



    public GameObject select;
    Color color;
    public GameObject chessman;
    public static int turn=1;
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        color = chessman. GetComponent<SpriteRenderer>().color;

    }

    // Update is called once per frame
    void Update()
    {
        Click();
        if (turn == 1)
        {
            text.text = "王の番です";
        }
        else
        {
            text.text = "玉の番です";
        }
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
                select.GetComponent<SpriteRenderer>().color =color;
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
                        select.GetComponent<SpriteRenderer>().color = Color.red;
                    }
                }
            }
        }
    }
}
