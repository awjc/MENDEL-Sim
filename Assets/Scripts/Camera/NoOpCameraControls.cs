using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class NoOpCameraControls : ICameraControls
{
    public List<CameraAction> GetActions()
    {
        return new List<CameraAction>();
    }
}
