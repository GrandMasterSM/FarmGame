using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BuildingSystem : MonoBehaviour
{
	public static BuildingSystem current;
	
	public GridLayout gridLayout;
	public Tilemap MainTilemap;
	public TileBase takenTile;
	
	#region Building Placement
	
	public void InitializeWithObject(GameObject building, Vector3 pos)
	{
		pos.z = 0;
		pos.y = building.GetComponent<SpriteRenderer>().bounds.size.y / 2f;
		Vector3Int cellPos = gridLayout.WorldToCell(pos);
		Vector3 position = gridLayout.CellToLocalInterpolated(cellPos);
		
		GameObject obj = Instantiate(building, position, Quaternion.identity);
		PlaceableObject temp = obj.transform.GetComponent<PlaceableObject>();
		temp.GameObject.AddComponent<ObjectDrag>();
	}
	
	public bool CanTakeArea(BoundsInt area)
	{
		TileBase[] baseArray = GetTilesBlock(area, MainTilemap);
		foreach (var b in baseArray)
		{
			if (b == takenTile)
			{
				return false;
			}
		}
		
		return true;
	}
	
	public void TakeArea(BoundsInt area)
	{
	SetTilesBlock(area, takenTile, MainTilemap);
	}
	
	#endregion
}
	
   
