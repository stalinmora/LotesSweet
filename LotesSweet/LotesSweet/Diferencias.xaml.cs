﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LotesSweet
{
    /// <summary>
    /// Lógica de interacción para Diferencias.xaml
    /// </summary>
    public partial class Diferencias : Window
    {
        public Diferencias()
        {
            InitializeComponent();
        }

        public Diferencias(int codigo, decimal diferencias)
        {
            InitializeComponent();
        }
    }
}
