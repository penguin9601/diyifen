using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Common
{
	public class GameMath
	{
        //权重随机
        public static int GetRandomIndexLinear(int[] list)
        {
            int totalWeight = 0;

            for(int i = 0; i < list.Length; i++)
            {
                totalWeight += list[i];
            }

            var value = Random.Range(0, totalWeight);
            for (int i = 0; i < list.Length; i++)
            {
                value -= list[i];
                if (value <= 0)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}

