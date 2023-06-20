using IronXL;
using System;
using System.CodeDom;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Excel = Microsoft.Office.Interop.Excel;
namespace ReadPolarBear
{
    public partial class Form1 : Form
    {
        public string tableName = "";
        private List<Province> myProvinces = new List<Province>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            provinceListbox.HorizontalScrollbar = true;
        }

        private void ImportExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        DataTable dtExcel = ReadExcel(file.FileName);
                        tableName = dtExcel.TableName;
                        for (int i = 0; i < myProvinces.Count; i++)
                        {
                            if (myProvinces[i].Name == tableName)
                            {
                                return;
                            }
                        }
                        dataGridView1.Visible = true;
                        for (int j = 66; j < 75; j++)
                        {
                            dtExcel.Rows[66].Delete();
                        }
                        for (int i = 0; i < 8; i++)
                        {
                            dtExcel.Rows[0].Delete();
                        }
                        dtExcel.AcceptChanges();
                        dataGridView1.DataSource = dtExcel;
                    }
                    catch
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only,", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            WorkSheet sheet = workbook.DefaultWorkSheet;
            return sheet.ToDataTable(true);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource == null)
            {
                return;
            }
            for (int i = 0; i < myProvinces.Count; i++)
            {
                if (myProvinces[i].Name == tableName)
                {
                    return;
                }
            }
            Province currentProvince = new Province(tableName);
            //SkillNode skillNode = new SkillNode();
            for (int rows = 0; rows < dataGridView1.Rows.Count; rows++)
            {
                SkillNode skillNode = new SkillNode();
                for (int cols = 0; cols < dataGridView1.Rows[rows].Cells.Count; cols++)
                {
                    string value = "";
                    if (dataGridView1.Rows[rows].Cells[cols].Value != null)
                    {
                        value = dataGridView1.Rows[rows].Cells[cols].Value.ToString();
                    }
                    if (cols == 0)
                    {
                        if (value == "")
                        {
                            goto LoopEnd;
                        }
                        skillNode.Name = value;
                    }
                    else
                    {
                        skillNode.AddData(value);
                    }
                    if (cols == dataGridView1.Rows[rows].Cells.Count - 1)
                    {
                        currentProvince.Add(skillNode);
                    }

                }
            }
        LoopEnd:
            if (currentProvince.skillList.Count != int.Parse(TotalSkillNum.Text) && int.Parse(TotalSkillNum.Text) != 0)
            {
                MessageBox.Show("The current Excel data is not correct! The numbers of skills does not match the previous excel.");
                return;
            }
            myProvinces.Add(currentProvince);
            dataGridView1.DataSource = null;
            tableName = "";
            provinceListbox.BeginUpdate();
            provinceListbox.Items.Add(currentProvince.Name);
            provinceListbox.EndUpdate();

            TradeListbox.BeginUpdate();

            for (int i = 0; i < currentProvince.skillList.Count; i++)
            {
                TradeListbox.Items.Add(currentProvince.skillList[i].Name);
            }
            if (TotalSkillNum.Text == "0")
            {
                TotalSkillNum.Text = currentProvince.skillList.Count.ToString();
            }

            TradeListbox.EndUpdate();
            ProvinceNum.Text = provinceListbox.Items.Count.ToString();
        }



        private void provinceListbox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ClearExltable_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            tableName = "";
        }

        private void DeleteProvince_Click(object sender, EventArgs e)
        {

            if (provinceListbox.SelectedItem == null)
            {
                return;
            }
            var selectedItem = provinceListbox.SelectedItem.ToString();

            foreach (var pData in myProvinces)
            {
                if (pData.Name == selectedItem)
                {
                    myProvinces.Remove(pData);
                    break;
                }
            }

            provinceListbox.Items.RemoveAt(provinceListbox.SelectedIndex);
            if (provinceListbox.Items.Count == 0)
            {
                TradeListbox.Items.Clear();
                TotalSkillNum.Text = "0";
            }
            ProvinceNum.Text = provinceListbox.Items.Count.ToString();

        }

        private void ClearListbox_Click(object sender, EventArgs e)
        {

            myProvinces.Clear();
            provinceListbox.Items.Clear();
            TradeListbox.Items.Clear();
            TotalSkillNum.Text = "0";
            ProvinceNum.Text = provinceListbox.Items.Count.ToString();

        }

        private void ExportOne_Click(object sender, EventArgs e)
        {
            if (TradeListbox.SelectedItem == null)
            {
                return;
            }

            var exportTradeName = TradeListbox.SelectedItem.ToString();

            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!");
                return;
            }
            Excel.Workbook xlWorkbook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            xlWorkbook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
            for (int index = 0; index < myProvinces.Count; index++)
            {
                xlWorkSheet.Cells[index + 1, 1] = myProvinces[index].Name;
                for (int j = 0; j < myProvinces[index].skillList.Count; j++)
                {
                    if (myProvinces[index].skillList[j].Name == exportTradeName)
                    {
                        for (int k = 0; k < myProvinces[index].skillList[j].data.Count; k++)
                        {
                            xlWorkSheet.Cells[index + 1, k + 2] = myProvinces[index].skillList[j].data[k];
                        }
                        break;
                    }
                }
            }
            string[] nameArray = exportTradeName.Split('\n');
            string path = "D:\\Skills\\" + nameArray[0] + ".xls";
            xlWorkbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkbook.Close(true, misValue, misValue);
            xlApp.Quit();
            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkbook);
            Marshal.ReleaseComObject(xlApp);
            MessageBox.Show("Excel file created , you can find the file " + path);
        }

        private void TotalLabel_Click(object sender, EventArgs e)
        {

        }

        private void ExportAll_Click(object sender, EventArgs e)
        {
            var allList = TradeListbox.Items;

            for (int listIndex = 0; listIndex < allList.Count; listIndex++)
            {
                Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    MessageBox.Show("Excel is not properly installed!");
                    return;
                }
                Excel.Workbook xlWorkbook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;
                xlWorkbook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkbook.Worksheets.get_Item(1);
                for (int index = 0; index < myProvinces.Count; index++)
                {
                    xlWorkSheet.Cells[index + 1, 1] = myProvinces[index].Name;
                    for (int j = 0; j < myProvinces[index].skillList.Count; j++)
                    {
                        if (myProvinces[index].skillList[j].Name == allList[listIndex].ToString())
                        {
                            for (int k = 0; k < myProvinces[index].skillList[j].data.Count; k++)
                            {
                                xlWorkSheet.Cells[index + 1, k + 2] = myProvinces[index].skillList[j].data[k];
                            }
                            break;
                        }
                    }
                }
                Regex illegalInFileName = new Regex(@"[\\/:*?""<>|]");
                string fileName = String.Concat(allList[listIndex].ToString().Split('\n')[0].Where(c => !Char.IsWhiteSpace(c)));
                string path = "D:\\Skills\\" + illegalInFileName.Replace(fileName, "") + ".xls";
                xlWorkbook.SaveAs(path, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkbook.Close(true, misValue, misValue);
                xlApp.Quit();
                Marshal.ReleaseComObject(xlWorkSheet);
                Marshal.ReleaseComObject(xlWorkbook);
                Marshal.ReleaseComObject(xlApp);
                //MessageBox.Show("Excel file created , you can find the file d:\\csharp-Excel.xls");
            }
        }

        private void ExportTemp_Click(object sender, EventArgs e)
        {
            if (TradeListbox.SelectedItem == null)
            {
                return;
            }

            var exportTradeName = TradeListbox.SelectedItem.ToString();
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        WorkBook wb = WorkBook.Load(file.FileName);
                        WorkSheet workSheet = wb.DefaultWorkSheet;
                        for (int index = 0; index < myProvinces.Count; index++)
                        {
                            for (int j = 0; j < myProvinces[index].skillList.Count; j++)
                            {
                                if (myProvinces[index].skillList[j].Name == exportTradeName)
                                {
                                    workSheet.Rows[index + 8].Columns[0].Value = myProvinces[index].Name;
                                    for (int k = 0; k < myProvinces[index].skillList[j].data.Count; k++)
                                    {
                                        workSheet.Rows[index + 8].Columns[k + 1].Value = myProvinces[index].skillList[j].data[k];
                                        //if(k+1==4 || k+1==5 || k+1==11 || k + 1 == 12){
                                        //    workSheet.Rows[index + 8].Columns[k + 1].FormatString = "%0";
                                        //}
                                        //xlWorkSheet.Cells[index + 1, k + 2] = myProvinces[index].skillList[j].data[k];
                                    }
                                    break;
                                }
                            }
                        }

                        Regex illegalInFileName = new Regex(@"[\\/:*?""<>|]");
                        string fileName = String.Concat(exportTradeName.Split('\n')[0].Where(c => !Char.IsWhiteSpace(c)));
                        workSheet.Rows[3].Columns[10].Value = fileName;
                        workSheet.Rows[4].Columns[10].Value = "";
                        string path = "D:\\Skills\\" + illegalInFileName.Replace(fileName, "") + ".xls";
                        wb.SaveAs(path);
                        MessageBox.Show("Excel file created , you can find the file " + path);
                    }
                    catch
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only,", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ExportAllTemp_Click(object sender, EventArgs e)
        {
            //var exportTradeName = TradeListbox.SelectedItem.ToString();
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    try
                    {
                        WorkBook wb = WorkBook.Load(file.FileName);
                        WorkSheet workSheet = wb.DefaultWorkSheet;
                        var allList = TradeListbox.Items;

                        for (int listIndex = 0; listIndex < allList.Count; listIndex++)
                        {
                            for (int index = 0; index < myProvinces.Count; index++)
                            {
                                for (int j = 0; j < myProvinces[index].skillList.Count; j++)
                                {
                                    if (myProvinces[index].skillList[j].Name == allList[listIndex].ToString())
                                    {
                                        workSheet.Rows[index + 8].Columns[0].Value = myProvinces[index].Name;
                                        for (int k = 0; k < myProvinces[index].skillList[j].data.Count; k++)
                                        {
                                            workSheet.Rows[index + 8].Columns[k + 1].Value = myProvinces[index].skillList[j].data[k];
                                            //xlWorkSheet.Cells[index + 1, k + 2] = myProvinces[index].skillList[j].data[k];
                                        }
                                        break;
                                    }
                                }
                            }

                            Regex illegalInFileName = new Regex(@"[\\/:*?""<>|]");
                            string fileName = String.Concat(allList[listIndex].ToString().Split('\n')[0].Where(c => !Char.IsWhiteSpace(c)));
                            workSheet.Rows[3].Columns[10].Value = fileName;
                            workSheet.Rows[4].Columns[10].Value = "";
                            string path = "D:\\Skills\\" + illegalInFileName.Replace(fileName, "") + ".xls";
                            wb.SaveAs(path);
                        }
                        MessageBox.Show("export all the skills to D:\\Skills folders");
                    }
                    catch
                    {

                    }
                }
                else
                {
                    MessageBox.Show("Please choose .xls or .xlsx file only,", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}