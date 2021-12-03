using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MissionPlanner;
using WeifenLuo.WinFormsUI.Docking;
using System.IO;
using FBGroundControl.Forms.utils;
using Microsoft.DirectX;
using Microsoft.DirectX.Direct3D;
using MissionPlanner.Utilities;

namespace FBGroundControl.Forms
{
    public partial class HudFrm : DockContent
    {  
        #region  定义
        Mesh mesh = null;
        bool pause = false;
        private Device device = null;
        Material meshmaterials;
        Texture[] meshtexture;
        private Microsoft.DirectX.Direct3D.Font fonts = null;
        Microsoft.DirectX.Direct3D.Material[] meshmaterials1;
        float angle = 0, viewz = -5500.0f;
        public MissionPlanner.Controls.HUD hud1;
        int position_x, position_y;
        float pitch, yaw, roll = 0;
        float carema_x, carema_y;
        static bool updataFlag = false;
        bool isMouseDown = false;
        Point pointMouse = new Point();
        #endregion

        public HudFrm()
        {

            InitializeComponent();
            this.InitializeHud();
            this.InitializeSolid();
            this.tabPage1.Controls.Add(this.hud1);
        }
        public bool InitializeGraphics()
        {
            try
            {
                PresentParameters presentparams = new PresentParameters();
                presentparams.Windowed = true;//这个是在SolidShowFrm
                //                presentparams.DeviceWindow = tabPage2;//这个是把图画弄到pannal里面
                presentparams.SwapEffect = SwapEffect.Discard;
                presentparams.EnableAutoDepthStencil = true;
                presentparams.AutoDepthStencilFormat = DepthFormat.D16;
                //device = new Device(0, DeviceType.Hardware, tabPage2, CreateFlags.SoftwareVertexProcessing, presentparams);

                //                device.DeviceReset += new System.EventHandler(this.OnResetDevice);
                this.OnCreateDevice(device, null);
                this.OnResetDevice(device, null);
            }
            catch (DirectXException) { return false; }
            return true;
        }

        public void OnCreateDevice(object sender, EventArgs e)
        {
            meshmaterials = new Material();

            ExtendedMaterial[] mtrl = null;

            mesh = Mesh.FromFile(@"..\..\3dx\f16.x", MeshFlags.RtPatches, device, out mtrl);//要载入的.x文件

            if ((mtrl != null) && (mtrl.Length > 0))
            {
                //这两个就是前面定义的全局变量，保存材质和纹理  
                meshmaterials1 = new Material[mtrl.Length];
                meshtexture = new Texture[mtrl.Length];

                for (int i = 0; i < mtrl.Length; ++i)
                {
                    /*当前的temp是Debug下的Model文件， 
                    *Model文件中有保存纹理和材质的文件 
                     */

                    meshmaterials1[i] = mtrl[i].Material3D;
                    meshmaterials1[i].Ambient = meshmaterials1[i].Diffuse;
                    if ((mtrl[i].TextureFilename != null)
                        && mtrl[i].TextureFilename != string.Empty)
                    {
                        meshtexture[i] = TextureLoader.FromFile(device, @"..\..\3dx\p.jpg");
                    }
                }
            }
        }
        public void OnResetDevice(object sender, EventArgs e)
        {
            Device dev = (Device)sender;
            dev.RenderState.Ambient = Color.Blue;           // System.Drawing.Color.Brown;//*****************飞机颜色！！！！！
            dev.RenderState.CullMode = Cull.None;
            dev.RenderState.Lighting = true;
            dev.RenderState.BlendFactor = Color.White;
            dev.RenderState.FogColor = Color.Yellow;


            dev.Lights[0].Type = LightType.Directional;
            dev.Lights[0].Diffuse = Color.Silver;
            //        dev.Lights[0].Direction = new Vector3(0, -1, 1);//设置投光位置
            dev.Lights[0].Update();
            dev.Lights[0].Enabled = true;
            dev.Material = meshmaterials;

        }
        public void Render()
        {
            if ((device == null) || (pause))
            {
                return;
            }
            if (mesh == null)
            {
                return;
            }
            //            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, SystemColors.ControlLight, 10.0f, 0);
            device.Clear(ClearFlags.Target | ClearFlags.ZBuffer, SystemColors.ControlDarkDark, 10.0f, 0);
            SetupMatrices();
            device.BeginScene();
            for (int i = 0; i < meshmaterials1.Length; i++)
            {
                device.Material = meshmaterials1[i];
                device.SetTexture(0, meshtexture[i]);
                mesh.DrawSubset(i);
            }

            device.EndScene();
            device.Present();
        }
        private void SetupMatrices()
        {
            //float itime = System.Environment.TickCount%1000.0f;
            //angle = (float)(2 * Math.PI) * itime / 1000.0f;
            //device.Transform.World = Matrix.RotationY(angle);
            device.Transform.World = Matrix.RotationYawPitchRoll(yaw, pitch, roll);



            //一个摄像机矩阵可有由三个部分组成：摄像机位置、目标位置以及摄像机上下方
            device.Transform.View = Matrix.LookAtLH(new Vector3(carema_x, carema_y, viewz), new Vector3(-position_x * viewz / 200, -position_y * viewz / 200, 0), new Vector3(0, 5, 0));

            //下面的方法参考 http://www.cnblogs.com/markuya/articles/1517348.html
            /*函数名称可以翻译为投影变换，类似透视图
             * 其中参数fovy为y轴上的视角，Aspect为高宽比，zn为近裁面，zf为远裁面。
             * 远近裁面跟viewz相关，就是要处于这两个面之间才能正确显示
             * Y轴的视角：在DirectX的帮助文档中描述fovy为filed of view in y direction。
             * 
             * BV:其实fovy可以理解为焦距哇哈哈，望远镜倍数……
             * */
            device.Transform.Projection = Matrix.PerspectiveFovLH((float)Math.PI / 10, 1.0f, 1.0f, 9000.0f);//设置透视，最后面那个参数好像是最远能看到的距离

        }
        private void Solid_MouseDown(object sender, MouseEventArgs e)
        {
            pointMouse = e.Location;
            isMouseDown = true;

        }

        private void Solid_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {

                yaw += (pointMouse.X - e.Location.X) * 3.14f / 180;
                pointMouse = e.Location;
                Render();

            }
        }

        private void Solid_MouseUp(object sender, MouseEventArgs e)
        {
            isMouseDown = false;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (tabControl1.SelectedTab == tabPage2)//进行tabpage位置判断  
            //{
            //    InitializeGraphics();
            //    Render();
            //}
        }
           private void label1_TextChanged(object sender, EventArgs e)
        {
        
            if (!updataFlag)
            {
                updataFlag = true;
                InitializeGraphics();
            }
          //  yaw = MissionPlanner.CurrentState.yaw_state;//change
            pitch = MissionPlanner.CurrentState.pitch_state;
            roll = MissionPlanner.CurrentState.roll_state;
            Render();
        }

           private void HudFrm_Load(object sender, EventArgs e)
           {

           }
    }
}
