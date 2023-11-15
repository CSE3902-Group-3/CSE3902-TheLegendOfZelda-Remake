using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace LegendOfZelda
{
    public enum Menu { Start, Item, End, GameOver};
    public class CameraController
    {
        //Menu's are positioned in world coordinates
        public Vector2 HUDLocation { get; private set; } = new Vector2(10000, 1024);
        public Vector2 ItemMenuLocation { get; private set; } = new Vector2(10000, 0);
        public Vector2 StartLocation { get; private set; } = new Vector2(20000, 0);
        public Vector2 EndLocation { get; private set; } = new Vector2(30000, 0);
        public Vector2 GameOverLocation { get; private set; } = new Vector2(40000, 0);

        private float camSpeed = 8;

        public Camera mainCamera;
        public Camera itemMenuCamera;
        public Camera startCamera;
        public Camera endCamera;
        public Camera gameOverCamera;

        private static CameraController instance;

        private List<List<IDrawable>> mainCameraDrawables;
        private List<IDrawable> activeMenuDrawables;

        private Camera activeMenu;
        
        private CameraController()
        {
            mainCamera = new Camera(Vector2.Zero);
            itemMenuCamera = new Camera(HUDLocation);
            startCamera = new Camera(StartLocation);
            endCamera = new Camera(EndLocation);
            gameOverCamera = new Camera(GameOverLocation);

            mainCameraDrawables = new List<List<IDrawable>>();
            activeMenuDrawables = new List<IDrawable>();

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
            activeMenu.DrawAll(activeMenuDrawables, spriteBatch);
        }

        public void SnapCamToRoom(int fromRoomId, int toRoomId, Vector2 roomPos)
        {
            mainCamera.worldPos = roomPos;
        }
        public void PanCamToRoom(int fromRoomId, int toRoomId, Vector2 roomPos, Action onPanComplete = null)
        {
            mainCamera.PanToLocation(roomPos, camSpeed, onPanComplete);
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
                case Menu.GameOver:
                    activeMenu = gameOverCamera;
                    break;
            }
        }

        public void AddDrawablesToMainCamera(List<IDrawable> drawablesList)
        {
            mainCameraDrawables.Insert(0, drawablesList);
        }
        public void AddPersistentDrawablesToMainCamera(List<IDrawable> drawablesList)
        {
            mainCameraDrawables.Insert(mainCameraDrawables.Count, drawablesList);
        }
        public void RemovePersistentDrawablesFromMainCamera()
        {
            mainCameraDrawables.Remove(activeMenuDrawables);
        }
        public void RemoveDrawablesFromMainCamera(List<IDrawable> drawablesList)
        {
            mainCameraDrawables.Remove(drawablesList);
        }
        public void AddDrawablesToActiveMenuCamera(List<IDrawable> drawablesList)
        {
            activeMenuDrawables = drawablesList;
        }
        public void RemoveDrawablesFromActiveMenuCamera()
        {
            activeMenuDrawables = new List<IDrawable>();
        }

        public void Reset()
        {
            mainCamera.worldPos = LevelMaster.CurrentRoomPosition;
            mainCameraDrawables = new List<List<IDrawable>>();
            activeMenu = itemMenuCamera;
        }
    }
}
