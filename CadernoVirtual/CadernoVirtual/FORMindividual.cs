using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadernoVirtual
{
    public partial class FORMindividual : Form
    {

        public string matriculaAntiga, usuarioAntigo, cadernoId, turma, idCaderno, nomeMateria, senhaAntiga, idc, tituloc;

        //INICIALIZAÇÕES
        public FORMindividual(string login, string matricula, string senha)
        {
            InitializeComponent();
            matriculaAntiga = matricula;
            usuarioAntigo = login;
            senhaAntiga = senha;
            tituloApresentacao.Text = ("Bem vindo, "+ login);
            LBLuser.Text = ("Usuário: " + login);
            LBLmat.Text = ("Matricula: " + matricula);

            TXTmatriculaEditar.Text = matriculaAntiga; 

            PreencherCBs();
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

        // PREENCHER GRID
        public void PreencherLista(List<Conteudo> Conteudos)
        {
            ListViewItem item;
            foreach (Conteudo c in Conteudos)
            {
                item = new ListViewItem(c.idCaderno);
                item.SubItems.Add(c.nome);
                item.SubItems.Add(c.titulo);
                LISTA.Items.Add(item);
            }
        }
        //TUDO
        public void  BuscarTudo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo ORDER BY titulo ASC;";

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR TÍTULO
        public void BuscarTitulo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE titulo LIKE (@titulo) ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@titulo", TXTtituloBusca.Text + "%");

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR MATÉRIA
        public void BuscarMateria()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE nome = @nome ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@nome", CBmateria.Text);

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR CADERNO
        public void BuscarCaderno()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE idCaderno = @idCaderno ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@idCaderno", CBidCaderno.Text);

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR CADERNO E MATÉRIA
        public void BuscarCadernoMateria()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE idCaderno = @idCaderno AND nome = @nome ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@idCaderno", CBidCaderno.Text);
            cmd.Parameters.AddWithValue("@nome", CBmateria.Text);

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR CADERNO E TÍTULO
        public void BuscarCadernoTitulo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE idCaderno = @idCaderno AND titulo LIKE (@titulo) ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@idCaderno", CBidCaderno.Text);
            cmd.Parameters.AddWithValue("@titulo", TXTtituloBusca.Text + "%");

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR MATÉRIA E TÍTULO
        public void BuscarMateriaTitulo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE nome = @nome AND titulo LIKE (@titulo) ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@nome", CBmateria.Text);
            cmd.Parameters.AddWithValue("@titulo", TXTtituloBusca.Text + "%");

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }
        //POR TUDO
        public void BuscarCadernoMateriaTitulo()
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM conteudo WHERE nome = @nome AND idCaderno = @idCaderno AND titulo LIKE (@titulo) ORDER BY titulo ASC;";
            cmd.Parameters.AddWithValue("@nome", CBmateria.Text);
            cmd.Parameters.AddWithValue("@idCaderno", CBidCaderno.Text);
            cmd.Parameters.AddWithValue("@titulo", TXTtituloBusca.Text + "%");

            LISTA.Items.Clear();

            cmd.Connection.Open();
            MySqlDataReader dr;
            dr = cmd.ExecuteReader();

            List<Conteudo> Conteudos = new List<Conteudo>();

            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    Conteudo c = new Conteudo();
                    c.idConteudo = dr.GetString(0);
                    c.idCaderno = dr.GetString(1);
                    c.nome = dr.GetString(2);
                    c.titulo = dr.GetString(3);
                    c.conteudo = dr.GetString(4);
                    Conteudos.Add(c);
                }
            }
            PreencherLista(Conteudos);
            cmd.Connection.Close();
        }

        //PREENCHER CB TURMA/ANO E CB MATERIA
        public void PreencherCBs()
        {
            //CB TURMA/ANO
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT idCaderno FROM caderno";

            string erro = "";
            try
            {
                CBidCaderno.Items.Clear();
                erro = "Falha na conexão ao banco (Editar Caderno)";
                cmd.Connection.Open();
                erro = "Falha ao buscar na tabela Caderno";
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    idCaderno = dr.GetString(0);
                    CBidCaderno.Items.Add(idCaderno);

                }

                erro = "Falha ao fechar conexão";
                cmd.Connection.Close();
            }
            catch
            {
                MessageBox.Show(erro);
            }

            //CB MATERIAS
            cmd.CommandText = "SELECT DISTINCT(nome) FROM materia";

            erro = "";
            try
            {
                CBmateria.Items.Clear();
                erro = "Falha na conexão ao banco (Editar Caderno)";
                cmd.Connection.Open();
                erro = "Falha ao buscar na tabela Caderno";
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    nomeMateria = dr.GetString(0);
                    CBmateria.Items.Add(nomeMateria);
                }

                erro = "Falha ao fechar conexão";
                cmd.Connection.Close();
            }
            catch
            {
                MessageBox.Show(erro);
            }


        }

        //VERIFICAR NO BANCO
        public bool VerificarUsuario(string usuario)
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "select count(*) from Aluno where usuario = @usuario;";
            cmd.Parameters.AddWithValue("@usuario", usuario);
            cmd.Connection.Open();

            if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0)
            {
                cmd.Connection.Close();
                if (usuario == usuarioAntigo)
                    return false;

                else
                    return true;
            }
            else
            {
                cmd.Connection.Close();
                return false;
            }
        }
        public bool VerificarMatricula(string matricula)
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "select count(*) from Aluno where matricula = @matricula;";
            cmd.Parameters.AddWithValue("@matricula", matricula);
            cmd.Connection.Open();

            if (Convert.ToInt32(cmd.ExecuteScalar().ToString()) > 0)
            {
                cmd.Connection.Close();
                if (matricula == matriculaAntiga)
                    return false;

                else
                    return true;
            }
            else
            {
                cmd.Connection.Close();
                return false;
            }

        }
        public bool VerificarCaderno(string idCaderno)
        {
            MySqlCommand cmd = Conectar();

            cmd.CommandText = "select count(*) from caderno where idCaderno = @idCaderno;";
            cmd.Parameters.AddWithValue("@idCaderno", idCaderno);
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
        
        //BOTÃO DESCONECTAR, VOLTAR PRA PÁGINA INICIAL
        private void BTNsairusuario_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //BOTÕES QUE ABREM PAINEIS
        private void BTNcriarCaderno_Click(object sender, EventArgs e)
        {
            PANELcriarCaderno.Visible = true;
            PANELeditarCaderno.Visible = false;
            TXTturma.Clear();
            TXTano.Clear();
            TXTsenhaTurma.Clear();
            TXTconfirmarsenhaTurma.Clear();
        }
        private void BTNexcluirUsuario_Click(object sender, EventArgs e)
        {
            PANELexcluirAluno.Visible = true;
            PANELperfil.Visible = false;
            PANELeditarAluno.Visible = false;
            TXTmatExcluir.Text = matriculaAntiga;
        }
        private void BTNperfil_Click(object sender, EventArgs e)
        {
            PANELexcluirAluno.Visible = false;
            PANELperfil.Visible = true;
            PANELeditarAluno.Visible = false;
        }        
        private void BTNeditarUsuario_Click(object sender, EventArgs e)
        {
            PANELexcluirAluno.Visible = false;
            PANELperfil.Visible = false;
            PANELeditarAluno.Visible = true;
        }
        private void BTNvoltar_Click(object sender, EventArgs e)
        {
            PANELeditarCaderno.Visible = true;
            PANELcriarCaderno.Visible = false;
            TXTturma.Clear();
            TXTsenhaTurma.Clear();
        }
        
        //FILTROS
        private void BTNtudo_Click(object sender, EventArgs e)
        {
            LISTA.Items.Clear();
            BuscarTudo();
        }
        private void BTNbuscar_Click(object sender, EventArgs e)
        {
            if (CBidCaderno.Text == string.Empty && CBmateria.Text == string.Empty && TXTtituloBusca.Text == string.Empty)
            {
                LISTA.Items.Clear();
                BuscarTudo();
            }
            else if (CBidCaderno.Text == string.Empty && CBmateria.Text == string.Empty && TXTtituloBusca.Text != string.Empty)
            {
                LISTA.Items.Clear();
                BuscarTitulo();
            }
            else if (CBidCaderno.Text == string.Empty && CBmateria.Text != string.Empty && TXTtituloBusca.Text == string.Empty)
            {
                LISTA.Items.Clear();
                BuscarMateria();
            }
            else if (CBidCaderno.Text != string.Empty && CBmateria.Text == string.Empty && TXTtituloBusca.Text == string.Empty)
            {
                LISTA.Items.Clear();
                BuscarCaderno();
            }
            else if (CBidCaderno.Text != string.Empty && CBmateria.Text != string.Empty && TXTtituloBusca.Text == string.Empty)
            {
                LISTA.Items.Clear();
                BuscarCadernoMateria();
            }
            else if (CBidCaderno.Text != string.Empty && CBmateria.Text == string.Empty && TXTtituloBusca.Text != string.Empty)
            {
                LISTA.Items.Clear();
                BuscarCadernoTitulo();
            }
            else if (CBidCaderno.Text == string.Empty && CBmateria.Text != string.Empty && TXTtituloBusca.Text != string.Empty)
            {
                LISTA.Items.Clear();
                BuscarMateriaTitulo();
            }
            else if (CBidCaderno.Text != string.Empty && CBmateria.Text != string.Empty && TXTtituloBusca.Text != string.Empty)
            {
                LISTA.Items.Clear();
                BuscarCadernoMateriaTitulo();
            }
        }
        private void BTNlimpar_Click(object sender, EventArgs e)
        {
            TXTtituloBusca.Text = string.Empty;
            CBmateria.SelectedItem = null;
            CBidCaderno.SelectedItem = null;
        }

        //ABRIR CONTEÚDO
        private void BTNabrirConteudo_Click(object sender, EventArgs e)
        {
            if (TXTconteudo.Text == string.Empty)
                MessageBox.Show("Primeiro selecione um Conteúdo!");
            else
            {
                FORMconteudo formC = new FORMconteudo(idc, tituloc);
                formC.Show();              
            }            
        }        

        //SELEÇÃO
        private void LISTA_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView lista = (ListView)sender;
            if (lista.SelectedItems.Count > 0)
            {
                TXTconteudo.Text = (lista.SelectedItems[0].SubItems[0].Text) + "/" + (lista.SelectedItems[0].SubItems[1].Text) + "/" + (lista.SelectedItems[0].SubItems[2].Text);
                idc = lista.SelectedItems[0].SubItems[0].Text;
                tituloc = lista.SelectedItems[0].SubItems[2].Text;
            }                
        }        

        //EDITAR ALUNO
        private void BTNconfirmarEdicao_Click(object sender, EventArgs e)
        {
            if (TXTmatriculaEditar.Text == string.Empty || TXTusuarioEditar.Text == string.Empty || TXTsenhaEditar.Text == string.Empty || TXTconfirmarsenhaEditar.Text == string.Empty)
                MessageBox.Show("Preencha todos os campos");
            else if (TXTsenhaEditar.Text != TXTconfirmarsenhaEditar.Text)
                MessageBox.Show("As senhas estão diferentes, digite a mesma senha no campo 'SENHA' e no campo 'CONFIRMAR SENHA'");

            else
            {
                if (VerificarUsuario(TXTusuarioEditar.Text) == false)
                {
                    MySqlCommand cmd = Conectar();
                    cmd.CommandText = "UPDATE aluno SET matricula = @matricula, usuario = @usuario, senha = @senha WHERE matricula = @matriculaAntes;";

                    Aluno a = new Aluno();
                    a.matricula = TXTmatriculaEditar.Text;
                    a.usuario = TXTusuarioEditar.Text;
                    a.senha = TXTsenhaEditar.Text;

                    cmd.Parameters.AddWithValue("@matriculaAntes", matriculaAntiga.ToString());
                    cmd.Parameters.AddWithValue("@matricula", a.matricula);
                    cmd.Parameters.AddWithValue("@usuario", a.usuario);
                    cmd.Parameters.AddWithValue("@senha", a.senha);

                    string erro = "";
                    try
                    {
                        erro = "Falha na conexão ao banco (Edição de aluno)";
                        cmd.Connection.Open();
                        erro = "Falha ao editar aluno";
                        cmd.ExecuteNonQuery();
                        erro = "Falha ao fechar conexão";
                        cmd.Connection.Close();

                        tituloApresentacao.Text = ("Bem vindo, " + a.usuario);
                        LBLuser.Text = ("Usuário: " + a.usuario);
                        LBLmat.Text = ("Matricula: " + a.matricula);

                        usuarioAntigo = TXTusuarioEditar.Text;
                        senhaAntiga = TXTsenhaEditar.Text;

                        MessageBox.Show("Aluno editado com sucesso");
                        TXTusuarioEditar.Clear();
                        TXTsenhaEditar.Clear();
                        TXTconfirmarsenhaEditar.Clear();
                        PANELeditarAluno.Visible = false;
                        PANELperfil.Visible = true;
                    }
                    catch
                    {
                        MessageBox.Show(erro);
                    }

                }
                else
                {
                    MessageBox.Show("Este usuário já existe, digite outro");
                    TXTusuarioEditar.Clear();
                }
            }
        }

        //EXCLUIR ALUNO
        private void BTNconfirmarExclur_Click(object sender, EventArgs e)
        {
            if (TXTmatExcluir.Text == string.Empty || TXTsenhaExcluir.Text == string.Empty)
                MessageBox.Show("Preencha todos os campos corretamente");

            else 
            {
                string erro = "";
                try
                {
                    if(TXTsenhaExcluir.Text == senhaAntiga)
                    {
                        MySqlCommand cmd = Conectar();
                        cmd.CommandText = "DELETE FROM aluno WHERE matricula = @matricula AND senha = @senha;";
                        cmd.Parameters.AddWithValue("@matricula", TXTmatExcluir.Text);
                        cmd.Parameters.AddWithValue("@senha", TXTsenhaExcluir.Text);

                        erro = "Falha na conexão ao banco (Exclusão de aluno)";
                        cmd.Connection.Open();
                        erro = "Digite a senha e a matrícula correta!";
                        cmd.ExecuteNonQuery();
                        erro = "Falha ao fechar conexão";
                        cmd.Connection.Close();

                        MessageBox.Show("Aluno excluído com sucesso!");
                        TXTmatExcluir.Clear();
                        TXTsenhaExcluir.Clear();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Senha incorreta!");
                    }                                        
                }
                catch
                {
                    MessageBox.Show(erro);
                }                
            }
        } 

        //EDITAR CADERNO
        private void BTNeditarCaderno_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = Conectar();
            cmd.CommandText = "SELECT * FROM caderno WHERE turma = @turma AND ano = @ano AND senha = @senha;";
            cmd.Parameters.AddWithValue("@turma", TXTturmaCaderno.Text);
            cmd.Parameters.AddWithValue("@ano", TXTanoCaderno.Text);
            cmd.Parameters.AddWithValue("@senha", TXTsenhaCaderno.Text); 

            string erro = "";
            try
            {
                erro = "Falha na conexão ao banco (Editar Caderno)";
                cmd.Connection.Open();
                erro = "Falha ao buscar caderno";
                MySqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    Caderno c = new Caderno();
                    c.idCaderno = dr.GetString(0);
                    c.turma = dr.GetString(1);
                    c.ano = dr.GetString(2);
                    c.senha = dr.GetString(3);

                    idCaderno = dr.GetString(0);

                    FORMeditarcaderno editarCaderno = new FORMeditarcaderno(idCaderno, usuarioAntigo, matriculaAntiga, senhaAntiga);
                    TXTturmaCaderno.Clear();
                    TXTanoCaderno.Clear();
                    TXTsenhaCaderno.Clear();
                    editarCaderno.Show();
                    this.Close();
                }
                else
                {
                    if (TXTturmaCaderno.Text == string.Empty || TXTanoCaderno.Text == string.Empty || TXTsenhaCaderno.Text == string.Empty)
                        MessageBox.Show("Preencha todos os campos corretamente, verifique se não deixou algum dos campos vazio");

                    else
                        MessageBox.Show("Turma, ano ou senha incorretos");
                }

                erro = "Falha ao fechar conexão";
                cmd.Connection.Close();
            }
            catch
            {
                MessageBox.Show(erro);
            }
        }        

        //CRIAR CADERNO TURMA
        private void BTNcriarturma_Click(object sender, EventArgs e)
        {
            if (TXTturma.Text == string.Empty || TXTano.Text == string.Empty || TXTsenhaTurma.Text == string.Empty || TXTconfirmarsenhaTurma.Text == string.Empty)
                MessageBox.Show("Preencha todos os campos");

            else if (TXTsenhaTurma.Text != TXTconfirmarsenhaTurma.Text)
                MessageBox.Show("As senhas estão diferentes, digite a mesma senha no campo 'SENHA' e no campo 'CONFIRMAR SENHA'");

            else
            {
                cadernoId = TXTturma.Text + "/" + TXTano.Text;
                if (VerificarCaderno(cadernoId) == false)
                {
                    MySqlCommand cmd = Conectar();
                    cmd.CommandText = "INSERT INTO caderno (idCaderno, turma, ano, senha) VALUES (@id, @turma, @ano, @senha);";

                    Caderno c = new Caderno();

                    c.idCaderno = cadernoId;
                    c.turma = TXTturma.Text;
                    c.ano = TXTano.Text;
                    c.senha = TXTsenhaTurma.Text;

                    cmd.Parameters.AddWithValue("@id", c.idCaderno);
                    cmd.Parameters.AddWithValue("@turma", c.turma);
                    cmd.Parameters.AddWithValue("@ano", c.ano);
                    cmd.Parameters.AddWithValue("@senha", c.senha);

                    string erro = "";
                    try
                    {
                        erro = "Falha na conexão ao banco (cadastro caderno)";
                        cmd.Connection.Open();
                        erro = "Falha ao cadastrar caderno";
                        cmd.ExecuteNonQuery();
                        erro = "Falha ao fechar conexão";
                        cmd.Connection.Close();

                        MessageBox.Show("Caderno cadastrado com sucesso");
                        PreencherCBs();
                        TXTturma.Clear();
                        TXTano.Clear();
                        TXTsenhaTurma.Clear();
                        TXTconfirmarsenhaTurma.Clear();
                        PANELcriarCaderno.Visible = false;
                        PANELeditarCaderno.Visible = true;
                    }
                    catch
                    {
                        MessageBox.Show(erro);
                    }

                }
                else
                {
                    MessageBox.Show("Essa turma desse ano já existe, digite outra turma ou outro ano");
                    TXTturma.Clear();
                    TXTano.Clear();
                }

            }
        }
    }
}
