﻿using Entra21.BancoDados01.Ado.Net.Models;
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
    public partial class PersonagemCadastroEdicaoForm : Form
    {
        private readonly int _idParaEditar;
        public PersonagemCadastroEdicaoForm()
        {
            InitializeComponent();
            PreencherComboBoxTipoPersonagem();
            PreencherComboBoxEditora();
        }

        public PersonagemCadastroEdicaoForm(Personagem personagem) : this()
        {
            _idParaEditar = personagem.Id;
            textBoxNome.Text = personagem.Nome;

            //Percorrer cada um dos itens do tipo personagem, para selecionar o que o usuário tinha cadastrado anteriormente
            for (int i = 0; i < comboBoxTipoPersonagem.Items.Count; i++)
            {
                var tipoPersonagemPercorrido = comboBoxTipoPersonagem.Items[i] as TipoPersonagem;

                if(tipoPersonagemPercorrido.Id == personagem.TipoPersonagem.Id)
                {
                    comboBoxTipoPersonagem.SelectedItem = tipoPersonagemPercorrido;
                    break;
                }
            }
            //Percorrer cada um dos itens da editora, para selecionar o que o usuario tinha cadastrado
            for (int i = 0; i < comboBoxEditora.Items.Count;i++)
            {
                var editoraPercorrida = comboBoxEditora.Items[i] as Editora;

                if (editoraPercorrida.Id == personagem.Editora.Id)
                {
                    comboBoxEditora.SelectedItem = editoraPercorrida;
                }
            }
        }

        private void PreencherComboBoxEditora()
        {
            //Buscar todas as editoras do banco de dados para permitir o usuário escolher
            var editoraService = new EditoraService();
            var editoras = editoraService.ObterTodos();

            for (int i = 0; i < editoras.Count; i++)
            {
                var editora = editoras[i];
                comboBoxEditora.Items.Add(editora);
            }
        }

        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            if (comboBoxEditora.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma editora");
                return;
            }

            if (comboBoxTipoPersonagem.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione um tipo de personagem");
                return;
            }

            var nome = textBoxNome.Text.Trim();
            var tipoPersonagem = comboBoxTipoPersonagem.SelectedItem as TipoPersonagem;
            var editora = comboBoxEditora.SelectedItem as Editora;

            var personagem = new Personagem();
            personagem.Nome = nome;
            personagem.TipoPersonagem = tipoPersonagem;
            personagem.Editora = editora;

            //Persistir oque o usuário escolheu na tabela de personagens
            var personagemService = new PersonagemService();
            personagemService.Cadastrar(personagem);

            MessageBox.Show("Personagem cadastrado com sucesso!");
            Close();
        }

        private void PreencherComboBoxTipoPersonagem()
        {
            //Buscar todos os tipos de personagens do abnco de dados para permitir o usuario escolher
            var tipoPersonagemService = new TipoPersonagemService();
            var tipoPersonagens = tipoPersonagemService.ObterTodos();

            for (int i = 0; i < tipoPersonagens.Count; i++)
            {
                var tipoPersonagem = tipoPersonagens[i];
                comboBoxTipoPersonagem.Items.Add(tipoPersonagem);
            }
        }

        private void PersonagemCadastroEdicaoForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
