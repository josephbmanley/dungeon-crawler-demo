using System;
using Godot;

public delegate void StatUpdatedHandler(int newValue);

interface IStat
{
    int value {get;}
    int max {get;}
    int min {get;}

    event StatUpdatedHandler statUpdated;
}
