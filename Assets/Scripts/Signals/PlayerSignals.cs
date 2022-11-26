using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction<bool> onInteractionWithBorder = delegate{  };
        public UnityAction<bool> onInteractionWithHookEntry = delegate {  };
        public UnityAction<bool> onInteractionWithHookExit = delegate {  };
        public UnityAction onHasImpact = delegate { };
        public UnityAction onChangeMoveDirection = delegate {  };
    }
}