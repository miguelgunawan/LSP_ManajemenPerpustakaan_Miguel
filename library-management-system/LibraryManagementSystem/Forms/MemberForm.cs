using LibraryManagementSystem.Data;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Forms
{
    public partial class MemberForm : Form
    {
        private readonly MemberRepository memberRepo;
        private int selectedIdAnggota = 0;

        public MemberForm()
        {
            InitializeComponent();
            memberRepo = new MemberRepository();
        }

        private void MemberForm_Load(object sender, EventArgs e)
        {
            try
            {
                LoadMembers();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMembers()
        {
            try
            {
                var members = memberRepo.GetAllMembers();
                dgvMembers.DataSource = members;

                if (dgvMembers.Columns.Count > 0)
                {
                    dgvMembers.Columns["IdAnggota"].HeaderText = "ID";
                    dgvMembers.Columns["IdAnggota"].Width = 50;
                    dgvMembers.Columns["KodeAnggota"].HeaderText = "Kode Anggota";
                    dgvMembers.Columns["NamaLengkap"].HeaderText = "Nama Lengkap";
                    dgvMembers.Columns["Alamat"].HeaderText = "Alamat";
                    dgvMembers.Columns["NoTelepon"].HeaderText = "No. Telepon";
                    dgvMembers.Columns["Email"].HeaderText = "Email";
                    dgvMembers.Columns["TanggalBergabung"].HeaderText = "Tanggal Bergabung";
                    dgvMembers.Columns["TanggalBergabung"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvMembers.Columns["Aktif"].HeaderText = "Aktif";
                }

                lblTitle.Text = $"👥 MANAJEMEN ANGGOTA ({members.Count} Anggota)";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading members: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInput()) return;

                var member = new Member
                {
                    KodeAnggota = txtKodeAnggota.Text.Trim(),
                    NamaLengkap = txtNamaLengkap.Text.Trim(),
                    Alamat = txtAlamat.Text.Trim(),
                    NoTelepon = txtNoTelepon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Aktif = chkActive.Checked
                };

                if (memberRepo.AddMember(member))
                {
                    MessageBox.Show("Anggota berhasil ditambahkan!", "Sukses", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMembers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal menambahkan anggota.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedIdAnggota == 0)
                {
                    MessageBox.Show("Pilih anggota yang akan diupdate!", "Peringatan", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!ValidateInput()) return;

                var member = new Member
                {
                    IdAnggota = selectedIdAnggota,
                    KodeAnggota = txtKodeAnggota.Text.Trim(),
                    NamaLengkap = txtNamaLengkap.Text.Trim(),
                    Alamat = txtAlamat.Text.Trim(),
                    NoTelepon = txtNoTelepon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Aktif = chkActive.Checked
                };

                if (memberRepo.UpdateMember(member))
                {
                    MessageBox.Show("Anggota berhasil diupdate!", "Sukses", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadMembers();
                    ClearForm();
                }
                else
                {
                    MessageBox.Show("Gagal mengupdate anggota.", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedIdAnggota == 0)
                {
                    MessageBox.Show("Pilih anggota yang akan dihapus!", "Peringatan", 
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var result = MessageBox.Show("Apakah Anda yakin ingin menghapus anggota ini?", 
                    "Konfirmasi Hapus", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (memberRepo.DeleteMember(selectedIdAnggota))
                    {
                        MessageBox.Show("Anggota berhasil dihapus!", "Sukses", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMembers();
                        ClearForm();
                    }
                    else
                    {
                        MessageBox.Show("Gagal menghapus anggota.", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }



        private void dgvMembers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvMembers.Rows[e.RowIndex];
                    selectedIdAnggota = Convert.ToInt32(row.Cells["IdAnggota"].Value);
                    txtKodeAnggota.Text = row.Cells["KodeAnggota"].Value.ToString();
                    txtNamaLengkap.Text = row.Cells["NamaLengkap"].Value.ToString();
                    txtAlamat.Text = row.Cells["Alamat"].Value.ToString();
                    txtNoTelepon.Text = row.Cells["NoTelepon"].Value.ToString();
                    txtEmail.Text = row.Cells["Email"].Value.ToString();
                    chkActive.Checked = Convert.ToBoolean(row.Cells["Aktif"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtKodeAnggota.Text))
            {
                MessageBox.Show("Kode anggota tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtKodeAnggota.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNamaLengkap.Text))
            {
                MessageBox.Show("Nama lengkap tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNamaLengkap.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNoTelepon.Text))
            {
                MessageBox.Show("No. telepon tidak boleh kosong!", "Validasi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoTelepon.Focus();
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            selectedIdAnggota = 0;
            txtKodeAnggota.Clear();
            txtNamaLengkap.Clear();
            txtAlamat.Clear();
            txtNoTelepon.Clear();
            txtEmail.Clear();
            chkActive.Checked = true;
            txtKodeAnggota.Focus();
        }
    }
}
