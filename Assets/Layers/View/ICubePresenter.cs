using System;
using UnityEngine;

public interface ICubePresenter
{
   public void RecolorCube(Color newColor);
    public void AddListenerOnColorChanged(Action<Color> listener);
   public Color GetCubeColor();
}
