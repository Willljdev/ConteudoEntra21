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

namespace Entra21.BancoDados01.Ado.Net.Views.TiposPersonagens
{
    
    public partial class TipoPersonagemListaForm : Form
    {
        private TipoPersonagemService tipoPersonagemService;
        
        public TipoPersonagemListaForm()
        {
            InitializeComponent();

            // Instanciado objeto da classe TipoPersonagemService para permitir:
            // - Listar todos
            // - Editar
            // - Apagar
            tipoPersonagemService = new TipoPersonagemService();
        }


        private void TipoPersonagemListagemForm_Load(object sender, EventArgs e)
        {
            
        }

        private void TipoPersonagemListaForm_Load(object sender, EventArgs e)
        {
            // Obter todos os tipos de personagens cadastrados na tabela 
            // tipos_personagens
            var tiposPersonagens = tipoPersonagemService.ObterTodos();

            // removido todos os registros do dataGridView1
            dataGridView1.Rows.Clear();

            // Percorrido todos os tipos de personagens encontrados para 
            // adicionar no DataGridView permitindo o usuário visualiza-los
            for (int i = 0; i < tiposPersonagens.Count; i++)
            {
                var tipoPersonagem = tiposPersonagens[i];

                dataGridView1.Rows.Add(new object[]
                {
                    tipoPersonagem.Id,
                    tipoPersonagem.Tipo
                });

            }
        }
    }
}
