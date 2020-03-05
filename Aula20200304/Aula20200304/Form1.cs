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
using System.Diagnostics;

namespace Aula20200304
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnOi_Click(object sender, EventArgs e)
        {
            GRBEnv Ambiente = new GRBEnv();
            GRBModel Modelo = new GRBModel(Ambiente);
            GRBVar x = Modelo.AddVar(0, 1, 0, GRB.BINARY, "x");
            GRBVar y = Modelo.AddVar(0, 1, 0, GRB.BINARY, "y");
            GRBVar z = Modelo.AddVar(0, 1, 0, GRB.BINARY, "z");
            Modelo.SetObjective(x + y + 2 * z, GRB.MAXIMIZE);
            Modelo.AddConstr(x + 2 * y + 3 * z <= 4.0, "c0");
            Modelo.AddConstr(x + y >= 1.0, "c1");
            Modelo.Write("C:\\Teste\\ModeloAula.lp");
            Modelo.Optimize();
            MessageBox.Show("O valor da variável x é: " + x.X.ToString());
            MessageBox.Show("O valor da variável y é: " + y.X.ToString());
            MessageBox.Show("O valor da variável z é: " + z.X.ToString());

        }

        private void btnModelo2_Click(object sender, EventArgs e)
        {
            GRBEnv Ambinte = new GRBEnv();
            GRBModel Modelo = new GRBModel(Ambinte);
            Random Aleatorio = new Random(4);
            int m = 1600;
            GRBVar[,] X = new GRBVar[m, m];
            for(int i=0;i<m;i++)
            {
                for(int j=0;j<m;j++)
                {
                    X[i, j] = Modelo.AddVar(0, 1, Aleatorio.Next(1, 20), GRB.BINARY, "x_" + i.ToString() + "_" + j.ToString());
                }
            }
            Modelo.ModelSense = GRB.MAXIMIZE;
            GRBLinExpr Expressao=new GRBLinExpr();
            for (int i=0;i<m;i++)
            {
                Expressao.Clear();
                for (int j = 0; j < m; j++)
                {
                    Expressao.AddTerm(1, X[i, j]);
                }
                Modelo.AddConstr(Expressao == 1, "Vendedor_" + i);
            }

            for (int j = 0; j < m; j++)
            {
                Expressao.Clear();
                for (int i = 0; i < m; i++)
                {
                    Expressao.AddTerm(1, X[i, j]);
                }
                Modelo.AddConstr(Expressao == 1, "Regiao_" + j);
            }
            Stopwatch Cronometro = new Stopwatch();
            Cronometro.Start();
            Modelo.Optimize();
            Cronometro.Stop();
            MessageBox.Show("O valor do lucro é: " + Modelo.ObjVal.ToString());
            MessageBox.Show("O tempo para resolver foi de: " + Cronometro.ElapsedMilliseconds.ToString() + " ms");
            MessageBox.Show("Se quiser saber a alocação que gera esse lucro é só me pagar");
            //for (int j = 0; j < m; j++)
            //{
            //    for (int i = 0; i < m; i++)
            //    {
            //        if(X[i,j].X>0)
            //        {
            //            MessageBox.Show("O vendedor " + i + " é alocado para a região " + j);
            //        }
            //    }
            //}
            Modelo.Write("C:\\Teste\\Modelo2.lp");
        }
    }
}
