using Agenda.DAO;
using System.Data;

namespace Agenda
{
    public partial class frmAgenda : Form
    {
        public frmAgenda()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            CarregarDataGridView();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = (int) dgvAgenda.CurrentRow.Cells[0].Value; //volta em object
            ContatoDAO contatoDao = new ContatoDAO();
            contatoDao.Excluir(id);
            CarregarDataGridView();

        }

        private void CarregarDataGridView()
        {
            ContatoDAO contatoDao = new ContatoDAO();
            DataSet ds = contatoDao.GetContatos();
            dgvAgenda.DataSource = ds.Tables["CONTATOS"]; //especificar de qual table
            dgvAgenda.Refresh();
        }
    }
}