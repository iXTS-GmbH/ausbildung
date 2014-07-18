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
            try
            {
                ValidateFormat.CheckPointStringFormat(tb_coordinates.Text);
                if (dd_Polygons.SelectedIndex == -1)
                {
                    throw new NoFormExeption("Keine Form Ausgewählt!");
                }
                    var type = dd_Polygons.SelectedItem.ToString();
                    var formname = CreateForm(type, tb_coordinates.Text);//Diese Zeile macht probleme                
                    AddPolygonToListbox(formname);
                    var forms = polygonPrinter.Print(pnl_drawField.Width,pnl_drawField.Height);
                    Draw(forms);

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message,@"Exception");
            }


        }

        private void AddPolygonToListbox(String formname)
        {
          lb_ListofForms.Items.Add(formname);
        }

        private void Draw(Bitmap forms)
        {
            pnl_drawField.BackgroundImage = forms;
        }

        private String CreateForm(string type, string coordinatesText)
        {
            var points = StringToPointsParser.Parse(coordinatesText);
            ValidateFormat.CheckPointCount(points, type);
                if (type == "Triangle")
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
            MovePolygon(0,1);
        }

        private void btn_moveDown_Click(object sender, EventArgs e)
        {
            MovePolygon(0,-1);
        }

        private void btn_moveLeft_Click(object sender, EventArgs e)
        {
            MovePolygon(-1,0);
        }

        private void btn_moveRight_Click(object sender, EventArgs e)
        {
            MovePolygon(1,0);
        }

        private void MovePolygon(double moveX ,double moveY )
        {
            try
            {
                if (lb_ListofForms.SelectedIndex == -1)
                {
                    throw new NoFormExeption("Keine zu bewegende Form ausgewählt!");
                }
                polygonPrinter.MovePolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex], moveX, moveY);
                ReDraw();
            }
            catch (Exception exception)
            {
                
                MessageBox.Show(exception.Message,@"Exception");
            }


        }

        private void btn_zoomPlus_Click(object sender, EventArgs e)
        {
            ZoomPolygon(2);
        }

        private void btn_zoomMinus_Click(object sender, EventArgs e)
        {
            ZoomPolygon(0.5);
        }

        private void ZoomPolygon(double factor)
        {
            try
            {
                if (lb_ListofForms.SelectedIndex == -1)
                {
                    throw new NoFormExeption("Keine zu zoomende Form ausgewählt!");
                }
                polygonPrinter.ZoomPolygon((string)lb_ListofForms.Items[lb_ListofForms.SelectedIndex], factor);
                ReDraw(); 
                }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
    }
}
