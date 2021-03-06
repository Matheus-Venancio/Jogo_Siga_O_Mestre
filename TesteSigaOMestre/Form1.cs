using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Threading;


namespace TesteSigaOMestre
{
    public partial class Form1 : Form
    {
        List<string> sequencia = new List<string>();
        List<string> jogador = new List<string>();
       
        int lista,pontos;
    
        string atualCor;
        string[] cores = { "V", "G", "A", "Y" };
        bool jogar;
        
        Random rdn = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        
       
          private void ProcuraCor(string tagPict)
        {
            foreach(var corEncontrada in Controls.OfType<PictureBox>())
            {
                if (corEncontrada.Tag.ToString() == tagPict)
                {

                    string tag = corEncontrada.Tag.ToString();



                    if (corEncontrada.Tag.ToString() == "V")
                    {
                        corEncontrada.Image = Properties.Resources.vermelho_aceso;
                        timer1.Start();
                    }
                    else
                    {
                        if (corEncontrada.Tag.ToString() == "G")
                        {
                            corEncontrada.Image = Properties.Resources.verde_aceso;
                            timer1.Start();
                        }
                        else
                        {
                            if (corEncontrada.Tag.ToString() == "Y")
                            {
                                corEncontrada.Image = Properties.Resources.amarelo_aceso;
                                timer1.Start();

                            }
                            else
                            {
                                if (corEncontrada.Tag.ToString() == "A")
                                {
                                    corEncontrada.Image = Properties.Resources.azul_aceso;
                                    timer1.Start();


                                }
                            }
                        }
                    }

                    
                

                }
               
            }
        }
        private void apagar(string tagPic)
        {
            foreach (var corEncontrada in Controls.OfType<PictureBox>())
            {
                if (corEncontrada.Tag.ToString() == tagPic)
                {

                    string tag = corEncontrada.Tag.ToString();



                    if (corEncontrada.Tag.ToString() == "V")
                    {
                        
                        corEncontrada.Image = Properties.Resources.vermelho;
                        timer1.Stop();
                    }
                    else
                    {
                        if (corEncontrada.Tag.ToString() == "G")
                        {
                           
                            corEncontrada.Image = Properties.Resources.verde;
                            timer1.Stop();
                        }
                        else
                        {
                            if (corEncontrada.Tag.ToString() == "Y")
                            {
                                
                                corEncontrada.Image = Properties.Resources.amarelo;
                                timer1.Stop();
                            }
                            else
                            {
                                if (corEncontrada.Tag.ToString() == "A")
                                {
                                   
                                    corEncontrada.Image = Properties.Resources.azul;
                                    timer1.Stop();
                                }
                            }
                        }
                    }



                }
                Thread.Sleep(150);
                
            }
        }

        private void corSorteada()
        {
            /**Mostra a cor e da pra clicar**/
            atualCor = cores[rdn.Next(0, cores.Length)];
            sequencia.Add(atualCor);

            foreach(var cor in sequencia)
            {
                Application.DoEvents();
                Thread.Sleep(150);//250
                ProcuraCor(cor);
                
            }

            jogar = true;
        }

        private void clique(object sender, EventArgs e)
        {
            if (lista <= 2)
            {


                PictureBox pb = (PictureBox)sender;

                if (jogar)
                {
                    jogar = false;
                    atualCor = pb.Tag.ToString();
                    jogador.Add(atualCor);
                    ProcuraCor(atualCor);

                    if (jogador[lista] == sequencia[lista])
                    {

                        pontos++; lblPontos.Text =" pontos: " + pontos.ToString();
                        lista++;
                        checar();
                    }
                    else
                    {
                        MessageBox.Show("Você errou a sequencia!  Fim de jogo");
                    }
                }
            }
            else
            {
                MessageBox.Show("Parabens Você venceu");
            }
        }


        private void checar()
        {
            if (lista == sequencia.Count)
            {
                lista = 0;
                jogador.Clear();/**limpa quando for dnv**/
                corSorteada();
            }
            else
            {
                jogar = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (var cor in sequencia)
            {


                apagar(cor);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void opcoes(object sender, EventArgs e)
        {
            ToolStripMenuItem menu = (ToolStripMenuItem)sender;

            switch (menu.Text)
            {

                case "Iniciar": pontos = 0; lblPontos.Text = "pontos: "; jogador.Clear();
                    sequencia.Clear();
                    jogar = false;
                    lista = 0;
                    corSorteada();
                    break;

                case "Sair": Application.Exit();


                    break;
            }
        }
    }
}


