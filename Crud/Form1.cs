using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Crud
{
    public partial class Form1 : Form
    {
        public List<Empleados> dgv = new List<Empleados>();
        public Form1()
        {
            InitializeComponent();
            Empleados empleados = new Empleados();
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
            DataGridView.DataSource = null;
            DataGridView.DataSource = dgv;
        }
        public void errormessage(string error)
        {
            MessageBox.Show(error);
        }
        public bool validateNumbers()
        {
            bool valid = false;
            double.TryParse(IdBox.Text, out double xid);
            if (xid != 0)
            {
                errorProvider1.Clear();
            }
            else { errorProvider1.SetError(IdBox, "El indentificador debe ser un número"); }
            double.TryParse(AgeBox.Text, out double xage);
            if (xage != 0)
            {
                errorProvider2.Clear();
            }
            else { errorProvider2.SetError(AgeBox, "La edad debe ser un número"); }
            if (xid != 0 && xage != 0) { valid = true; }
            return valid;
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
            if (validateNumbers())
            {
                Empleados empleados = new Empleados();
                empleados.Id = Int32.Parse(IdBox.Text);
                empleados.Name = NameBox.Text;
                empleados.Age = Int32.Parse(AgeBox.Text);
                empleados.Email = EmailBox.Text;
                bool already_exist = dgv.Any(empleado => empleado.Id == empleados.Id);
                if (already_exist)
                {
                    load();
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
                    load();
                    updatelist(empleados);

                }
                refresh();
            }
        }

        private void Eliminarbtn_Click(object sender, EventArgs e)
        {
            if (validateNumbers())
            {
                string checker = IdBox.Text;
                var isempty = dgv.Select(empleado => empleado.Id).FirstOrDefault();
                if (checker != "" && isempty != 0)
                {
                    int IdEliminar = Int32.Parse(IdBox.Text);
                    var FindEliminar = dgv.FindIndex(empleado => empleado.Id == IdEliminar);
                    load();
                    eliminar(FindEliminar);
                    refresh();
                    DataGridView.ClearSelection();
                }
                else if (isempty == 0)
                {
                    errormessage("No quedan datos por eliminar");
                }
                else
                {
                    errormessage("El campo del Identificador esta vacio");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void DataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int item = (int)DataGridView.Rows[e.RowIndex].Cells[0].Value;
            var find = dgv.Where(empleado => empleado.Id == item).ToList();
            foreach (var empleado in find)
            {
                IdBox.Text = empleado.Id.ToString();
                NameBox.Text = empleado.Name;
                AgeBox.Text = empleado.Age.ToString();
                EmailBox.Text = empleado.Email;
            }
        }

        private async void load()
        {
            pictureBox1.Visible = true;
            await Task.Delay(TimeSpan.FromSeconds(3));
            pictureBox1.Visible = false;
        }


    }
}
