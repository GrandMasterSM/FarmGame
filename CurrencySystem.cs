using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrencySystem : MonoBehaviour
{
private static Dictionary<CurrencyType, int> CurrencyAmounts = new Dictionary <CurrencyType, int>();

[SerializeField] private List<GameObject> texts;

private Dictionary<CurrencyType, TextMeshProUGUI> CurrencyTexts =
new Dictionary <CurrencyType, TextMeshProUGUI>();

private void Awake()
{
for (int i =0; i < texts.Count; i++)
{
CurrencyAmounts.Add((CurrencyType)i, 0);
CurrencyTexts.Add((CurrencyType)i, texts[i].transform.GetChild(0). GetComponent<TextMeshProUGUI>());
}
}

private void Start()
{
EventManager.Instance.AddListener<CurrencyChangeGameEvent>(OnCurrencyChange);
EventManager.Instance.AddListener<NotEnoughCurrencyGameEvent>(OnNotEnough);
}

private void OnCurrencyChange(CurrencyChangeGameEvent info)
{
CurrencyAmonts[info.CurrencyType] += info.amount;
CurrencyTexts[info.CurrencyType].text = CurrencyAmounts[info.CurrencyType].ToString();
}

private void OnNotEnough(NotEnoughCurrencyGameEvent info)
{
Debug.Log("You dont have enough of {info.amount} {info.currencyType}");
}
}
public enum CurrencyType
{
Coins,
Crystals
}
