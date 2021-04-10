using Playlist.ObjListaOrdenada;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PlayList_Music
{
    public partial class Form1 : Form
    {
        ListaOrdenada nombre_canciones = new ListaOrdenada();
        ListaOrdenada nombre_ruta = new ListaOrdenada();
        int numeroCancion = 1;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnPausa_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.Ctlcontrols.stop();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            nombre_ruta.eliminar(nombre_ruta.buscarPosicion(numeroCancion).dato);
            lstCanciones.Items.RemoveAt(numeroCancion - 1);
            numeroCancion--;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            if (openfile.ShowDialog() == DialogResult.OK)
            {
                nombre_canciones.insertaOrden(openfile.SafeFileName);
                nombre_ruta.insertaOrden(openfile.FileName);
                lstCanciones.Items.Add(openfile.SafeFileName);
            }
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            numeroCancion--;
            axWindowsMediaPlayer1.URL = nombre_ruta.buscarPosicion(numeroCancion).dato.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            numeroCancion++;
            axWindowsMediaPlayer1.URL = nombre_ruta.buscarPosicion(numeroCancion).dato.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = nombre_ruta.buscarPosicion(numeroCancion).dato.ToString();
            axWindowsMediaPlayer1.Ctlcontrols.play();
        }
    }
}
