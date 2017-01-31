using System;
using EnumClass;
using System.Windows.Forms;

namespace BindingEnumToDropDownList
{
    public partial class Form : System.Windows.Forms.Form
    {
        MyEnumType variable;

        public Form()
        {
            InitializeComponent();

            Array values = Enum.GetValues(typeof(MyEnumType));
            foreach (MyEnumType value in values)
                this.comboBox1.Items.Add(EnumClass.EnumClass.GetEnumDescription(value));
            this.comboBox1.SelectedItem = EnumClass.EnumClass.GetEnumDescription(variable);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(variable.ToString());
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            variable = EnumClass.EnumClass.GetValueFromDescription<MyEnumType>(this.comboBox1.SelectedItem.ToString());
        }
    }
}
