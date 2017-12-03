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
    public partial class FORMeditarcaderno : Form
    {
        public string idCadernoI, loginI, matriculaI, senhaI, matNome;

        //INICIALIZAÇÕES
        public FORMeditarcaderno(string idCaderno, string login, string matricula, string senha)
        {
            InitializeComponent();
            idCadernoI = idCaderno;
            loginI = login;
            matriculaI = matricula;
            senhaI = senha;
            tituloEditar.Text = "EDITAR CADERNO: " + idCaderno;
            PreencherCBmatCont();
            PreencherCBmaterias();
            PreencherCBtitulo();
        }

        //VERIFICAÇÕES
        public bool VerificarMateria(string nome)
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "select count(*) from materia where nome = @nome;";
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Connection.Open();

            if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0)
            {
                cmd.Connection.Close();
                return true;
            }

            else
            {
                cmd.Connection.Close();
                return false;
            }
        }
        public bool VerificarConteudo(string titulo)
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "select count(*) from conteudo where idConteudo = @idConteudo;";
            string id = idCadernoI + titulo;
            cmd.Parameters.AddWithValue("@idConteudo", id);
            cmd.Connection.Open();

            if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0)
            {
                cmd.Connection.Close();
                return true;
            }
            else
            {
                cmd.Connection.Close();
                return false;
            }
        }

        //PREENCHER CB MATERIA EXCLUIR
        public void PreencherCBmaterias()
        {
            MySqlCommand cmd = Conectar();
            MySqlCommand cmd2 = Conectar();
            cmd.CommandText = "SELECT DISTINCT(nome) FROM conteudo WHERE idCaderno = @idCaderno;";
            cmd.Parameters.AddWithValue("@idCaderno", idCadernoI);

            string erro = "";
            try
            {
                CBmateriaEx.Items.Clear();
                erro = "Falha na conexão ao banco (Editar Caderno)";
                cmd.Connection.Open();
                erro = "Falha ao buscar na tabela Caderno";

                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.HasRows)
                {
                    string mat;
                    while (dr.Read())
                    {
                        cmd2.CommandText = "SELECT Count(DISTINCT idCaderno) FROM conteudo WHERE nome = @nome;";
                        mat = dr.GetString(0);

                        cmd2.Parameters.Clear();
                        cmd2.Parameters.AddWithValue("@nome", mat.ToString());

                        cmd2.Connection.Open();
                        int num = Convert.ToInt32(cmd2.ExecuteScalar().ToString());

                        if (num <= 1)
                        {
                            CBmateriaEx.Items.Add(mat);
                        }
                        cmd2.Connection.Close();
                        erro = "Falha ao fechar conexão";
                    }

                    cmd.Connection.Close();
                }
            }
            catch
            {
                MessageBox.Show(erro);
            }
        }
        //PREENCHER CB MATERIA CONTEUDO
        public void PreencherCBmatCont()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT nome FROM materia";

            string erro = "";
            try
            {
                CBmateria.Items.Clear();
                erro = "Falha na conexão ao banco (Preencher Banco Materia Conteudo)";
                cmd.Connection.Open();
                erro = "Falha ao buscar na tabela Caderno";
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    matNome = dr.GetString(0);
                    CBmateria.Items.Add(matNome);

                }

                erro = "Falha ao fechar conexão";
                cmd.Connection.Close();
            }
            catch
            {
                MessageBox.Show(erro);
            }
        }
        //PREENCHER CB TITULO
        public void PreencherCBtitulo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT titulo FROM conteudo WHERE idCaderno = @idCaderno";
            cmd.Parameters.AddWithValue("@idCaderno", idCadernoI);

            string erro = "";
            try
            {
                CBtitulo.Items.Clear();
                erro = "Falha na conexão ao banco (Preencher Banco Titulo Excluir)";
                cmd.Connection.Open();
                erro = "Falha ao buscar na tabela Caderno";
                MySqlDataReader dr = cmd.ExecuteReader();
                string t;

                while (dr.Read())
                {
                    t = dr.GetString(0);
                    CBtitulo.Items.Add(t);
                }

                erro = "Falha ao fechar conexão";
                cmd.Connection.Close();
            }
            catch
            {
                MessageBox.Show(erro);
            }
        }

        //BUSCAR IDCONTEÚDO
        public string BuscarConteudo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT idConteudo FROM conteudo WHERE idCaderno = @idCaderno AND titulo = @titulo;";
            cmd.Parameters.AddWithValue("@idCaderno", idCadernoI);
            cmd.Parameters.AddWithValue("@titulo", CBtitulo.Text);

            string erro = "";
            try
            {
                string i = "";
                erro = "Falha na conexão ao banco (Buscar Conteudo)";
                cmd.Connection.Open();
                erro = "Falha ao buscar na tabela Conteudo";
                MySqlDataReader dr = cmd.ExecuteReader();
                while(dr.Read())
                {
                    i = dr.GetString(0);
                }
                erro = "Falha ao fechar conexão";
                cmd.Connection.Close();

                return i;
            }
            catch
            {
                MessageBox.Show(erro);
                return "";
            }            
        }

        //CONECTAR
        public MySqlCommand Conectar()
        {
            MySqlCommand cmd = new MySqlCommand
            {
                Connection = new MySqlConnection("Server=127.0.0.1;Database=caderno;Uid=root;Pwd=")//Lembrar de alterar PWD: root
            };
            return cmd;
        }

        //PAINEIS E VOLTAR
        private void BTNexcluirConteudo_Click(object sender, EventArgs e)
        {
            PANELaddConteudo.Visible = false;
            PANELexcluirConteudo.Visible = true;
            PANELexcluirMateria.Visible = false;
            PANELaddMateria.Visible = false;

            PreencherCBtitulo();
            PreencherCBmaterias();
            PreencherCBmatCont();
        }
        private void BTNexcluirMateria_Click(object sender, EventArgs e)
        {
            PANELaddConteudo.Visible = false;
            PANELexcluirConteudo.Visible = false;
            PANELexcluirMateria.Visible = true;
            PANELaddMateria.Visible = false;

            PreencherCBtitulo();
            PreencherCBmaterias();
            PreencherCBmatCont();
        }
        private void BTNvoltarIndividual_Click(object sender, EventArgs e)
        {
            FORMindividual formIndividual = new FORMindividual(loginI, matriculaI, senhaI);
            formIndividual.Show();
            this.Close();
        }
        private void BTNcriarMateria_Click(object sender, EventArgs e)
        {
            PANELaddConteudo.Visible = false;
            PANELexcluirConteudo.Visible = false;
            PANELexcluirMateria.Visible = false;
            PANELaddMateria.Visible = true;

            PreencherCBtitulo();
            PreencherCBmaterias();
            PreencherCBmatCont();
        }
        private void BTNadicionarConteudo_Click(object sender, EventArgs e)
        {
            PANELaddConteudo.Visible = true;
            PANELexcluirConteudo.Visible = false;
            PANELexcluirMateria.Visible = false;
            PANELaddMateria.Visible = false;

            PreencherCBtitulo();
            PreencherCBmaterias();
            PreencherCBmatCont();
        }

        //EXCLUIR CONTEÚDO
        private void BTNcontEX_Click(object sender, EventArgs e)
        {
            if (CBtitulo.Text == string.Empty)
                MessageBox.Show("Escolha uma opção");

            else
            {
                string erro = "";
                try
                {
                    string id = BuscarConteudo();

                    MySqlCommand cmd = Conectar();
                    cmd.CommandText = "DELETE FROM conteudo WHERE idConteudo = @idConteudo;";

                    cmd.Parameters.AddWithValue("@idConteudo", id);

                    erro = "Falha na conexão ao banco (Exclusão de aluno)";
                    cmd.Connection.Open();
                    erro = "Falha ao excluir!";
                    cmd.ExecuteNonQuery();
                    erro = "Falha ao fechar conexão";
                    cmd.Connection.Close();                    

                    MessageBox.Show("Conteúdo excluído com sucesso!");
                    CBtitulo.SelectedText = string.Empty;

                    PreencherCBmaterias();
                    PreencherCBtitulo();
                }
                catch
                {
                    MessageBox.Show(erro);
                }
            }
        }        

        //ADD CONTEÚDO
        private void BTNaddConteudo_Click(object sender, EventArgs e)
        {
            if (TXTtituloConteudo.Text == string.Empty || CBmateria.Text == string.Empty || TXTconteudo.Text == string.Empty)
                MessageBox.Show("Preencha todos os campos");

            else
            {
                if (VerificarConteudo(TXTtituloConteudo.Text) == false)
                {
                    MySqlCommand cmd = Conectar();
                    cmd.CommandText = "INSERT INTO conteudo (idConteudo, idCaderno, nome, titulo, conteudo) VALUES (@idConteudo, @idCaderno, @nome, @titulo, @conteudo);";
                    Conteudo c = new Conteudo();

                    c.idConteudo = idCadernoI + TXTtituloConteudo.Text;
                    c.idCaderno = idCadernoI;
                    c.nome = CBmateria.Text;
                    c.titulo = TXTtituloConteudo.Text;
                    c.conteudo = TXTconteudo.Text;

                    cmd.Parameters.AddWithValue("@idConteudo", c.idConteudo);
                    cmd.Parameters.AddWithValue("@idCaderno", c.idCaderno);
                    cmd.Parameters.AddWithValue("@nome", c.nome);
                    cmd.Parameters.AddWithValue("@titulo", c.titulo);
                    cmd.Parameters.AddWithValue("@conteudo", c.conteudo);

                    string erro = "";
                    try
                    {
                        erro = "Falha na conexão ao banco (cadastro conteúdo)";
                        cmd.Connection.Open();
                        erro = "Falha ao cadastrar Conteúdo";
                        cmd.ExecuteNonQuery();
                        erro = "Falha ao fechar conexão";
                        cmd.Connection.Close();
                        
                        MessageBox.Show("Conteúdo cadastrado com sucesso");
                        PreencherCBtitulo();
                        TXTtituloConteudo.Clear();
                        TXTconteudo.Clear();
                    }
                    catch
                    {
                        MessageBox.Show(erro);
                    }
                }

                else
                {
                    MessageBox.Show("Esse Título já existe nesse caderno, tente escolher outro Título");
                    TXTtituloConteudo.Clear();
                }
            }
        }       

        //EXCLUIR MATÉRIA
        private void BTNmateriaEX_Click(object sender, EventArgs e)
        {
            if (CBmateriaEx.Text == string.Empty)
                MessageBox.Show("Escolha uma opção");

            else
            {
                string erro = "";
                try
                {
                    MySqlCommand cmd = Conectar();
                    MySqlCommand cmd2 = Conectar();
                    cmd.CommandText = "DELETE FROM materia WHERE nome = @nome;";
                    cmd.Parameters.AddWithValue("@nome", CBmateriaEx.Text);

                    erro = "Falha na conexão ao banco (Exclusão de aluno)1";
                    cmd.Connection.Open();
                    erro = "Digite a senha e a matrícula correta1!";
                    cmd.ExecuteNonQuery();
                    erro = "Falha ao fechar conexão1";
                    cmd.Connection.Close();

                    cmd2.CommandText = "DELETE FROM conteudo WHERE nome = @nome;";
                    cmd2.Parameters.AddWithValue("@nome", CBmateriaEx.Text);
                    erro = "Falha na conexão ao banco (Exclusão de aluno)2";
                    cmd2.Connection.Open();
                    erro = "Digite a senha e a matrícula correta!2";
                    cmd2.ExecuteNonQuery();
                    erro = "Falha ao fechar conexão2";
                    cmd2.Connection.Close();

                    MessageBox.Show("Matéria excluída com sucesso!");

                    CBmateriaEx.SelectedText = string.Empty;
                    PreencherCBmatCont();
                    PreencherCBmaterias();
                }
                catch
                {
                    MessageBox.Show(erro);
                }
            }
        }        

        //ADD MATÉRIA
        private void BTNaddMat_Click(object sender, EventArgs e)
        {
            if (TXTnomeMateria.Text == string.Empty)
                MessageBox.Show("Preencha o campo Nome da Matéria");
            
            else
            {
                if (VerificarMateria(TXTnomeMateria.Text) == false)
                {
                    MySqlCommand cmd = Conectar();
                    cmd.CommandText = "INSERT INTO materia (idMateria, nome) VALUES (@idMateria, @nome);";
                    Materia m = new Materia();

                    m.idMateria = "ID"+TXTnomeMateria.Text;
                    m.nome = TXTnomeMateria.Text;

                    cmd.Parameters.AddWithValue("@idMateria", m.idMateria);
                    cmd.Parameters.AddWithValue("@nome", m.nome);

                    string erro = "";
                    try
                    {
                        erro = "Falha na conexão ao banco (cadastro matéria)";
                        cmd.Connection.Open();
                        erro = "Falha ao cadastrar matéria";
                        cmd.ExecuteNonQuery();
                        erro = "Falha ao fechar conexão";
                        cmd.Connection.Close();

                        PreencherCBmatCont();
                        PreencherCBmaterias();

                        MessageBox.Show("Matéria cadastrada com sucesso");

                        TXTnomeMateria.Clear();                     
                    }
                    catch
                    {
                        MessageBox.Show(erro);
                    }
                }                        
                else
                {
                    MessageBox.Show("Já existe uma Matéria cadastrada com esse nome");
                    TXTnomeMateria.Clear();
                }
            }
        }
    }
}
