using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace tarea_2ED
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnleerBMP_Click(object sender, EventArgs e)
        {
            var ancho = 0;
            var tamanio = 0;
            var alto = 0;
            short pixel = 0;
            
            openFileDialog1.ShowDialog();
            FileStream archivo = new FileStream(openFileDialog1.FileName, FileMode.Open);
            BinaryReader br = new BinaryReader(archivo);

            br.BaseStream.Seek(0, SeekOrigin.Begin);
            if ("BM" != new string(br.ReadChars(2)))
            { 
            txtLeer.Text = ("Error");
            return;
            }
            br.BaseStream.Seek(18, SeekOrigin.Begin);
            ancho = br.ReadInt32();
            alto = br.ReadInt32();

            br.BaseStream.Seek(2, SeekOrigin.Begin);
            tamanio = br.ReadInt32();

            br.BaseStream.Seek(2, SeekOrigin.Current);
            pixel = br.ReadInt16();

            txtLeer.Text = (" Tamanio: " + tamanio + " Ancho: " + ancho + " Alto: " + alto + " Bits por Pixel: " + pixel);
            
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            txtLeer.Clear();

        }
    }
}
