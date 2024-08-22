using PlateauToolkit.Sandbox.Runtime.PlateauSandboxBuildingsLib;
using ProceduralToolkit;
using System;
using UnityEngine;

namespace PlateauToolkit.Sandbox.Runtime.PlateauSandboxBuildings.Runtime
{
    public abstract class ProceduralFacadeWallElement : ProceduralFacadeElement
    {
        protected class WallColorData
        {
            public Color m_WallColor;
            public Material m_VertexColorWallMat;
        }

        protected class WallTexturedData
        {
            public string m_WallName = k_WallTexturedDraftName;
            public Vector2 m_UVScale;
            public Material m_WallMat;
        }

        protected class DepressionWallColorData : WallColorData
        {
            public PositionType m_PositionType;
        }

        protected class DepressionWallTexturedData : WallTexturedData
        {
            public PositionType m_PositionType;
        }

        protected static MeshDraft Wall(Vector3 origin, float width, float height, WallColorData wallColorData)
        {
            return new MeshDraft {name = k_WallDraftName}
                .AddQuad(origin, Vector3.right*width, Vector3.up*height, calculateNormal:true)
                .Paint(wallColorData.m_WallColor, wallColorData.m_VertexColorWallMat);
        }

        protected static MeshDraft Wall(Vector3 origin, Vector3 width, Vector3 height, WallColorData wallColorData)
        {
            return new MeshDraft {name = k_WallDraftName}
                .AddQuad(origin, width, height, calculateNormal:true)
                .Paint(wallColorData.m_WallColor, wallColorData.m_VertexColorWallMat);
        }

        protected static MeshDraft WallTextured(Vector3 origin, float width, float height, WallTexturedData wallTexturedData)
        {
            return new MeshDraft {name = wallTexturedData.m_WallName}
                .AddQuad(origin, Vector3.right*width, Vector3.up*height, wallTexturedData.m_UVScale, calculateNormal:true, generateUV:true)
                .Paint(wallTexturedData.m_WallMat);
        }

        protected static MeshDraft WallTextured(Vector3 origin, Vector3 width, Vector3 height, WallTexturedData wallTexturedData)
        {
            return new MeshDraft {name = wallTexturedData.m_WallName}
                .AddQuad(origin, width, height, wallTexturedData.m_UVScale, calculateNormal:true, generateUV:true)
                .Paint(wallTexturedData.m_WallMat);
        }

        protected static MeshDraft DepressionWall(Vector3 origin, Vector3 width, Vector3 height, DepressionWallColorData wallColorData)
        {
            Vector3 depressionThickness = -Vector3.back * 0.3f;
            Vector3 depressionWidth;
            Vector3 depressionMoveWidth;
            switch (wallColorData.m_PositionType)
            {
                case PositionType.k_Left:
                    depressionWidth = width - Vector3.right * 0.3f;
                    depressionMoveWidth = depressionWidth * 0.5f + Vector3.right * 0.3f;
                    break;
                case PositionType.k_Middle:
                    depressionWidth = width;
                    depressionMoveWidth = depressionWidth * 0.5f;
                    break;
                case PositionType.k_Right:
                    depressionWidth = width - Vector3.right * 0.3f;
                    depressionMoveWidth = depressionWidth * 0.5f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            MeshDraft depressionWallYAxis = MeshDraft
                .PartialBox(width, depressionThickness, height, Directions.YAxis)
                .FlipFaces()
                .Move(origin + width / 2 + height / 2 + depressionThickness / 2)
                .Paint(wallColorData.m_WallColor, wallColorData.m_VertexColorWallMat);

            MeshDraft depressionWallBack = MeshDraft
                .PartialBox(depressionWidth, -depressionThickness, height, Directions.Back)
                .Move(origin + depressionMoveWidth + height / 2 + depressionThickness / 2)
                .Paint(wallColorData.m_WallColor, wallColorData.m_VertexColorWallMat);
            depressionWallYAxis.Add(depressionWallBack);
            depressionWallYAxis.name = k_WallDraftName;

            return depressionWallYAxis;
        }

        protected static MeshDraft DepressionWallTextured(Vector3 origin, Vector3 width, Vector3 height, DepressionWallTexturedData wallTexturedData)
        {
            Vector3 depressionThickness = -Vector3.back * 0.3f;
            Vector3 depressionWidth;
            Vector3 depressionMoveWidth;
            switch (wallTexturedData.m_PositionType)
            {
                case PositionType.k_Left:
                    depressionWidth = width - Vector3.right * 0.3f;
                    depressionMoveWidth = depressionWidth * 0.5f + Vector3.right * 0.3f;
                    break;
                case PositionType.k_Middle:
                    depressionWidth = width;
                    depressionMoveWidth = depressionWidth * 0.5f;
                    break;
                case PositionType.k_Right:
                    depressionWidth = width - Vector3.right * 0.3f;
                    depressionMoveWidth = depressionWidth * 0.5f;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            MeshDraft depressionWallYAxis = MeshDraft
                .PartialBox(width, depressionThickness, height, Directions.YAxis, true)
                .FlipFaces()
                .Move(origin + width / 2 + height / 2 + depressionThickness / 2)
                .Paint(wallTexturedData.m_WallMat);

            MeshDraft depressionWallBack = MeshDraft
                .PartialBox(depressionWidth, -depressionThickness, height, Directions.Back, true)
                .Move(origin + depressionMoveWidth + height / 2 + depressionThickness / 2)
                .Paint(wallTexturedData.m_WallMat);
            depressionWallYAxis.Add(depressionWallBack);

            return depressionWallYAxis;
        }
    }
}
