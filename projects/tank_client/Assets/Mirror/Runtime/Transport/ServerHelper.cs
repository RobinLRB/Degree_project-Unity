/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ServerHelper
{
    static readonly ILogger logger = LogFactory.GetLogger<ServerHelper>();

    public static void SetupForServer(GameObject obj)
    {
        logger.LogWarning("ServerHelper invoked");

        Component[] renderers;
        renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer rend in renderers)
        {
            rend.enabled = false;
        }

    }
}
*/