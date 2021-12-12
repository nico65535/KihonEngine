using KihonEngine.GameEngine;
using KihonEngine.GameEngine.GameLogics.Editor;
using KihonEngine.GameEngine.Graphics;
using KihonEngine.GameEngine.Graphics.ModelDefinitions;
using KihonEngine.GameEngine.Graphics.ModelsBuilders;
using KihonEngine.GameEngine.State;
using KihonEngine.Services;
using KihonEngine.Studio.Controls;
using KihonEngine.Studio.Helpers;
using KihonEngine.Studio.Services;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace KihonEngine.Studio.Controls
{
    /// <summary>
    /// Interaction logic for Toolbox3D.xaml
    /// </summary>
    public partial class Toolbox3D : UserControl, ISynchronizedIO
    {
        private ILogService LogService
            => Container.Get<ILogService>();
        private IGameEngineController GameEngineController
            => Container.Get<IGameEngineController>();
        private IGameEngineState State
            => Container.Get<IGameEngineState>();
        private INewModelManager NewModelManager
            => Container.Get<INewModelManager>();

        public Toolbox3D()
        {
            InitializeComponent();
        }

        public void Synchronize(IGameEngineState state)
        {
            if (State.EngineMode == EngineMode.EditorMode)
            {
                btnMode.Content = "Start Play Mode";
            }
            else if (State.EngineMode == EngineMode.PlayMode)
            {
                btnMode.Content = "Start Editor Mode";
            }
            else if (State.EngineMode == EngineMode.Off)
            {
                btnMode.Content = "Restart Editor Mode";
            }

            btnStopGameLogic.IsEnabled = State.EngineMode != EngineMode.Off;
            btnAddCeiling.IsEnabled = State.Editor.ActionNew.Mode != KihonEngine.GameEngine.State.Editor.NewModelMode.Active;
            btnAddFloor.IsEnabled = State.Editor.ActionNew.Mode != KihonEngine.GameEngine.State.Editor.NewModelMode.Active;
            btnAddWall.IsEnabled = State.Editor.ActionNew.Mode != KihonEngine.GameEngine.State.Editor.NewModelMode.Active;
            btnAddVolume.IsEnabled = State.Editor.ActionNew.Mode != KihonEngine.GameEngine.State.Editor.NewModelMode.Active;
            btnAddLight.IsEnabled = State.Editor.ActionNew.Mode != KihonEngine.GameEngine.State.Editor.NewModelMode.Active;
            btnAddSkybox.IsEnabled = State.Editor.ActionNew.Mode != KihonEngine.GameEngine.State.Editor.NewModelMode.Active;
        }

        private void btnFullScreen_Click(object sender, RoutedEventArgs e)
        {
            GameEngineController.SwitchToFullScreen();
        }

        private void btnMode_Click(object sender, RoutedEventArgs e)
        {
            if (State.EngineMode == EngineMode.EditorMode)
            {
                GameEngineController.SwitchToPlayMode();
            }
            else
            {
                GameEngineController.SwitchToEditorMode();
            }
        }

        private void btnStopGameLogic_Click(object sender, RoutedEventArgs e)
        {
            GameEngineController.StopGameLogic();
            GameEngineController.NotifyIOs();
        }

        private void btnAddCeiling_Click(object sender, RoutedEventArgs e)
        {
            NewModelManager.StartAddNewModel(new CeilingDefinition
            {
                Color = Colors.White,
                Position = new System.Windows.Media.Media3D.Point3D(0, 30, 0),
                Metadata = new CeilingMetadata
                {
                    XSize = 10,
                    ZSize = 20,
                    UseBackMaterial = true,
                }
            });
        }

        private void btnAddFloor_Click(object sender, RoutedEventArgs e)
        {
            NewModelManager.StartAddNewModel(new FloorDefinition
            {
                Color = Colors.White,
                Position = new System.Windows.Media.Media3D.Point3D(0, 1, 0),
                Metadata = new FloorMetadata
                {
                    XSize = 10,
                    ZSize = 20,
                    UseBackMaterial = true,
                }
            });
        }

        private void btnAddWall_Click(object sender, RoutedEventArgs e)
        {
            NewModelManager.StartAddNewModel(new WallDefinition
            {
                Color = Colors.White,
                Metadata = new WallMetadata
                {
                    XSize = 10,
                    YSize = 20,
                    UseBackMaterial = true,
                }
            });
        }

        private void btnAddVolume_Click(object sender, RoutedEventArgs e)
        {
            NewModelManager.StartAddNewModel(new VolumeDefinition
            {
                Color = Colors.White,
                Metadata = new VolumeMetadata
                {
                    XSize = 10,
                    YSize = 10,
                    ZSize = 10,
                    UseBackMaterial = false,
                }
            });
        }

        private void btnAddSkybox_Click(object sender, RoutedEventArgs e)
        {
            var ligthModel = State.Graphics.Level.FirstOrDefault(x => x.Type == ModelType.Light);
            var normal = ligthModel != null ? ((LightMetadata)ligthModel.Metadata[ModelType.Light.ToString()]).Direction : new System.Windows.Media.Media3D.Vector3D(-3, -4, -5);
            GameEngineController.AddModelAndNotify(new SkyboxDefinition
            {
                Color = Colors.White,
                Position = new System.Windows.Media.Media3D.Point3D(-5000, -5000, -5000),
                Metadata = new SkyboxMetadata
                {
                    Name = "sky1",
                    Size = 10000,
                    Normal = normal,
                    UseBackMaterial = true,
                }
            });
        }

        private void btnAddLight_Click(object sender, RoutedEventArgs e)
        {
            GameEngineController.AddModelAndNotify(new LightDefinition
            {
                Color = Colors.White,
                Metadata = new LightMetadata
                {
                    Direction = new System.Windows.Media.Media3D.Vector3D(-3, -4, -5)
                }
            });
        }

        private void btnRespawn_Click(object sender, RoutedEventArgs e)
        {
            new CameraPositionService().MovetoRespawnPosition();
        }

        private void btnCameraBack_Click(object sender, RoutedEventArgs e)
        {
            new CameraPositionService().MoveToBack();
        }

        private void btnCameraFace_Click(object sender, RoutedEventArgs e)
        {
            new CameraPositionService().MoveToFront();
        }

        private void btnCameraRightSide_Click(object sender, RoutedEventArgs e)
        {
            new CameraPositionService().MoveToRightSide();
        }

        private void btnCameraLeftSide_Click(object sender, RoutedEventArgs e)
        {
            new CameraPositionService().MoveToLeftSide();
        }
    }
}
