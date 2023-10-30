using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace Trinagle
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void UpdateTextBlock()
        {
            TextBlock.Text = "測試結果：\n";

            foreach (Triangle triangle in triangles)
            {
                string result = triangle.IsValid ? "可構成" : "不可構成";
                TextBlock.Text += $"邊長 {triangle.SideA}, {triangle.SideB}, {triangle.SideC} {result}三角形\n";
            }
        }

        private List<Triangle> triangles = new List<Triangle>();

        public class Triangle
        {
            public double SideA { get; }
            public double SideB { get; }
            public double SideC { get; }
            public bool IsValid { get; }

            public Triangle(double sideA, double sideB, double sideC)
            {
                SideA = sideA;
                SideB = sideB;
                SideC = sideC;
                IsValid = IsTriangleValid(sideA, sideB, sideC);
            }

            private bool IsTriangleValid(double a, double b, double c)
            {
                return (a + b > c) && (b + c > a) && (a + c > b);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            double A, B, C;
            bool number = double.TryParse(text1.Text, out A);
            bool number1 = double.TryParse(text2.Text, out B);
            bool number2 = double.TryParse(text3.Text, out C);

            if (!number || !number1 || !number2 || A < 0 || B < 0 || C < 0)
            {
                MessageBox.Show("請輸入正數!", "Error!");
            }
            else
            {
                Triangle triangle = new Triangle(A, B, C);
                if (triangle.IsValid)
                {
                    label.Background = new SolidColorBrush(Colors.Green);
                    label.Content = $"邊長 {A}, {B}, {C} 可構成三角形";
                }
                else
                {
                    label.Background = new SolidColorBrush(Colors.Red);
                    label.Content = $"邊長 {A}, {B}, {C} 不可構成三角形";
                }

                triangles.Add(triangle); // 將此三角形添加到列表中
                UpdateTextBlock();
            }
        }
    }
}
