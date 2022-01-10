using UnityEngine;
private sealed class StoreReview.<CoRequestReviewImpl>d__3 : IEnumerator<object>, IEnumerator, IDisposable
{
    // Fields
    private int <>1__state;
    private object <>2__current;
    private Google.Play.Review.ReviewManager <reviewManager>5__2;
    private Google.Play.Common.PlayAsyncOperation<Google.Play.Review.PlayReviewInfo, Google.Play.Review.ReviewErrorCode> <requestFlowOperation>5__3;
    private Google.Play.Common.PlayAsyncOperation<Google.Play.Common.VoidResult, Google.Play.Review.ReviewErrorCode> <launchFlowOperation>5__4;
    
    // Properties
    private object System.Collections.Generic.IEnumerator<System.Object>.Current { get; }
    private object System.Collections.IEnumerator.Current { get; }
    
    // Methods
    public StoreReview.<CoRequestReviewImpl>d__3(int <>1__state)
    {
        this.<>1__state = <>1__state;
    }
    private void System.IDisposable.Dispose()
    {
    
    }
    private bool MoveNext()
    {
        object val_8;
        int val_9;
        Google.Play.Common.PlayAsyncOperation<Google.Play.Common.VoidResult, Google.Play.Review.ReviewErrorCode> val_10;
        val_8 = this;
        if((this.<>1__state) == 2)
        {
            goto label_1;
        }
        
        if((this.<>1__state) == 1)
        {
            goto label_2;
        }
        
        if((this.<>1__state) != 0)
        {
            goto label_3;
        }
        
        this.<>1__state = 0;
        Google.Play.Review.ReviewManager val_1 = new Google.Play.Review.ReviewManager();
        this.<reviewManager>5__2 = val_1;
        Google.Play.Common.PlayAsyncOperation<Google.Play.Review.PlayReviewInfo, Google.Play.Review.ReviewErrorCode> val_2 = val_1.RequestReviewFlow();
        this.<requestFlowOperation>5__3 = val_2;
        this.<>2__current = val_2;
        val_9 = 1;
        this.<>1__state = val_9;
        return (bool);
        label_2:
        this.<>1__state = 0;
        UnityEngine.Debug.Log(message:  "CoAndroiReview: RequestReviewFlow()");
        val_8 = "RequestReviewFlow Error: "("RequestReviewFlow Error: ") + "CoAndroiReview: RequestReviewFlow()"("CoAndroiReview: RequestReviewFlow()");
        UnityEngine.Debug.LogError(message:  val_8);
        label_3:
        val_9 = 0;
        return (bool);
        label_1:
        val_10 = this.<launchFlowOperation>5__4;
        this.<>1__state = 0;
        if(0 != 0)
        {
                UnityEngine.Debug.LogError(message:  "LaunchReviewFlow Error: "("LaunchReviewFlow Error: ") + 0);
            val_10 = this.<launchFlowOperation>5__4;
        }
        
        UnityEngine.Debug.Log(message:  "CoAndroidReview end : "("CoAndroidReview end : ") + val_10);
        val_9 = 0;
        this.<launchFlowOperation>5__4 = 0;
        return (bool);
    }
    private object System.Collections.Generic.IEnumerator<System.Object>.get_Current()
    {
        return (object)this.<>2__current;
    }
    private void System.Collections.IEnumerator.Reset()
    {
        throw new System.NotSupportedException();
    }
    private object System.Collections.IEnumerator.get_Current()
    {
        return (object)this.<>2__current;
    }

}
