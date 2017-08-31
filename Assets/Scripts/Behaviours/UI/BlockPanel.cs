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

    void cerrarPestaña()
    {
        this.gameObject.SetActive(false);
    }
}
