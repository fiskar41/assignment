using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HeatlhIndicator : MonoBehaviour
{
    [SerializeField] private Player player;
    private TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        text.text = player.health.ToString();
    }
}
