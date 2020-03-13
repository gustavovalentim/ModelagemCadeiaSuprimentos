using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gurobi;

namespace Sudoku
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GRBEnv Ambiente = new GRBEnv();
            GRBModel Modelo = new GRBModel(Ambiente);
            int Tamanho = 4;
            GRBVar[,,] X = new GRBVar[Tamanho,Tamanho,Tamanho];
            for(int i=0;i<Tamanho;i++)
            {
                for(int j=0;j<Tamanho;j++)
                {
                    for(int k=0;k<Tamanho;k++)
                    {
                        X[i, j, k] = Modelo.AddVar(0, 1, 0, GRB.BINARY, "X_" + i.ToString() + "_" +j.ToString() + "_" + k.ToString());
                    }
                }
            }
            GRBLinExpr Expressao = new GRBLinExpr();
            //Criar restrições de que em cada célula exatamente 1 número é alocado
            for(int i=0;i<Tamanho;i++)
            {
                for(int j=0;j<Tamanho;j++)
                {
                    Expressao.Clear();
                    for(int k=0;k<Tamanho;k++)
                    {
                        Expressao.AddTerm(1, X[i, j, k]);
                    }
                    Modelo.AddConstr(Expressao == 1, "SingularidadeDaCelula_" + i.ToString() + "_" + j.ToString());
                }
            }
            //Criar restrições de que cada número, em cada linha, é alocado uma única vez
            for(int i=0;i<Tamanho;i++)
            {
                for(int k=0;k<Tamanho;k++)
                {
                    Expressao.Clear();
                    for(int j=0;j<Tamanho;j++)
                    {
                        Expressao.AddTerm(1, X[i, j, k]);
                    }
                    Modelo.AddConstr(Expressao == 1, "SingularidadeNaLinha_" + i.ToString() + "_" + k.ToString());
                }
            }
            //Criar restrições de que cada número, em cada coluna, é alocado uma única vez
            for (int j = 0; j < Tamanho; j++)
            {
                for (int k = 0; k < Tamanho; k++)
                {
                    Expressao.Clear();
                    for (int i = 0; i < Tamanho; i++)
                    {
                        Expressao.AddTerm(1, X[i, j, k]);
                    }
                    Modelo.AddConstr(Expressao == 1, "SingularidadeNaColuna_" + j.ToString() + "_" + k.ToString());
                }
            }

            Modelo.Write("C:\\Teste\\Sudoku.lp");
            Modelo.Optimize();
            Modelo.Write("C:\\Teste\\Sudoku.sol");
        }
    }
}
