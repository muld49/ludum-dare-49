using UnityEngine;
using UnityEngine.UI;

public class ShowItem : MonoBehaviour
{
    public Inventory inventory;
    public int index;

    Image itemSprite;

    void Start()
    {
        itemSprite = GetComponent<Image>();
    }

    void Update()
    {
        if (inventory.Count() > index) {
            itemSprite.sprite = inventory[index].GetComponent<SpriteRenderer>().sprite;
            itemSprite.color = inventory[index].GetComponent<SpriteRenderer>().color;
        }
    }
}
