using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "GameObjects/Shop Item", order = 0)]

public class ShopItem : MonoBehaviour
{
	public stirng Name = "Default";
	public stirng Description = "Description";
	public int Level;
	public int Price;
	public CurrencyType Currency;
	public ObjectType Type;
	public Sprite Icon;
	public GameObject Prefab;
}

public enum ObjectType
{
	AnimalHomes,
	Animals,
	ProductionBuildings,
	TreesBushes,
	Decorations
}
