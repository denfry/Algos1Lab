using System.Collections.Generic;
using System.Windows;


namespace Algos1Lab
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeSets();
            DisplaySets();
        }

        private HashSet<int> _setA, _setB, _setC, _universalSet;

        private void InitializeSets()
        {
            _setA = new HashSet<int> { 220, 231, 223, 222, 225 };
            _setB = new HashSet<int> { 226, 224, 232, 220, 221 };
            _setC = new HashSet<int> { 231, 235, 229, 237, 230 };

            _universalSet = new HashSet<int>(_setA);
            _universalSet.UnionWith(_setB);
            _universalSet.UnionWith(_setC);
        }

        private void DisplaySets()
        {
            TextBoxSetA.Text = $"A = {{ {string.Join(", ", _setA)} }}";
            TextBoxSetB.Text = $"B = {{ {string.Join(", ", _setB)} }}";
            TextBoxSetC.Text = $"C = {{ {string.Join(", ", _setC)} }}";
            TextBoxUniversal.Text = $"Universal = {{ {string.Join(", ", _universalSet)} }}";
        }

        private void ButtonCalculateExpression_Click(object sender, RoutedEventArgs e)
        {
            RichTextBox1.Document.Blocks.Clear();

            var intersectionAB = new HashSet<int>(_setA);
            intersectionAB.IntersectWith(_setB);
            RichTextBox1.AppendText($"1) A ∩ B = {{ {string.Join(", ", intersectionAB)} }}\r\n");
            

            var complementA = new HashSet<int>(_universalSet);
            complementA.ExceptWith(_setA);
            RichTextBox1.AppendText($"2) ¬A = {{ {string.Join(", ", complementA)} }}\r\n");
            

            var complementB = new HashSet<int>(_universalSet);
            complementB.ExceptWith(_setB);
            RichTextBox1.AppendText($"3) ¬B = {{ {string.Join(", ", complementB)} }}\r\n");
            

            var complementIntersection = new HashSet<int>(complementA);
            complementIntersection.IntersectWith(complementB);
            RichTextBox1.AppendText($"4) ¬A ∩ ¬B = {{ {string.Join(", ", complementIntersection)} }}\r\n");
            

            complementIntersection.IntersectWith(_setC);
            RichTextBox1.AppendText($"5) (¬A ∩ ¬B) ∩ C = {{ {string.Join(", ", complementIntersection)} }}\r\n");
            

            var result = new HashSet<int>(intersectionAB);
            result.UnionWith(complementIntersection);
            RichTextBox1.AppendText($"6) (A ∩ B) ∪ ((¬A ∩ ¬B) ∩ C) = {{ {string.Join(", ", result)} }}\r\n");
            

            TextBox1.Text = $"Result = {{ {string.Join(", ", result)} }}";
        }
    }
}
