using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum CameraControlImplementation
{
    Keyboard,
    Gamepad
}

public class CameraControlImplementations
{
    public static ICameraControls GetControlsFor(CameraControlImplementation impl)
    {
        switch (impl)
        {
            case CameraControlImplementation.Keyboard:
                return new KeyboardCameraControls();
            case CameraControlImplementation.Gamepad:
                return new KeyboardCameraControls();

            default:
                return new NoOpCameraControls();
        }
    }
}
