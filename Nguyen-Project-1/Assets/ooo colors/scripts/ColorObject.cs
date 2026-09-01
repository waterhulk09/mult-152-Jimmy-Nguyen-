/*
using UnityEngine;

public class ColorObject : MonoBehaviour
{
    
public enum ColorState
{
Red,

Green,

Blue
}


public Material redMaterial;

public Material greenMaterial;

public Material blueMaterial;


public ColorState CurrentColor {get; private set;}

private Renderer rend;

private void Awake()
{
    rend = GetComponent<Renderer>();
}

private void Start()
{
    SetColor(ColorState.Red);
}

public Void CycleColor()
{
    switch(CurrentColor)

    case ColorState.Red:
    SetColor(ColorState.Green);
    break;

    
    switch(CurrentColor)

    case ColorState.Green:
    SetColor(ColorState.Blue);
    break;

    
    switch(CurrentColor)

    case ColorState.Blue:
    SetColor(ColorState.Red);
    break;
}

ColorMatchManager.Instance.CheckMatch();
 
  }

  Private Void SetColor (ColorState color);
{
    CurrentColor = color;

    switch(color)

}
} */
