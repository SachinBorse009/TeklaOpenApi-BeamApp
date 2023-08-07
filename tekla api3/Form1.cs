using System;
using System.Windows.Forms;
using Tekla.Structures.Model;
using Point = Tekla.Structures.Geometry3d.Point;
using Tekla.Structures.Model.UI;


namespace tekla_api3
{
    public partial class Form1 : Form

    {
        private Position.PlaneEnum planeEnum; // global variable
        private Position.DepthEnum depthEnum;
        private Position.RotationEnum rotationEnum;
        
        public Form1()
        {
            InitializeComponent();
        }
        //private void InsertBeam()
       // {
           
        //}

        private void InsertBeam(object sender, EventArgs e)
        {
            Model model = new Model();
            Picker picker = new Picker();
            if (model.GetConnectionStatus())
            {
                Point startPoint = picker.PickPoint("Select the start point of the beam");
                Point endPoint = picker.PickPoint("Select the end point of the beam");
                //TSG.Point endPoint = new TSG.Point { X = 10000, Y = 6000, Z = 0 };

                Beam mybeam = new Beam(startPoint, endPoint);
                mybeam.Profile.ProfileString = textBox1.Text;
                mybeam.Material.MaterialString = textBox4.Text;
                mybeam.Class = textBox8.Text;
                mybeam.Name= textBox5.Text;

                mybeam.PartNumber.Prefix= textBox2.Text;
                mybeam.PartNumber.StartNumber = Convert.ToInt32(textBox7.Text);

                mybeam.AssemblyNumber.Prefix= textBox3.Text;
                mybeam.AssemblyNumber.StartNumber = Convert.ToInt32(textBox6.Text);

                //onplane
                //mybeam.Position.Depth = Position.DepthEnum.BEHIND;
                mybeam.Position.Depth = UpdateDepth(comboBox2.SelectedIndex);
                //mybeam.Position.Rotation = Position.RotationEnum.TOP;
                mybeam.Position.Plane = UpdatePlane(comboBox1.SelectedIndex);
                mybeam.Position.Rotation = UpdateRotation(comboBox3.SelectedIndex);

                mybeam.Insert();
                model.CommitChanges();

            }

        }

        private Position.PlaneEnum UpdatePlane(int comboBox1)
        {
            switch (comboBox1)
            {
                case 0:
                    return planeEnum = Position.PlaneEnum.LEFT;
                case 1:
                    return planeEnum = Position.PlaneEnum.MIDDLE;
                case 2:
                    return planeEnum = Position.PlaneEnum.RIGHT;
                default:
                    return planeEnum = Position.PlaneEnum.MIDDLE;

            }
        }

        private Position.DepthEnum UpdateDepth(int comboBox2)
        {
            switch(comboBox2)
            {
                case 0:
                    return depthEnum = Position.DepthEnum.MIDDLE;
                case 1:
                    return depthEnum = Position.DepthEnum.FRONT;
                case 2:
                    return depthEnum = Position.DepthEnum.BEHIND;
                default:
                    return depthEnum = Position.DepthEnum.BEHIND;
            }
        }

        private Position.RotationEnum UpdateRotation(int comboBox3)
        {
            switch (comboBox3)
            {
                case 1:
                    return rotationEnum = Position.RotationEnum.BACK;
                case 2:
                    return rotationEnum = Position.RotationEnum.FRONT;
                case 3:
                    return rotationEnum = Position.RotationEnum.BELOW;
                case 4:
                    return rotationEnum = Position.RotationEnum.TOP;
                default:
                    return rotationEnum = Position.RotationEnum.TOP;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
