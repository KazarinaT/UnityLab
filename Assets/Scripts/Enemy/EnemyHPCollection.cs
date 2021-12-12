using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Enemy
{
    static class EnemyHPCollection
    {
        public static float GetSizeDeltaHP(string name)
        {
            switch (name)
            {
                case "TurtleShell":
                    return 100f;
            }

            return 0f;
        }
    }
}
