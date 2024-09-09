using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilheteria
{
    public partial class Form1 : Form
    {
        Label statusLabel; // Label para mostrar o status das reservas
        int totalReservas = 0; // Contador de reservas

        public Form1()
        {
            InitializeComponent();
            this.Text = "Bilheteria - Controle de Assentos";
            this.Load += new System.EventHandler(this.Form1_Load); // Associa o evento Load ao Form1_Load
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Define o tamanho fixo do Formulário
            this.Size = new Size(1025, 500); // Defina um tamanho adequado para seu formulário

            // Adiciona o Label no topo para status das reservas
            statusLabel = new Label();
            statusLabel.Width = 950;
            statusLabel.Height = 40;
            statusLabel.Top = 400;
            statusLabel.Left = 20;
            statusLabel.Text = "Nenhum assento reservado ainda.";

            // Define o tamanho do texto do Label
            statusLabel.Font = new Font(statusLabel.Font.FontFamily, 14); // Aumenta o tamanho do texto para 14

            // Define o alinhamento do texto do Label
            statusLabel.TextAlign = ContentAlignment.MiddleCenter;

            this.Controls.Add(statusLabel);

            // Defina o tamanho das poltronas
            int checkBoxWidth = 20;
            int checkBoxHeight = 20;
            int spacing = 5; // Espaço entre as poltronas
            int marginLeft = 10; // Margem à esquerda
            int marginTop = 10; // Margem no topo
            int rows = 15;
            int columns = 40;

            // Criação das poltronas dinamicamente
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    // Cria um novo CheckBox
                    CheckBox seatCheckBox = new CheckBox();

                    // Definir propriedades do CheckBox
                    seatCheckBox.Width = checkBoxWidth;
                    seatCheckBox.Height = checkBoxHeight;

                    // Posicionamento do CheckBox com margens
                    seatCheckBox.Left = marginLeft + col * (checkBoxWidth + spacing);
                    seatCheckBox.Top = marginTop + row * (checkBoxHeight + spacing);

                    // Nome e texto do CheckBox com base na sua posição
                    seatCheckBox.Name = $"Seat_{row + 1}_{col + 1}";
                    seatCheckBox.Text = $"fileira {row + 1}, coluna {col + 1}";

                    // Adiciona o evento de mudança de estado (CheckedChanged)
                    seatCheckBox.CheckedChanged += SeatCheckBox_CheckedChanged;

                    // Adiciona o CheckBox ao Form
                    this.Controls.Add(seatCheckBox);
                }
            }
        }

        // Evento chamado ao marcar/desmarcar uma poltrona
        private void SeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox clickedCheckBox = (CheckBox)sender;

            if (totalReservas == 600)
            {
                statusLabel.Text = "A sala está cheia. Não há mais lugares disponíveis para reserva.";
                //return;
            }

            if (clickedCheckBox.Checked)
            {
                // Marca como reservado
                totalReservas++;
                //verifca se sala está cheia
                if (totalReservas == 600)
                {
                    statusLabel.Text = "A sala está cheia. Não há mais lugares disponíveis para reserva.";
                }
                else
                {
                statusLabel.Text = $"Você reservou o assento da {clickedCheckBox.Text}. Total de reservas: {totalReservas}.";
                }
            }
            else
            {
                // Desmarca a reserva
                totalReservas--;
                statusLabel.Text = $"Você liberou o assento da {clickedCheckBox.Text}. Total de reservas: {totalReservas}.";
            }
        }
    }
}