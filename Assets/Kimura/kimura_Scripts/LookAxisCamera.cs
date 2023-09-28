using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class LookAxisCamera : CinemachineExtension
{
    [Tooltip("�J������Y���W���Œ肷��l")]
    public float m_YPosition = 10;

    protected override void PostPipelineStageCallback(
        CinemachineVirtualCameraBase vcam,
        CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
    {
        if (stage == CinemachineCore.Stage.Body)
        {
            var pos = state.RawPosition;
            pos.y = m_YPosition;
            state.RawPosition = pos;
        }
    }
}
