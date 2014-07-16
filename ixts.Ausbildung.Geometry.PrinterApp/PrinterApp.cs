using System;
using System.Drawing;
using System.Windows.Forms;

namespace ixts.Ausbildung.Geometry.PrinterApp
{
    public partial class PrinterApp : Form
    {
        private PolygonPrinter polygonPrinter = new PolygonPrinter();
        public PrinterApp()
        {
            InitializeComponent();
        }
        
        private void btn_Draw_Click(object sender, EventArgs e)
        {

            var isTriangle = dd_Polygons.SelectedIndex == 0;
            var formname = CreateForm(isTriangle, tb_coordinates.Text);
            AddPolygonToListbox(formname);
            var forms = polygonPrinter.Print(pnl_drawField.Width,pnl_drawField.Height);
            Draw(forms);

        }

        private void AddPolygonToListbox(String formname)
        {
          lb_ListofForms.Items.Add(formname);
        }

        private void Draw(Bitmap forms)
        {
            pnl_drawField.BackgroundImage = forms;
        }

        private String CreateForm(Boolean isTriangle, string coordinatesText)
        {
            var points = StringToPointsParser.Parse(coordinatesText);
            if (isTriangle)
            {
                return polygonPrinter.Create(points[0],points[1],points[2]);
            }
            return polygonPrinter.Create(points[0], points[1], points[2], points[3]);
        }

        private void btn_Erase_Click(object sender, EventArgs e)
        {
            ClearField();
            polygonPrinter.Clear();
            lb_ListofForms.Items.Clear();
            tb_coordinates.Text = "";
        }

        private void ClearField()
        {
            Graphics g = pnl_drawField.CreateGraphics();
            SolidBrush sb = new SolidBrush(Color.White);
            g.FillRectangle(sb,0,0,pnl_drawField.Width,pnl_drawField.Height);
        }

        private void ReDraw()
        {
            var forms = polygonPrinter.Print(pnl_drawField.Width,pnl_drawField.Height);
            Draw(forms);
        }

        private void btn_moveUp_Click(object sender, EventArgs e)
        {
            polygonPrinter.MovePolygon((string) lb_ListofForms.Items[lb_ListofForms.SelectedIndex],0,1);
            ReDraw();
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            polygonPrinter.MovePolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex], 0, -1);
            ReDraw();
        }

        private void btn_moveLeft_Click(object sender, EventArgs e)
        {
            polygonPrinter.MovePolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex], -1, 0);
            ReDraw();
        }

        private void btn_moveRight_Click(object sender, EventArgs e)
        {
            polygonPrinter.MovePolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex], 1, 0);
            ReDraw();
        }

        private void btn_zoomPlus_Click(object sender, EventArgs e)
        {
            polygonPrinter.ZoomPolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex],2);
            ReDraw();
        }

        private void btn_zoomMinus_Click(object sender, EventArgs e)
        {
            polygonPrinter.ZoomPolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex], 0.5);
            ReDraw();
        }
    }
}
