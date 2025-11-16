using System.Collections.Generic;
using UnityEngine;

public class GraphTest : MonoBehaviour
{
    [SerializeField] private int minValue = 0;
    [SerializeField] private int maxValue = 50;
    [SerializeField] private int listSizes = 10;

    private List<int> ints = new List<int>();
    private List<int> ints2 = new List<int>();

    private void Awake()
    {
        RandomizeLists();
        RunTests();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomizeLists();
            RunTests();
        }
    }

    private void RandomizeLists()
    {
        ints.Clear();
        ints2.Clear();
        for (int i = 0; i < listSizes; i++)
        {
            ints.Add(UnityEngine.Random.Range(minValue, maxValue));
            ints2.Add(UnityEngine.Random.Range(minValue, maxValue));
        }
    }

    private void RunTests()
    {
        Debug.ClearDeveloperConsole();
        Debug.Log("List 1: " + string.Join(", ", ints));
        Debug.Log("List 2: " + string.Join(", ", ints2));
        Debug.Log("All > 10: " + GraphMethods.All(ints, x => x > 10));
        Debug.Log("Any > 40: " + GraphMethods.Any(ints, x => x > 40));
        Debug.Log("Contains 25: " + GraphMethods.Contains(ints, 25));
        Debug.Log("Distinct: " + string.Join(", ", GraphMethods.Distinct(ints)));
        Debug.Log("ElementAt(3): " + GraphMethods.ElementAt(ints, 3));
        Debug.Log("Except List2: " + string.Join(", ", GraphMethods.Except(ints, ints2)));
        Debug.Log("First > 20: " + GraphMethods.First(ints, x => x > 20));
        Debug.Log("Last < 30: " + GraphMethods.Last(ints, x => x < 30));
        Debug.Log("Intersect with List2: " + string.Join(", ", GraphMethods.Intersect(ints, ints2)));
        Debug.Log("Count > 15: " + GraphMethods.Count(ints, x => x > 15));
        Debug.Log("SkipWhile < 20: " + string.Join(", ", GraphMethods.SkipWhile(ints, x => x < 20)));
        Debug.Log("Union with List2: " + string.Join(", ", GraphMethods.Union(ints, ints2)));
        Debug.Log("Where > 25: " + string.Join(", ", GraphMethods.Where(ints, x => x > 25)));
        Debug.Log("SequenceEqual with List2: " + GraphMethods.SequenceEqual(ints, ints2, EqualityComparer<int>.Default));
    }
}