using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparedCookie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var left = textBox1.Text.Replace(" ","").Split(';').Select(o => o.Split('='));
            var right = textBox2.Text.Replace(" ", "").Split(';').Select(o => o.Split('='));
            var keys = new List<string>();
            keys.AddRange(left.Select(o => o[0]));
            keys.AddRange(right.Select(o => o[0]));
            var infos = keys.Distinct().Select(o =>
            {
                var info = new ComparedInfo
                {
                    Key = o,
                    Left = left.FirstOrDefault(l => l[0] == o)?[1],
                    Right = right.FirstOrDefault(r => r[0] == o)?[1],
                };
                info.Same = info.Left == info.Right;
                return info;
            }).ToArray();
            dataGridView1.DataSource = infos;
        }
    }
}
