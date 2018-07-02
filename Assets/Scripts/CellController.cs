using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CellController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler {
    public int CellNum;
    public Sprite x, o;

    private Image thisImage;
    private bool blockColorChange;
    // Use this for initialization
    void Start ()
    {
        thisImage = GetComponent<Image>();
	}
	
    public void OnPointerEnter(PointerEventData pointerData)
    {
        if(!blockColorChange)
            thisImage.color = new Color32(123, 123, 132, 100);
    }

    public void OnPointerExit(PointerEventData pointerData)
    {
        if(!blockColorChange)
            ResetColor();
    }

    public void OnPointerDown(PointerEventData pointerData)
    {
        if (blockColorChange)
            return;

        if (GameController.turnX)
                thisImage.sprite = x;
            else
                thisImage.sprite = o;

            GameController.turnX = !GameController.turnX;
            ResetColor();
            blockColorChange = true;
    }

    private void ResetColor()
    {
        thisImage.color = new Color32(255, 255, 255, 255);
    }
}
