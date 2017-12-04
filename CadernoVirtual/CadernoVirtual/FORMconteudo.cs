using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CadernoVirtual
{
    public partial class FORMconteudo : Form
    {
        public FORMconteudo(string idc, string tituloc)
        {
            InitializeComponent();

            MySqlCommand cmd = Conectar();

            cmd.CommandText = "SELECT conteudo FROM conteudo WHERE idCaderno = @idCaderno AND titulo = @titulo;";
            cmd.Parameters.AddWithValue("@idCaderno", idc);
            cmd.Parameters.AddWithValue("@titulo", tituloc);

            string erro = "";
            try
            {
                erro = "Erro ao abrir conexão";
                cmd.Connection.Open();
                erro = "Erro ao buscar conteúdo";

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {                    
                    txtC.Text = "" + dr.GetValue(0).ToString();
                    txtC.SelectionStart = 0;
                    txtC.SelectionLength = 0;
                }

                erro = "Erro ao fechar conexão";
                cmd.Connection.Close();
            }
            catch
            {
                MessageBox.Show(erro);
                this.Close();
            }
            
        }

        //CONECTAR
        public MySqlCommand Conectar()
        {
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = new MySqlConnection("Server=127.0.0.1;Database=caderno;Uid=root;Pwd=root")//Lembrar de alterar PWD: root
            };
            return cmd;
        }
    }
}
