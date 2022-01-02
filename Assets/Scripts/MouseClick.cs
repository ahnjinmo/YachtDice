using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClick : MonoBehaviour
{
    public Camera getCam;
    RaycastHit hit;
    public Transform dice;
    public DiceMovements Dm;
    public GameObject SelectedObject;
    public string ObjName;
    Vector3 InitPosition;

    


    // Start is called before the first frame update
    void Start()
    {

    }


    // 다이스 옆면의 collider들이 잡히는 것 확인 해야함
 

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
                Ray ray = getCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;

                if (Physics.Raycast(ray, out hitInfo))
                {
                    GameObject hitObject = hitInfo.transform.gameObject;
                    ObjName = hitInfo.collider.gameObject.name;
                    SelectObject(hitObject);
                }
                else
                {
                    ClearSelection();
                }
            if (SelectedObject.tag == "Dice")
            {
                dice = GameObject.Find(ObjName).GetComponentInParent<Transform>();
                Dm = GameObject.Find(ObjName).GetComponentInParent<DiceMovements>();
                InitPosition = Dm.initPosition;

            }
        }

        

    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if ((dice.transform.position - InitPosition) == new Vector3(0, 0, 0))
            {
                dice.transform.position = dice.transform.position + new Vector3(0, 0, 5);
                Dm.diceswitch = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if ((dice.transform.position - InitPosition) != new Vector3(0, 0, 0))
            {
                dice.transform.position = InitPosition;
                Dm.diceswitch = true;
            }
        }
        // 다이스 선택시 끄고 다시 키는거 설정해야함 
    }
    void SelectObject(GameObject obj)
    {
        if (SelectedObject != null)
        {
            if (obj == SelectedObject)
                return;

            ClearSelection();
        }
        SelectedObject = obj;
    }

    void ClearSelection()
    {
        if (SelectedObject == null)
            return;

        SelectedObject = null;
    }
}
