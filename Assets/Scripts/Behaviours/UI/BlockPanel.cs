using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockPanel : MonoBehaviour {

    public Camera move;
    public Button btnCerrar;
    private MoveCamera moveC;

    void Awake () {
        Button btn0 = btnCerrar.GetComponent<Button>();
        moveC = move.GetComponent<MoveCamera>();
        btn0.onClick.AddListener(cerrarPestaña);
    }

    void OnEnable()
    {
        moveC.turnSpeed = 0;
        moveC.zoomSpeed = 0;
        moveC.panSpeed = 0;
    }
    void OnDisable()
    {
        moveC.turnSpeed = 4;
        moveC.zoomSpeed = 4;
        moveC.panSpeed = 4;
    }

    void cerrarPestaña()
    {
        this.gameObject.SetActive(false);
    }
}
