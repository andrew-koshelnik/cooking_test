using UnityEngine;

namespace cooking.so
{
    [CreateAssetMenu(fileName = "Level", menuName = "ScriptableObjects/Level", order = 1)]
    public class LevelConfig : ScriptableObject
    {
        public int ID;
        public int Duration;
        public int TargetDishServed;
        public int MinSpawnTime;
        public int MaxSpawnTime;
        public int NumberOfWaiters;
        public OrderConfig OrderConfig;
    }
}