namespace RxCS;

public class Subscriber<T>: IDisposable{
    private readonly Action<T> onNext;
    private readonly Action<Exception> onError;
    private bool disposedValue;

    /// <summary> 
    /// Creates a new Subscriber.
    /// </summary>
    public Subscriber(Action<T> onNext, Action<Exception> onError) {
        this.onNext = onNext;
        this.onError = onError;
    }

    /// <summary>
    /// Emits a new value for the given subscriber
    /// </summary>
    public void Next(T next) {
        onNext(next);
    }

    /// <summary>
    /// Emits an error for the given subscriber
    /// </summary>
    public void Error(Exception error) {
        onError(error);
    }

    #region IDisposable Support
    protected virtual void Dispose(bool disposing)
    {
        if (!disposedValue)
        {
            if (disposing)
            {
                
            }
            disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
    #endregion
    
}
