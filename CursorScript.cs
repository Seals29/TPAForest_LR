using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    Cinemachine.CinemachineFreeLook camcinema;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt)&&Cursor.visible==true)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else if (Input.GetKeyDown(KeyCode.LeftAlt) &&Cursor.visible==false)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (Cursor.visible==true)//unlock cursor
        {
            camcinema.m_XAxis.m_InputAxisName = "";
            camcinema.m_YAxis.m_InputAxisName = "";
        }
        else if(Cursor.visible==false)//lock cursor
        {
            camcinema.m_XAxis.m_InputAxisName = "Mouse X";
            camcinema.m_YAxis.m_InputAxisName = "Mouse Y";
        }
    }
}
