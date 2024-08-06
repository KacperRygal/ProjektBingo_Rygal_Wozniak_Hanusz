﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Bingo.Classes.Buttons
{
    public class BingoFindButton : Button, IBingoButton
    {
        public int id;
        public bool currentState = false;

        private TextBlock textBlock;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        string IBingoButton.Content
        {
            get { return textBlock.Text; }
            set { textBlock.Text = value; }
        }

        bool IBingoButton.CurrentState
        {
            get { return currentState; }
            set { currentState = value; }
        }

        public event EventHandler ButtonClicked;

        public BingoFindButton()
        {
            textBlock = new TextBlock
            {
                TextWrapping = TextWrapping.Wrap,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontFamily = new FontFamily("Bahnschrift SemiBold Condensed"),
                FontSize = 20,
                FontWeight = FontWeights.Bold
            };

            Content = textBlock;

            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Margin = new Thickness(5);
            Width = 140;
            Height = 65;
            Click += (s, e) => OnClick();
            Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFE4E4"));
            Padding = new Thickness(5);
            BorderThickness = new Thickness(2);
            BorderBrush = Brushes.Black;
            
            
        }

        private event EventHandler _onClick;
        event EventHandler IBingoButton.OnClick
        {
            add
            {
                _onClick += value;
            }
            remove
            {
                _onClick -= value;
            }
        }

        protected virtual void OnButtonClicked(EventArgs e)
        {
            ButtonClicked?.Invoke(this, e);
        }

        protected virtual void OnClick()
        {
            Debug.WriteLine(Content);
            if (!currentState)
            {
                Background = new SolidColorBrush(Colors.Red);
                currentState = true;
            }
            else
            {
                Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFE4E4"));
                currentState = false;
            }
            OnButtonClicked(EventArgs.Empty);
            _onClick?.Invoke(this, EventArgs.Empty);
        }

        public Button GetButton()
        {
            return this;
        }
    }
}
