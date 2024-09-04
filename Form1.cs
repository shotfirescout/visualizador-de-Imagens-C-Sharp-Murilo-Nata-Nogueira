using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visualizador_de_Imagens__C_Sharp_
{
    public partial class Form1 : Form
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private Bitmap imageBitmap;
        private String localArquivo;
        public Form1()
        {
            InitializeComponent();
            configurarFileDialog();
        }

        private void btnCarregar_Click(object sender, EventArgs e)
        {
            abrirArquivo();
        }

        private void configurarFileDialog()
        {
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures); //Essa é o diretório que vai começar
            openFileDialog.Filter = "Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF"; //Esse é um filto para usar
            openFileDialog.FilterIndex = 2;
            openFileDialog.RestoreDirectory = true;
        }

        private void abrirArquivo()
        {
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    localArquivo = openFileDialog.FileName;
                    imageBitmap = new Bitmap(localArquivo);
                    imagemSelecionada.Image = imageBitmap;

                } catch(FileLoadException e)
                {
                    MessageBox.Show("Arquivo não encontrado");
                }
                
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            if (imagemSelecionada != null)
            {
                imagemSelecionada.Image.Dispose();
                imagemSelecionada.Image = null;
            } else
            {
                MessageBox.Show("A imagem não foi selecionada ainda");
            }

        }
    }
}
