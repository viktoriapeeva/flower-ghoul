using UnityEngine;


[CreateAssetMenu(fileName ="New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
 new   public string name = "New Item";
    public Sprite icon = null;
    public string description = "Default description";
    public bool isDefaultItem = false;
    public GameObject prefab;

}
