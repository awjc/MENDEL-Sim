using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class KeyboardCameraControls : ICameraControls
{
    private Dictionary<KeyCode, CameraAction> _keyMappings;

    protected virtual Dictionary<KeyCode, CameraAction> GetDefaultKeyMappings()
    {
        var mappings = new Dictionary<KeyCode, CameraAction>();
        mappings.Add(KeyCode.W, CameraAction.MOVE_FORWARD);
        mappings.Add(KeyCode.S, CameraAction.MOVE_BACK);
        mappings.Add(KeyCode.A, CameraAction.MOVE_LEFT);
        mappings.Add(KeyCode.D, CameraAction.MOVE_RIGHT);
        mappings.Add(KeyCode.LeftShift, CameraAction.MOVE_UP);
        mappings.Add(KeyCode.LeftControl, CameraAction.MOVE_DOWN);

        mappings.Add(KeyCode.Q, CameraAction.ROLL_CCW);
        mappings.Add(KeyCode.E, CameraAction.ROLL_CW);

        return mappings;
    }

    public Dictionary<KeyCode, CameraAction> GetKeyMappings()
    {
        if (_keyMappings == null)
        {
            _keyMappings = GetDefaultKeyMappings();
        }

        return _keyMappings;
    }

    public List<CameraAction> GetActions()
    {
        List<CameraAction> actions = new List<CameraAction>();

        foreach (var keyMapping in GetKeyMappings())
        {
            if (Input.GetKey(keyMapping.Key))
            {
                actions.Add(keyMapping.Value);
            }
        }

        return actions;
    }
}