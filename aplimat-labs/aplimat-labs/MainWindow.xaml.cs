using aplimat_labs.Models;
using aplimat_labs.Utilities;
using SharpGL;
using SharpGL.SceneGraph.Primitives;
using SharpGL.SceneGraph.Quadrics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplimat_labs
{

    /// <summary>
    /// Interaction logic for MainWindow.xml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
        }

        private CubeMesh lightCube = new CubeMesh()
        {
            Position = new Vector3(0, 0, 0),
            Mass = 1
        };

        private CubeMesh heavyCube = new CubeMesh()
        {
            Position = new Vector3(15, 0, 0),
            Mass = 3
        };

        private CubeMesh mediumCube = new CubeMesh()
        {
            Position = new Vector3(20, 0, 0),
            Mass = 2
        };
                
        private Vector3 wind = new Vector3(0.06f, 0, 0);
        private Vector3 gravity = new Vector3(0, -0.1f, 0);

        private void OpenGLControl_OpenGLDraw(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {

            OpenGL gl = args.OpenGL;

            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            gl.LoadIdentity();
            gl.Translate(0.0f, 0.0f, -40.0f);

            lightCube.Draw(gl);
            lightCube.ApplyForce(wind);
            lightCube.ApplyForce(gravity);
            if(lightCube.Position.x >=27)
            {
                lightCube.Velocity.x = -1;
            }
            if (lightCube.Position.y <=-15)
            {
                lightCube.Velocity.y = 1;
            }

            mediumCube.Draw(gl);
            mediumCube.ApplyForce(wind);
            mediumCube.ApplyForce(gravity);
            if (mediumCube.Position.x >= 27)
            {
                mediumCube.Velocity.x = -1;
            }
            if (mediumCube.Position.y <= -15)
            {
                mediumCube.Velocity.y = 1;
            }

            heavyCube.Draw(gl);
            heavyCube.ApplyForce(wind);
            heavyCube.ApplyForce(gravity);
            if (heavyCube.Position.x >= 27)
            {
                heavyCube.Velocity.x = -1;
            }
            if (heavyCube.Position.y <= -15)
            {
                heavyCube.Velocity.y = 1;
            }




        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void OpenGLControl_OpenGLInitialized(object sender, SharpGL.SceneGraph.OpenGLEventArgs args)
        {
            OpenGL gl = args.OpenGL;

            gl.Enable(OpenGL.GL_DEPTH_TEST);

            float[] global_ambient = new float[] { 0.5f, 0.5f, 0.5f, 1.0f };
            float[] light0pos = new float[] { 0.0f, 5.0f, 10.0f, 1.0f };
            float[] light0ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };
            float[] light0diffuse = new float[] { 0.3f, 0.3f, 0.3f, 1.0f };
            float[] light0specular = new float[] { 0.8f, 0.8f, 0.8f, 1.0f };

            float[] lmodel_ambient = new float[] { 0.2f, 0.2f, 0.2f, 1.0f };

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, lmodel_ambient);

            gl.LightModel(OpenGL.GL_LIGHT_MODEL_AMBIENT, global_ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_POSITION, light0pos);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_AMBIENT, light0ambient);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_DIFFUSE, light0diffuse);
            gl.Light(OpenGL.GL_LIGHT0, OpenGL.GL_SPECULAR, light0specular);

            gl.Color(0,1,1);

            gl.Enable(OpenGL.GL_LIGHTING);
            gl.Enable(OpenGL.GL_LIGHT0);
            



            gl.ShadeModel(OpenGL.GL_SMOOTH);

        }

        private void OpenGLControl_MouseMove(object sender, MouseEventArgs e)
        {

        }
    }
}
