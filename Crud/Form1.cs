using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Crud
{
    public partial class Form1 : Form
    {
        public List<Empleados> dgv = new List<Empleados>();
        public Form1()
        {
            InitializeComponent();
            Empleados empleados= new Empleados();
            empleados.Id = 1;
            empleados.Name = "carlos";
            empleados.Age = 1;
            empleados.Email = "tesis@tesis.mx";
            updatelist(empleados);
            refresh();
        }
        public void updatelist(Empleados empleado)
        {
            dgv.Add(empleado);
        }
        public void eliminar(int i)
        {
            dgv.RemoveAt(i);
        }
        public void refresh()
        {
           DataGridView.DataSource=null;
           DataGridView.DataSource= dgv;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void IdBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nuevobtn_Click(object sender, EventArgs e)
        {
            IdBox.Text = string.Empty;
            NameBox.Text = string.Empty;
            AgeBox.Text = string.Empty;
            EmailBox.Text = string.Empty;
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void NameBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void AgeBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void EmailBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Guardarbtn_Click(object sender, EventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Id = Int32.Parse(IdBox.Text);
            empleados.Name = NameBox.Text;
            empleados.Age = Int32.Parse(AgeBox.Text);
            empleados.Email = EmailBox.Text;
            bool already_exist = dgv.Any(empleado=>empleado.Id==empleados.Id);
            if (already_exist)
            {
                var findit = dgv.Where(empleado => empleado.Id == empleados.Id);
                foreach (Empleados emp in findit)
                {
                    emp.Name = empleados.Name;
                    emp.Age = empleados.Age;
                    emp.Email = empleados.Email;
                }
            }
            else
            {
                updatelist(empleados);
            }
            refresh();
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            var IdEliminar = Int32.Parse(IdBox.Text);
            var FindEliminar = dgv.FindIndex(empleado => empleado.Id == IdEliminar);
            eliminar(FindEliminar);
            refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int item = (int)DataGridView.Rows[e.RowIndex].Cells[0].Value;
            var find=dgv.Where(empleado=>empleado.Id == item).ToList();
            foreach (var empleado in find)
            {
                IdBox.Text = empleado.Id.ToString();
                NameBox.Text = empleado.Name;
                AgeBox.Text = empleado.Age.ToString();
                EmailBox.Text = empleado.Email;
            }
        }

    }
}
