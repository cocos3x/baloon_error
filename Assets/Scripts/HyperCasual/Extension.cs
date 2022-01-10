using UnityEngine;

namespace HyperCasual
{
    public static class Extension
    {
        // Methods
        public static UnityEngine.EventSystems.PointerEventData ToPointer(UnityEngine.EventSystems.BaseEventData self)
        {
            if(self == null)
            {
                    return (UnityEngine.EventSystems.PointerEventData)self;
            }
            
            return (UnityEngine.EventSystems.PointerEventData)self;
        }
    
    }

}
