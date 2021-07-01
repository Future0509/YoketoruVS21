﻿using System;
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
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(int vKey);
        const bool isDebug = true;

        const int PlayerMax = 1;
        const int EnemyMax = 10;
        const int ItemMax = 10;
        const int ChrMax = PlayerMax + EnemyMax + ItemMax;

        Label[] chrs = new Label[ChrMax];
        const int PlayerIndex = 0;
        const int EnemyIndex = PlayerIndex + PlayerMax;
        const int ItemIndex = EnemyIndex + EnemyMax;

        const string PlayerText = "(・ω・)";
        const string EnemyText = "◆";
        const string ItemText = "★";
        static Random rand = new Random();
        enum State
        {
            None = -1,      //無効
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
            for (int i = 0; i < ChrMax; i++)
            {
                chrs[i] = new Label();
                chrs[i].AutoSize = true;
                if (i == PlayerIndex)
                {
                    chrs[i].Text = PlayerText;
                }
                else if (i < ItemIndex)
                {
                    chrs[i].Text = EnemyText;
                }
                else
                {
                    chrs[i].Text = ItemText;
                }
                Controls.Add(chrs[i]);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            if (nextState != State.None)
            {
                initProc();
            }

            void initProc()
            {
                currentState = nextState;
                nextState = State.None;
                switch (currentState)
                {
                    case State.Title:
                        titleLabel.Visible = true;
                        startButton.Visible = true;
                        copyrightLabel.Visible = true;
                        hiLabel.Visible = true;
                        gameOverLabel.Visible = false;
                        titleButton.Visible = false;
                        clearLabel.Visible = false;
                        break;
                    case State.Game:
                        titleLabel.Visible = false;
                        startButton.Visible = false;
                        copyrightLabel.Visible = false;
                        hiLabel.Visible = false;
                        break;


                }
            }
            if (isDebug)
            {
                if (GetAsyncKeyState((int)Keys.O) < 0)
                {
                    nextState = State.Gameover;
                }
                else if (GetAsyncKeyState((int)Keys.C) < 0)
                {
                    nextState = State.Clear;
                }
                if (currentState == State.Game)
                {
                    UpdateGame();
                }
                if (GetAsyncKeyState((int)Keys.Space) < 0)
                {
                    Text = "space";
                }
            }
            void UpdateGame()
            {
                Point mp = PointToClient(MousePosition);
                // TODO: mpがプレイヤーの中心になるように設定
            }
           
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            nextState = State.Game;
        }
    }
}
