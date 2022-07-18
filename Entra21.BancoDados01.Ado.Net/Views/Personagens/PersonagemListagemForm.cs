using Entra21.BancoDados01.Ado.Net.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Entra21.BancoDados01.Ado.Net.Views.Personagens
{
    public partial class PersonagemListagemForm : Form
    {
        //DEFININDO COMO READONLY SERÁ PERMITIDA A CRIAÇÃO DA INSTANCIA SOMENTE NO CONSTRUTOR
        private readonly PersonagemService _personagemService;

        //AQUI FICA O CONSTRUTOR, TEM COMO OBEJETIVO CONSTRUIR O OBJETO COM PROPRIEDADES NECESSÁRIAS E EXECUÇÃO DE MÉTODOS 
        //OBRIGATÓRIOS, OU SEJA, NESTE CENÁRIO DESENHAR A TELA E INSTANCIAR O OBJETO DO SERVIÇO
        //QUE PERMITIRÁ GERENCIAR OS DADOS REFERENTE AO PERSONSAGEM 
        public PersonagemListagemForm()
        {
            InitializeComponent();

            _personagemService = new PersonagemService();

            PreencherDataGridViewComPersonagens();
        }

        private void PreencherDataGridViewComPersonagens()
        {
            var personagens = _personagemService.ObterTodos();

            dataGridView1.Rows.Clear();

            for (int i = 0; i < personagens.Count; i++)
            {
                var personagem = personagens[i];

                dataGridView1.Rows.Add(new object[]
                {
                    personagem.Id,
                    personagem.Nome,
                    personagem.TipoPersonagem.Tipo,
                    personagem.Editora.Nome
                });
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PersonagemListagemForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            var personagemForm = new PersonagemCadastroEdicaoForm();
            personagemForm.ShowDialog();

            PreencherDataGridViewComPersonagens();
        }
    }
}
