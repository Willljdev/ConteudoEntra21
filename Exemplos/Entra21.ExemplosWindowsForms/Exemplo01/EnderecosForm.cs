using Newtonsoft.Json;

namespace Entra21.ExemplosWindowsForms.Exemplo01
{
    public partial class EnderecosForm : Form
    {
        private EnderecoServico enderecoServico;
        private PacienteServico pacienteServico;

        // Construtor: Tem como objetivo construir o objeto que está sendo
        // instanciado com as devidas informações ou rotinas
        public EnderecosForm()
        {
            InitializeComponent();

            enderecoServico = new EnderecoServico();

            // Instanciado o objeto de PacienteServico o que permitirá listar os pacientes
            // no ComboBox e decorrente disso será possível o usuário selecionar o mesmo
            pacienteServico = new PacienteServico();

            // Irá apresentar os dados quando a tela for carregada
            PreencherDataGridViewComEnderecos();

            // Irá apresentar os nomes dos pacientes no ComboBox quando a tela for carregada
            PreencherComboBoxComOsNomesDosPacientes();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            maskedTextBoxCep.Text = string.Empty;
            textBoxEnderecoCompleto.Text = string.Empty;
            comboBoxPaciente.SelectedIndex = -1;

            dataGridView1.ClearSelection();
        }
        private void buttonSalvar_Click(object sender, EventArgs e)
        {
            // Obter os dados preenchidos pelo usuário armazenando em variáveis
            var cep = maskedTextBoxCep.Text;
            var enderecoCompleto = textBoxEnderecoCompleto.Text;
            var nomePaciente = Convert.ToString(comboBoxPaciente.SelectedItem);

            var dadosValidos = ValidarDados(cep, enderecoCompleto, nomePaciente);

            if (dadosValidos == false)
            {
                return;
            }
            if (dataGridView1.SelectedRows.Count == 0)
                Cadastrarendereco(cep, enderecoCompleto, nomePaciente);
            else
                EditarEndereco(cep, enderecoCompleto, nomePaciente);
            // Apresentar o registro novo no DataGridView
            PreencherDataGridViewComEnderecos();

            LimparCampos();
        }

        private void EditarEndereco(string cep, string enderecoCompleto, string nomePaciente)
        {
            //Obter linha selecionada
            var linhaSelecionada = dataGridView1.SelectedRows[0];

            //Obter codigo que esta na coluna oculta do datagridview
            var codigoSelecionado = Convert.ToInt32(linhaSelecionada.Cells[0].Value);

            //Construir objeto com os dados da tela 
            var endereco = new Endereco();
            endereco.Codigo = codigoSelecionado;
            endereco.EnderecoCompleto = enderecoCompleto;
            endereco.Cep = cep;
            endereco.Paciente = pacienteServico.ObterPorNomePaciente(nomePaciente);

            //Atualizar o dado da lista de endereços e salvar o dado atualizado no arquivo JSON
            enderecoServico.Editar(endereco);
        }

        private void Cadastrarendereco(string cep, string enderecoCompleto, string? nomePaciente)
        {
            // Construir o objeto de endereço com as variáveis
            var endereco = new Endereco();
            endereco.Codigo = enderecoServico.ObterUltimocodigo() + 1;
            endereco.Cep = cep;
            endereco.EnderecoCompleto = enderecoCompleto;
            endereco.Paciente = pacienteServico.ObterPorNomePaciente(nomePaciente);

            // Salvar este endereço na lista de endereços e no arquivo JSON
            enderecoServico.Adicionar(endereco);
        }

        private void PreencherDataGridViewComEnderecos()
        {
            // Obter todos os enderços da lista de endereços
            var enderecos = enderecoServico.ObterTodos();

            // Remover todas as linhas do dataGridView
            dataGridView1.Rows.Clear();

            // Remover a selação do dataGridView
            dataGridView1.ClearSelection();

            // Percorrer cada um dos endereços adicionando cada um em uma nova
            // linha da tabela
            for (var i = 0; i < enderecos.Count; i++)
            {
                // Obter endereço percorrido
                var endereco = enderecos[i];

                // Cria uma nova linha no DataGridView com os dados referentes ao endereço
                dataGridView1.Rows.Add(new object[]
                {
                    endereco.Codigo,
                    endereco.EnderecoCompleto,
                    endereco.Cep,
                    endereco.Paciente.Nome
                }); ;
            }
        }

        private void PreencherComboBoxComOsNomesDosPacientes()
        {
            // Obter lista dos pacientes que foram cadastrados, ou seja, armazenados no JSON
            var pacientes = pacienteServico.ObterTodos();

            for (var i = 0; i < pacientes.Count; i++)
            {
                var paciente = pacientes[i];
                comboBoxPaciente.Items.Add(paciente.Nome);
            }
        }

        private void ObterDadosCep()
        {
            var cep = maskedTextBoxCep.Text.Replace("-","");
            // HttpClient permite fazer requisições para obter ou enviar dados para outros sistemas
            var httpClient = new HttpClient();

            // Executando a requisição para o site ViaCep para obter os dados do endereço do cep
            var resultado = httpClient.GetAsync($"http://viacep.com.br/ws/{cep}/json/").Result;

            // Verificar se a requisicação deu certo
            if (resultado.StatusCode == System.Net.HttpStatusCode.OK)
            {
                // Obter a resposta da requisição
                var resposta = resultado.Content.ReadAsStringAsync().Result;

                var dadosEndereco = JsonConvert.DeserializeObject<EnderecoDadosRequisicao>(resposta);

                textBoxEnderecoCompleto.Text = $"{dadosEndereco.Logradouro} - {dadosEndereco.Bairro} - {dadosEndereco.Localidade} - {dadosEndereco.Uf}";
            }
        }

        private void maskedTextBoxCep_Leave(object sender, EventArgs e)
        {
            ObterDadosCep();
        }
        private bool ValidarDados (string cep, string enderecoCompleto, string nomePaciente)
        {
            if (cep.Replace("-", "").Trim().Length != 8)
            {
                MessageBox.Show("Cep inválido");
                maskedTextBoxCep.Focus();
                return false;
            }

            if (enderecoCompleto.Trim().Length <10)
            {
                MessageBox.Show("Endereço completo deve conter no mínimo 10 caracteres");
                textBoxEnderecoCompleto.Focus();
                return false;
            }

            if (comboBoxPaciente.SelectedIndex == -1)
            {
                MessageBox.Show("Escolha um paciente");
                comboBoxPaciente.DroppedDown = true;
                return false;
            }
            return true;
        }

        private void buttonApagar_Click(object sender, EventArgs e)
        {
            //Verificar se algum item do DataGridView está selecionado
            if(dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um endereço para remover");
                return;
            }
            //Questionar se o usuário realmente deseja apagar
            var resposta = MessageBox.Show("Deseja realmente apagar o endereço?", "Aviso", MessageBoxButtons.YesNo);
            
            //Validar que o usuário não escolheu sim pq nao devera continuar executando o código abixo
            if(resposta == DialogResult.Yes)
            {
                MessageBox.Show("Relaxa teu registro ta ali salvo");
                return;
            }

            //Qual item será apagado
            var linhaSelecionada = dataGridView1.SelectedRows[0];

            var codigo = Convert.ToInt32(linhaSelecionada.Cells[0].Value);

            //Apagar o item da lista de itens no serviço
            //Atualizar o arquivo JSON

            var endereco = enderecoServico.ObterPorCodigo(codigo);

            enderecoServico.Apagar(endereco);
            //Atualizar o DataGridView
            PreencherDataGridViewComEnderecos();
            //Remover a seleção do DataGridView
            dataGridView1.ClearSelection();

        }

        private void buttonEditar_Click(object sender, EventArgs e)
        {
            ApresentarDadosParaEdicao();

        }

        private void ApresentarDadosParaEdicao()
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Selecione um endereço para editar");
                return;
            }
            //obter a linha que o usuáiro selecionou
            var linhaSelecionada = dataGridView1.SelectedRows[0];

            //obter o codigo do endereço que o usuario selecionou
            var codigo = Convert.ToInt32(linhaSelecionada.Cells[0].Value);

            //obter o endereço solicitado
            var endereco = enderecoServico.ObterPorCodigo(codigo);

            //Apresentar os dados do endereço na tela para edição
            maskedTextBoxCep.Text = endereco.Cep;
            textBoxEnderecoCompleto.Text = endereco.EnderecoCompleto;
            comboBoxPaciente.SelectedItem = endereco.Paciente.Nome;
        }

        private void EnderecosForm_Load(object sender, EventArgs e)
        {
            PreencherDataGridViewComEnderecos();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ApresentarDadosParaEdicao();
        }
    }
}
