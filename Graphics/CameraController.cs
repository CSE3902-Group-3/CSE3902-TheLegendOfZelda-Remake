using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public enum Menu { Start, Item, End};
    public class CameraController
    {
        public Vector2 HUDLocation { get; private set; } = new Vector2(10000, 1024);
        public Vector2 ItemMenuLocation { get; private set; } = new Vector2(10000, 0);
        public Vector2 StartLocation { get; private set; } = new Vector2(20000, 0);
        public Vector2 EndLocation { get; private set; } = new Vector2(30000, 0);
        private float camSpeed = 4;

        public Camera mainCamera;
        public Camera itemMenuCamera;
        public Camera startCamera;
        public Camera endCamera;

        public int roomLookingAt = 0;
        public int roomMovingTo = 0;
        private Action OnPanComplete;

        private static CameraController instance;

        private List<List<IDrawable>> mainCameraDrawables;

        private Camera activeMenu;
        
        private CameraController()
        {
            mainCamera = new Camera(Vector2.Zero);
            itemMenuCamera = new Camera(HUDLocation);
            startCamera = new Camera(StartLocation);
            endCamera = new Camera(EndLocation);

            mainCameraDrawables = new List<List<IDrawable>>();

            roomLookingAt = LevelMaster.CurrentRoom;
            mainCameraDrawables.Add(LevelMaster.Drawables);

            instance = this;

            activeMenu = itemMenuCamera;
        }

        public static CameraController GetInstance()
        {
            if (instance == null)
            {
                instance = new CameraController();
            }
            return instance;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            mainCamera.DrawAll(mainCameraDrawables, spriteBatch);
        }

        public void SnapCamToRoom(int roomId, Vector2 roomPos)
        {
            mainCamera.worldPos = roomPos;

            roomMovingTo = roomId;
            roomLookingAt = roomId;
        }
        public void PanCamToRoom(int roomId, Direction directionMoving, Action onPanComplete = null)
        {

            Vector2 newLocation = DetermineRoomLocation(mainCamera, directionMoving);
            mainCamera.PanToLocation(newLocation, camSpeed, OnMainCameraArrival);

            roomMovingTo = roomId;
            OnPanComplete = onPanComplete;
        }

        public void OpenItemMenu(Action onPanComplete = null)
        {
            itemMenuCamera.PanToLocation(ItemMenuLocation, camSpeed, onPanComplete);
        }

        public void CloseItemMenu(Action onPanComplete = null)
        {
            itemMenuCamera.PanToLocation(HUDLocation, camSpeed, onPanComplete);
        }

        public void ChangeMenu(Menu menu)
        {
            switch (menu)
            {
                case Menu.Start:
                    activeMenu = startCamera;
                    break;
                case Menu.End:
                    activeMenu = endCamera;
                    break;
                case Menu.Item:
                    activeMenu = itemMenuCamera;
                    break;
            }
        }

        private Vector2 DetermineRoomLocation(Camera movingCam, Direction directionMoving)
        {
            Vector2 targetLocation;
            switch (directionMoving)
            {
                case Direction.right:
                    targetLocation = movingCam.worldPos + new Vector2(LevelMaster.RoomWidth, 0);
                    break;
                case Direction.left:
                    targetLocation = movingCam.worldPos + new Vector2(-LevelMaster.RoomWidth, 0);
                    break;
                case Direction.down:
                    targetLocation = movingCam.worldPos + new Vector2(0, LevelMaster.RoomHeight);
                    break;
                case Direction.up:
                    targetLocation = movingCam.worldPos + new Vector2(0, -LevelMaster.RoomHeight);
                    break;
                default:
                    targetLocation = Vector2.Zero;
                    break;
            }
            return targetLocation;
        }

        private void OnMainCameraArrival()
        {
            roomLookingAt = roomMovingTo;

            if (OnPanComplete != null) OnPanComplete();
        }
    }
}
