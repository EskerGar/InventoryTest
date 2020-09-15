namespace EquipObjects
{
    public static class IdPool
    {
        private static int _idCount;

        public static int GetNewId() => _idCount++;
    }
}