using System;
using Xunit;
using RxCS;

namespace RxCS.Test;

public class SubscriverTest
{
    [Fact]
    public void AllArgumentsSupplied_ShouldCreate()
    {
        Action<int> onNext = _ => { };
        Action<Exception> onError = _ => { };

        var subscriber = new Subscriber<int>(onNext, onError);

        Assert.NotNull(subscriber);
    }

    [Fact]
    public void OnNext_ShouldCallAction()
    {
        var called = false;
        Action<int> onNext = _ => called = true;
        Action<Exception> onError = _ => { };

        var subscriber = new Subscriber<int>(onNext, onError);

        subscriber.Next(1);

        Assert.True(called);
    }

    [Fact]
    public void OnError_SchouldCallError()
    {
        var called = false;
        Action<int> onNext = _ => { };
        Action<Exception> onError = _ => called = true;

        var subscriber = new Subscriber<int>(onNext, onError);

        subscriber.Error(new Exception());

        Assert.True(called);
    }
}