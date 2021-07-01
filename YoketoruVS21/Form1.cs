using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace YoketoruVS21
{
    public partial class Form1 : Form
    {
        enum State
        {
            None=-1,      //無効
            Title,       //タイトル
            Game,       //ゲーム
            Gameover,  //ゲームオーバー
            Clear,    //クリア
        }
        State currentState = State.None;
        State nextState = State.Title;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

       

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(nextState!=State.None)
            {
                initProc();
            }
        }
        void initProc()
        {
            currentState = nextState;
            nextState = State.None;
            switch (currentState)
            {
                case State.Title:
                    titleLabel.Visible = true;
                    staratButton.Visible = true;
                    copyrightLabel.Visible = true;
                    hiLabel.Visible = true;
                    gameOverLabel.Visible = false ;
                    titleButton.Visible = false;
                    clearLabel.Visible = false;
                    break;
                case State.Game:
                    titleLabel.Visible = false;
                    staratButton.Visible = false;
                    copyrightLabel.Visible = false;
                    hiLabel.Visible = false;
                    break;
            }
        }

        private void staratButton_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }
    }
}
