using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextTutorial : MonoBehaviour
{
    [SerializeField] GameObject part1Tut;
    [SerializeField] GameObject part2Tut;
    private void OnDestroy()
    {
        Destroy(part1Tut);
        part2Tut.SetActive(true);
    }
}
