using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BikeStateContext
{
    public IBikeState CurrentState { get; set; }

    private readonly BikeController _bikeController;  // readonly는 const와는 다르게 compile 시점에 값을 확정하지 않음.(runtime 시점에 이르러서야 값을 확정)

    public BikeStateContext(BikeController bikeController)
    {
        _bikeController = bikeController;
    }

    public void Transition()
    {
        CurrentState.Handle(_bikeController);
    }

    public void Transition(IBikeState state)
    {
        CurrentState = state;
        CurrentState.Handle(_bikeController);
    }
}
