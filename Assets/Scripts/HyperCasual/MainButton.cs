using UnityEngine;

namespace HyperCasual
{
    public class MainButton : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IBeginDragHandler, IDragHandler, IEndDragHandler, IPointerUpHandler, IPointerClickHandler
    {
        // Fields
        private HyperCasual.Manager _manager;
        
        // Methods
        private void UnityEngine.EventSystems.IPointerDownHandler.OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_1D0;
        }
        private void UnityEngine.EventSystems.IBeginDragHandler.OnBeginDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_1E0;
        }
        private void UnityEngine.EventSystems.IDragHandler.OnDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_1F0;
        }
        private void UnityEngine.EventSystems.IEndDragHandler.OnEndDrag(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_200;
        }
        private void UnityEngine.EventSystems.IPointerUpHandler.OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
        {
            UnityEngine.EventSystems.PointerEventData val_1 = HyperCasual.Extension.ToPointer(self:  eventData);
            goto typeof(HyperCasual.Manager).__il2cppRuntimeField_210;
        }
        private void UnityEngine.EventSystems.IPointerClickHandler.OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
        {
            if(this._manager != null)
            {
                    return;
            }
            
            throw new NullReferenceException();
        }
        public MainButton()
        {
        
        }
    
    }

}
