using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
private int XPNow;
private int Level;
private int xpToNext;

[SerializeField] private GameObject levelPanel;
[SerializeField] private GameObject lvlWindowPrefab;

private Slider slider;
private TextMeshProUGUI xpText;
private TextMeshProUGUI lvlText;
private Image starImage;

private static bool initialized;
private static Dictionary<int, int> xpToNextLevel = new Dictionary<int, int>();
private static Dictionary<int, int[]> lvlReward =  new Dictionary<int, int>();

private void Awake()
    {
	slider.levelPanel.GetComponent<Slider>();
	xpText = levelPanel.transform.Find("XP text").GetComponent<TextMeshProUGUI>();
	starImage = levelPanel.transform.Find("Star").GetComponent<Image>();
	lvlText = starImage.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
	
	if (!initialized)
	{
		Initialize();
	}
	
	xpToNextLevel.TryGetValue(Level, 0);
    }
}
