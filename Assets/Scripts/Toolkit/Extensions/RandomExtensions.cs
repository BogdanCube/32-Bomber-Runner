using System.Collections.Generic;
using UnityEngine;

namespace Toolkit.Extensions
{
    public static class RandomExtensions
    {
        public static T RandomItem<T>(this IList<T> list)
        {
            if (list.Count == 0)
            {
                throw new System.IndexOutOfRangeException("Cannot select a random item from an empty list");
            }
            

            return list[Random.Range(0, list.Count)];
        }
        
        public static int RandomRange(this Vector2Int vector)
        {
            return Random.Range(vector.x, vector.y);
        }
        public static float RandomRange(this Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }
        public static Vector3 RandomVector()
        {
            var randomX = Random.Range(-1, 2);
            var randomY = Random.Range(-1, 2);
            var randomZ = Random.Range(-1, 2);
            return new Vector3(randomX, randomY, randomZ);
        }
    }
}