using UnityEngine;

namespace Kayac
{
    public static class StoreReview
    {
        // Methods
        public static void RequestReview(UnityEngine.MonoBehaviour coroutineRunner, System.Action onComplete)
        {
            UnityEngine.Coroutine val_2 = coroutineRunner.StartCoroutine(routine:  Kayac.StoreReview.CoRequestReview(onComplete:  onComplete));
        }
        public static System.Collections.IEnumerator CoRequestReview()
        {
            .<>1__state = 0;
            return (System.Collections.IEnumerator)new StoreReview.<CoRequestReview>d__1();
        }
        private static System.Collections.IEnumerator CoRequestReview(System.Action onComplete)
        {
            .<>1__state = 0;
            .onComplete = onComplete;
            return (System.Collections.IEnumerator)new StoreReview.<CoRequestReview>d__2();
        }
        private static System.Collections.IEnumerator CoRequestReviewImpl()
        {
            .<>1__state = 0;
            return (System.Collections.IEnumerator)new StoreReview.<CoRequestReviewImpl>d__3();
        }
    
    }

}
