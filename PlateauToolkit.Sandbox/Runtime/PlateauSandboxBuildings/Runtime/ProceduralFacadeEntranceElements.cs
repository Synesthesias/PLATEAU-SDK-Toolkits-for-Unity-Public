using PlateauToolkit.Sandbox.Runtime.PlateauSandboxBuildingsLib;
using ProceduralToolkit;
using System.Collections.Generic;
using UnityEngine;

namespace PlateauToolkit.Sandbox.Runtime.PlateauSandboxBuildings.Runtime
{
    public abstract class ProceduralFacadeEntranceElement : ProceduralFacadeElement
    {
        protected class EntranceColorData
        {
            public bool m_HasRoof;
            public Color m_WallColor;
            public Color m_EntranceDoorColor;
            public Color m_EntranceDoorFrameColor;
            public Color m_EntranceRoofColor;
            public Material m_VertexWallMaterial;
        }

        protected class EntranceTexturedData
        {
            public bool m_HasRoof;
            public Vector2 m_UVScale;
            public Material m_WallMat;
            public Material m_EntranceDoorMat;
            public Material m_EntranceDoorFrameMat;
            public Material m_EntranceDoorRoofMat;
        }

        protected static MeshDraft Entrance(
            Vector3 origin,
            float width,
            float height,
            EntranceColorData entranceColorData
            )
        {
            Vector3 widthVector = Vector3.right*width;
            Vector3 heightVector = Vector3.up*height;

            Vector3 doorWidth = Vector3.right*k_EntranceDoorWidth;
            Vector3 doorHeight = Vector3.up*k_EntranceDoorHeight;
            Vector3 doorThickness = Vector3.back*k_EntranceDoorThickness;
            Vector3 doorOrigin = origin + widthVector/2 - doorWidth/2;

            MeshDraft draft = EntranceBracket(origin, widthVector, heightVector, doorOrigin, doorWidth, doorHeight)
                .Paint(entranceColorData.m_WallColor, entranceColorData.m_VertexWallMaterial);

            MeshDraft doorFrame = MeshDraft.PartialBox(doorWidth, -doorThickness, doorHeight, Directions.All & ~Directions.ZAxis, generateUV: false)
                .Move(doorOrigin + doorWidth / 2 + doorHeight / 2 + doorThickness / 2)
                .Paint(entranceColorData.m_EntranceDoorColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(doorFrame);

            MeshDraft door = new MeshDraft().AddQuad(doorOrigin + doorThickness, doorWidth, doorHeight, calculateNormal: true)
                .Paint(entranceColorData.m_EntranceDoorColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(door);

            draft.name = k_WallDraftName;
            return draft;
        }

        protected static CompoundMeshDraft EntranceTextured(
            Vector3 origin,
            float width,
            float height,
            EntranceTexturedData entranceTexturedData
            )
        {
            Vector3 widthVector = Vector3.right*width;
            Vector3 heightVector = Vector3.up*height;

            Vector3 doorWidth = Vector3.right*k_EntranceDoorWidth;
            Vector3 doorHeight = Vector3.up*k_EntranceDoorHeight;
            Vector3 doorThickness = Vector3.back*k_EntranceDoorThickness;
            Vector3 doorOrigin = origin + widthVector/2 - doorWidth/2;

            var meshDraft = new CompoundMeshDraft();

            MeshDraft draft = EntranceBracketTextured(origin, widthVector, heightVector, doorOrigin, doorWidth, doorHeight, entranceTexturedData.m_UVScale)
                .Paint(entranceTexturedData.m_EntranceDoorMat);
            draft.name = k_EntranceDoorTexturedDraftName;
            meshDraft.Add(draft);

            // MeshDraft doorFrame = MeshDraft.PartialBox(doorWidth, -doorThickness, doorHeight, Directions.All & ~Directions.ZAxis, generateUV:true)
            //     .Move(doorOrigin + doorWidth/2 + doorHeight/2 + doorThickness/2)
            //     .Paint(entranceTexturedData.m_EntranceDoorColor, entranceTexturedData.m_VertexWallMat);
            // doorFrame.name = k_EntranceDoorDraftName;
            // meshDraft.Add(doorFrame);
            //
            // MeshDraft door = new MeshDraft()
            //     .AddQuad(doorOrigin + doorThickness, doorWidth, doorHeight, entranceTexturedData.m_UVScale, calculateNormal:true, generateUV:true)
            //     .Paint(entranceTexturedData.m_EntranceDoorColor, entranceTexturedData.m_VertexWallMat);
            // door.name = k_EntranceDoorDraftName;
            // meshDraft.Add(door);

            return meshDraft;
        }

        protected static MeshDraft ResidenceEntrance(
            Vector3 origin,
            float width,
            float height,
            EntranceColorData entranceColorData
        )
        {
            Vector3 widthVector = Vector3.right*width;
            Vector3 heightVector = Vector3.up*height;

            Vector3 doorWidth = Vector3.right * (k_EntranceDoorWidth * 0.5f);
            Vector3 doorFrameWidth = Vector3.right * (k_EntranceDoorWidth * 0.02f);
            Vector3 doorHeight = Vector3.up*k_EntranceDoorHeight;
            Vector3 doorFrameHeight = Vector3.up * (k_EntranceDoorHeight * 0.02f);
            Vector3 doorThickness = Vector3.back*k_EntranceDoorThickness;
            Vector3 doorOrigin = origin + widthVector/2 - doorWidth/2;

            MeshDraft draft = EntranceBracket(origin, widthVector, heightVector, doorOrigin, doorWidth, doorHeight)
                .Paint(entranceColorData.m_WallColor, entranceColorData.m_VertexWallMaterial);

            MeshDraft doorLeftFrame = MeshDraft.PartialBox(doorFrameWidth, -doorThickness / 2, doorHeight, Directions.Back | Directions.Right)
                .Move(doorOrigin + doorFrameWidth / 2 + doorHeight / 2 - doorThickness / 4)
                .Paint(entranceColorData.m_EntranceDoorFrameColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(doorLeftFrame);

            MeshDraft doorRightFrame = MeshDraft.PartialBox(doorFrameWidth, -doorThickness / 2, doorHeight, Directions.Back | Directions.Left)
                .Move(doorOrigin + doorWidth - doorFrameWidth / 2 + doorHeight / 2 - doorThickness / 4)
                .Paint(entranceColorData.m_EntranceDoorFrameColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(doorRightFrame);

            MeshDraft doorUpperFrame = MeshDraft.PartialBox(doorWidth - doorFrameWidth * 2, -doorThickness / 2, doorFrameHeight, Directions.Back | Directions.Down)
                .Move(doorOrigin + doorWidth / 2 + doorHeight - doorFrameHeight / 2 - doorThickness / 4)
                .Paint(entranceColorData.m_EntranceDoorFrameColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(doorUpperFrame);

            MeshDraft doorBottomFrame = MeshDraft.PartialBox(doorWidth - doorFrameWidth * 2, -doorThickness / 2, doorFrameHeight, Directions.Back | Directions.Up)
                .Move(doorOrigin + doorWidth /2 + doorFrameHeight / 2 - doorThickness / 4)
                .Paint(entranceColorData.m_EntranceDoorFrameColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(doorBottomFrame);

            MeshDraft door = new MeshDraft().AddQuad(doorOrigin, doorWidth, doorHeight, calculateNormal: true)
                .Move( - doorThickness / 2)
                .Paint(entranceColorData.m_EntranceDoorColor, entranceColorData.m_VertexWallMaterial);
            draft.Add(door);

            if (entranceColorData.m_HasRoof)
            {
                Vector3 depthVector = Vector3.forward*k_EntranceDoorRoofDepth;
                MeshDraft roof = MeshDraft.PartialBox(doorWidth*1.2f, depthVector, Vector3.up*k_EntranceDoorRoofHeight, Directions.All & ~Directions.Forward)
                    .Move(origin + widthVector/2 + doorHeight + doorFrameHeight + Vector3.up*(k_EntranceDoorRoofHeight/2) - depthVector/2)
                    .Paint(entranceColorData.m_EntranceRoofColor);
                draft.Add(roof);
            }

            draft.name = k_WallDraftName;
            return draft;
        }

        protected static CompoundMeshDraft ResidenceEntranceTextured(
            Vector3 origin,
            float width,
            float height,
            EntranceTexturedData entranceTexturedData
        )
        {
            Vector3 widthVector = Vector3.right*width;
            Vector3 heightVector = Vector3.up*height;

            Vector3 doorWidth = Vector3.right * (k_EntranceDoorWidth * 0.5f);
            Vector3 doorFrameWidth = Vector3.right * (k_EntranceDoorWidth * 0.02f);
            Vector3 doorHeight = Vector3.up*k_EntranceDoorHeight;
            Vector3 doorFrameHeight = Vector3.up * (k_EntranceDoorHeight * 0.02f);
            Vector3 doorThickness = Vector3.back*k_EntranceDoorThickness;
            Vector3 doorOrigin = origin + widthVector/2 - doorWidth/2;

            var meshDraft = new CompoundMeshDraft();
            MeshDraft bracket = EntranceBracketTextured(origin, widthVector, heightVector, doorOrigin, doorWidth, doorHeight, entranceTexturedData.m_UVScale)
                .Paint(entranceTexturedData.m_WallMat);
            bracket.name = k_WallTexturedDraftName;
            meshDraft.Add(bracket);

            MeshDraft doorLeftFrame = MeshDraft.PartialBox(doorFrameWidth, -doorThickness / 2, doorHeight, Directions.Back | Directions.Right, generateUV: true)
                .Move(doorOrigin + doorFrameWidth / 2 + doorHeight / 2 - doorThickness / 4)
                .Paint(entranceTexturedData.m_EntranceDoorFrameMat);
            doorLeftFrame.name = k_EntranceDoorFrameTexturedDraftName;
            meshDraft.Add(doorLeftFrame);

            MeshDraft doorRightFrame = MeshDraft.PartialBox(doorFrameWidth, -doorThickness / 2, doorHeight, Directions.Back | Directions.Left, generateUV: true)
                .Move(doorOrigin + doorWidth - doorFrameWidth / 2 + doorHeight / 2 - doorThickness / 4)
                .Paint(entranceTexturedData.m_EntranceDoorFrameMat);
            doorRightFrame.name = k_EntranceDoorFrameTexturedDraftName;
            meshDraft.Add(doorRightFrame);

            MeshDraft doorUpperFrame = MeshDraft.PartialBox(doorWidth - doorFrameWidth * 2, -doorThickness / 2, doorFrameHeight, Directions.Back | Directions.Down, generateUV: true)
                .Move(doorOrigin + doorWidth / 2 + doorHeight - doorFrameHeight / 2 - doorThickness / 4)
                .Paint(entranceTexturedData.m_EntranceDoorFrameMat);
            doorUpperFrame.name = k_EntranceDoorFrameTexturedDraftName;
            meshDraft.Add(doorUpperFrame);

            MeshDraft doorBottomFrame = MeshDraft.PartialBox(doorWidth - doorFrameWidth * 2, -doorThickness / 2, doorFrameHeight, Directions.Back | Directions.Up, generateUV: true)
                .Move(doorOrigin + doorWidth /2 + doorFrameHeight / 2 - doorThickness / 4)
                .Paint(entranceTexturedData.m_EntranceDoorFrameMat);
            doorBottomFrame.name = k_EntranceDoorFrameTexturedDraftName;
            meshDraft.Add(doorBottomFrame);

            MeshDraft door = new MeshDraft().AddQuad(doorOrigin, doorWidth, doorHeight, entranceTexturedData.m_UVScale, calculateNormal: true, generateUV: true)
                .Move( - doorThickness / 2)
                .Paint(entranceTexturedData.m_EntranceDoorMat);
            door.name = k_EntranceDoorTexturedDraftName;
            meshDraft.Add(door);

            if (entranceTexturedData.m_HasRoof)
            {
                Vector3 depthVector = Vector3.forward*k_EntranceDoorRoofDepth;
                MeshDraft roof = MeshDraft.PartialBox(doorWidth*1.2f, depthVector, Vector3.up*k_EntranceDoorRoofHeight, Directions.All & ~Directions.Forward, generateUV: true)
                    .Move(origin + widthVector/2 + doorHeight + doorFrameHeight + Vector3.up*(k_EntranceDoorRoofHeight/2) - depthVector/2)
                    .Paint(entranceTexturedData.m_EntranceDoorRoofMat);
                door.name = k_EntranceDoorRoofTexturedDraftName;
                meshDraft.Add(roof);
            }

            return meshDraft;
        }

        private static MeshDraft EntranceBracket(Vector3 origin, Vector3 width, Vector3 depth, Vector3 innerOrigin, Vector3 innerWidth, Vector3 innerDepth)
        {
            return new MeshDraft().AddTriangleStrip(new List<Vector3>
            {
                innerOrigin,
                origin,
                innerOrigin + innerDepth,
                origin + depth,
                innerOrigin + innerDepth + innerWidth,
                origin + depth + width,
                innerOrigin + innerWidth,
                origin + width
            });
        }

        private static MeshDraft EntranceBracketTextured(Vector3 origin, Vector3 width, Vector3 depth, Vector3 innerOrigin, Vector3 innerWidth, Vector3 innerDepth, Vector2 uvScale)
        {
            return new MeshDraft().AddTriangleStrip(new List<Vector3>
            {
                innerOrigin,
                origin,
                innerOrigin + innerDepth,
                origin + depth,
                innerOrigin + innerDepth + innerWidth,
                origin + depth + width,
                innerOrigin + innerWidth,
                origin + width
            }, new List<Vector2>
            {
                new(innerOrigin.x * uvScale.x, innerOrigin.y * uvScale.y),
                new(origin.x * uvScale.x, origin.y * uvScale.y),
                new((innerOrigin.x + innerDepth.x) * uvScale.x, (innerOrigin.y + innerDepth.y) * uvScale.y),
                new((origin.x + depth.x) * uvScale.x, (origin.y + depth.y) * uvScale.y),
                new((innerOrigin.x + innerDepth.x + innerWidth.x) * uvScale.x, (innerOrigin.y + innerDepth.y + innerWidth.y) * uvScale.y),
                new((origin.x + depth.x + width.x) * uvScale.x, (origin.y + depth.y + width.y) * uvScale.y),
                new((innerOrigin.x + innerWidth.x) * uvScale.x, (innerOrigin.y + innerWidth.y) * uvScale.y),
                new((origin.x + width.x) * uvScale.x, (origin.y + width.y) * uvScale.y)
            });
        }

        protected static MeshDraft EntranceRoofed(Vector3 origin, float width, float height, Color wallColor,
            Color doorColor, Color roofColor)
        {
            // var draft = Entrance(origin, width, height, wallColor, doorColor);
            // Vector3 widthVector = Vector3.right*width;
            // Vector3 depthVector = Vector3.forward*k_EntranceRoofDepth;
            //
            // var roof = MeshDraft.PartialBox(widthVector, depthVector, Vector3.up*k_EntranceRoofHeight, Directions.All & ~Directions.Forward, false)
            //     .Move(origin + widthVector/2 + Vector3.up*(height - k_EntranceRoofHeight/2) - depthVector/2)
            //     .Paint(roofColor);
            // draft.Add(roof);
            MeshDraft draft = new MeshDraft();
            return draft;
        }

        protected static CompoundMeshDraft EntranceWindow(Vector3 origin, float width, float height, Color wallColor,
            Color frameColor, Color glassColor)
        {
            return new CompoundMeshDraft();
            // var compoundDraft = Window(origin, width, height/2, k_EntranceWindowWidthOffset, k_EntranceWindowHeightOffset,
            //     k_EntranceWindowHeightOffset, wallColor, frameColor, glassColor);
            // compoundDraft.Add(Window(origin + Vector3.up*height/2, width, height/2, k_EntranceWindowWidthOffset,
            //     k_EntranceWindowHeightOffset, k_EntranceWindowHeightOffset, wallColor, frameColor, glassColor));
            // return compoundDraft;
        }
    }
}
