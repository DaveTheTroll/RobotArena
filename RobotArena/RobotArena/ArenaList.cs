using System;
using System.Collections.Generic;

namespace RobotArena
{
    public class ArenaList : IEnumerable<Arena>
    {
        public ArenaList()
        {
            AddArena(new Arena());
        }

        Dictionary<int, Arena> arenas = new Dictionary<int,Arena>();

        public void AddArena(Arena arena) {arenas.Add(arena.Handle, arena);}
        public Arena GetArena(int handle)
        {
            try
            {
                return arenas[handle];
            }
            catch (KeyNotFoundException)
            {
                throw new ApplicationException(string.Format("Arena '{0}' does not exist.", handle));
            }
        }

        public IEnumerator<Arena> GetEnumerator() { return arenas.Values.GetEnumerator(); }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() { return GetEnumerator(); }
    }
}
