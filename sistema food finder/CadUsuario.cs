using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace sistema_food_finder
{
    public partial class CadUsuario : Form
    {
        public CadUsuario()
        {
            InitializeComponent();
        }

        private void CadUsuario_Load(object sender, EventArgs e)
        {

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.ShowDialog();
        }


        private bool ValidarCpf(string cpf)
        {
            // Remove qualquer caractere não numérico
            cpf = Regex.Replace(cpf, @"[^\d]", "");

            // Verifica se tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se o CPF é uma sequência de números iguais (ex.: 111.111.111-11)
            if (new string(cpf[0], 11) == cpf)
                return false;

            // Calculando o primeiro dígito verificador
            int soma = 0;
            int peso = 10;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * peso--;
            }

            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;
            if (digito1 != int.Parse(cpf[9].ToString()))
                return false;

            // Calculando o segundo dígito verificador
            soma = 0;
            peso = 11;
            for (int i = 0; i < 10; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * peso--;
            }

            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;
            return digito2 == int.Parse(cpf[10].ToString());
        }


        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            //Menu form = new Menu();
            //form.ShowDialog();

            string cpf = maskedTextBoxCPF.Text;

            if (ValidarCpf(cpf))
            {
                labelAlert.Text = "CPF VALIDO";
                labelAlert.ForeColor = Color.Green;
            }
            else
            {
                labelAlert.Text = "CPF INVALIDO";
                labelAlert.ForeColor = Color.Red;
                maskedTextBoxCPF.Text = "";
                maskedTextBoxCPF.Focus();

            }

            //Defina a sua string de conexão com o banco

            string conexaoString = "Server=localhost; Port=3306; Database=db_damaju; Uid=root; Pwd=;";

            //Variavel que vai definir inserção de registro do banco 

            string query = "INSERT INTO tb_clientes (nome, senha, email, cep, cpf, numero, telefone) VALUES " +
                "(@nome, @senha, @email, @cep, @cpf, @numero, @telefone)";

            //criando uma conexão com o banco 

            using (MySqlConnection conexao = new MySqlConnection(conexaoString))
            {

                try
                {
                    //Abre a conexão 
                    conexao.Open();
                    //adicinar os parametros com os valores dos textBox
                    using (MySqlCommand comando = new MySqlCommand(query, conexao))
                    {
                        comando.Parameters.AddWithValue("@nome", textBoxNomeCompleto.Text);
                        comando.Parameters.AddWithValue("@senha", textBoxSenha.Text);
                        comando.Parameters.AddWithValue("@email", textBoxEmail.Text);
                        comando.Parameters.AddWithValue("@cep", maskedTextBoxCEP.Text);
                        comando.Parameters.AddWithValue("@cpf", maskedTextBoxCPF.Text);
                        comando.Parameters.AddWithValue("@numero", textBoxNumero.Text);
                        comando.Parameters.AddWithValue("@telefone", maskedTextBoxTelefone.Text);

                        //Executa o comando de inserção

                        comando.ExecuteNonQuery();
                        MessageBox.Show("Dados inseridos com sucesso!");

                        textBoxNomeCompleto.Text = "";
                        textBoxSenha.Text = "";
                        textBoxEmail.Text = "";
                        maskedTextBoxCEP.Text = "";
                        maskedTextBoxCPF.Text = "";
                        textBoxNumero.Text = "";
                        maskedTextBoxTelefone.Text = "";
                        textBoxNomeCompleto.Focus();
                    }
                    //testedsgh

                }
                catch (Exception ex)
                {
                    //em caso de erro, exiba mensagem do erro 
                    MessageBox.Show("Erro: " + ex.Message);
                }
            }
        }
    }
}
