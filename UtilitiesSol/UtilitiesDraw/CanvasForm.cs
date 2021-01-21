using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using UtilitiesDraw.BusinessObjects.HouseBuilding;
using UtilitiesDraw.PaintersObjects;



namespace UtilitiesDraw
{



    public partial class CanvasForm : Form
    {



        private bool isDrawingVisible = false;



        public CanvasForm()
        {
            InitializeComponent();
        }



        //private void CanvasForm_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    //Pen pen = new Pen(Color.Black, 1.0f);
        //    Pen pen = new Pen(Color.Black, 2.0f);
        //    g.DrawLine(pen, 0, 0, 100, 100);
        //}



        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (isDrawingVisible)
            {
                //Graphics g = e.Graphics;
                ////Pen pen = new Pen(Color.Black, 1.0f);
                //Pen pen = new Pen(Color.Black, 2.0f);
                //g.DrawLine(pen, 0, 0, 100, 100);
                //pen.Dispose();
                DrawAll(e.Graphics);
            }
        }



        private void buttonShow_Click(object sender, EventArgs e)
        {
            this.isDrawingVisible = true;
            this.panelCanvas.Refresh();
        }



        private void buttonHide_Click(object sender, EventArgs e)
        {
            this.isDrawingVisible = false;
            this.panelCanvas.Refresh();
        }



        private void CanvasForm_Resize(object sender, EventArgs e)
        {
            if (this.isDrawingVisible)
            {
                this.panelCanvas.Refresh();
            }
        }


        private void DrawAll(Graphics g)
        {
            BlockOfFlats block = BlockOfFlats.GetKLadviBlockOfFlats();
            //CanvasContext context = new CanvasContext(0, 0, panelCanvas.Width, panelCanvas.Height);
            CanvasContext context = new CanvasContext(panelCanvas.ClientRectangle.Left, panelCanvas.ClientRectangle.Top, panelCanvas.ClientRectangle.Width, panelCanvas.ClientRectangle.Height);
            block.DrawSelf(g, context);
            //DrawEngine drawEngine = new DrawEngine(block, g, context);
            //drawEngine.DrawAllElements();
            Window window = Window.GetStandardWindow();
            window.DrawSelf(g, context);

            Door door = Door.GetSingleDoor();
            door.DrawSelf(g, context);
            //Window window = Window.GetStandardWindow();
            //CanvasContext context2 = new CanvasContext(0, 0, panelCanvas.Width, panelCanvas.Height);
            //window.DrawSelf(g, context2);

            


            ////Floor floor = Floor.GetGroundFloor();
            //Floor floor = Floor.GetFirstFloor();
            //CanvasContext context = new CanvasContext(panelCanvas.ClientRectangle.Left, panelCanvas.ClientRectangle.Top, panelCanvas.ClientRectangle.Width, panelCanvas.ClientRectangle.Height);
            ////floor.DrawSelf(g, context);
            //DrawEngine drawEngine = new DrawEngine(floor, g, context);
            //drawEngine.DrawAllElements();
        }



    }



}
