using Globals;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DotNet_Salon_Manager
{
    public partial class exemplo : Form
    {
        Global connection = new Global();

        public exemplo()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlParameterCollection parameters = new SqlCommand().Parameters;
            string Nome = "João";
            //string ID = 1;

            // Adicionando um parâmetro de exemplo
            parameters.Add(new SqlParameter("@Nome", SqlDbType.NVarChar) { Value = Nome });


            dgvMain.DataSource = connection.CarregaDataTable("dbo.PesquisaUsuario", parameters);
            if (connection.msgRetornoClasse != "OK")
            {
                MessageBox.Show(connection.msgRetornoClasse);
            }
        }
    }
}
