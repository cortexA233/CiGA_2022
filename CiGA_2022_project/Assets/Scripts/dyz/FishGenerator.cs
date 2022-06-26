using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGenerator : MonoBehaviour
{
    public GameObject Fish;
    List<Vector2> positionList = new List<Vector2>();

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        for (int i = 0; i < 20; i++)
        {
            GenerateFishes(Fish, CreateRandomPos(), Quaternion.identity);
        }
    }

    public void GenerateFishes(GameObject generateFish, Vector2 generatedPos, Quaternion generateRotation)
    {
        GameObject fishes = Instantiate(generateFish, generatedPos, generateRotation);

        fishes.transform.SetParent(gameObject.transform);

        positionList.Add(generatedPos);
    }

    Vector2 CreateRandomPos()
    {
        while (true)
        {
            Vector2 generatedPos = new Vector2(Random.Range(-9f, 9f), Random.Range(-1f, 0f));

            if (IsPosExist(generatedPos) == false)
            {
                return generatedPos;
            }
        }
    }

    bool IsPosExist(Vector2 generatedPos)
    {
        for (int i = 0; i < positionList.Count; i++)
        {
            if (generatedPos == positionList[i])
            {
                return true;
            }
        }

        return false;
    }
}
