using UnityEngine.UI;
using UnityEngine;

public class ShowAccumulatedTrash : MonoBehaviour, ITrashChangedListener
{
    House house;
    public Text trashText;
    
    void Start()
    {
        house = GetComponent<House>();
        //house.addTrashChangedListener(this); TODO
    }

    public void onTrashChanged()
    {
        //if (trashText != null)
        //{
        //    trashText.text = house.AccumulatedTrash + "/" + House.TRASH_CAPACITY;
        //    float lerp = 0;
        //    if (house.AccumulatedTrash >= 10)
        //    {
        //        lerp = ((float)((float)house.AccumulatedTrash) / ((float)House.TRASH_CAPACITY));
        //    }
        //    trashText.color = Color.Lerp(ColorPalette.Green, Color.red, lerp);
        //}
    }
}
