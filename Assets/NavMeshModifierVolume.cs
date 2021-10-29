using System;
using System.Collections.Generic;

namespace UnityEngine.AI
{
    internal class NavMeshModifierVolume
    {
        internal static List<NavMeshModifierVolume> activeModifiers;
        internal bool isActiveAndEnabled;
        internal object transform;

        internal bool AffectsAgentType(int m_AgentTypeID)
        {
            throw new NotImplementedException();
        }
    }
}