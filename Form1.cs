using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

#region NUEVOS ESPACIOS DE NOMBRES
using System.Data.OleDb;
using Excel = Microsoft.Office.Interop.Excel; 
#endregion

namespace CapturaCalificaciones
{
    public partial class Form1 : Form
    {
        #region VARIABLES
        private OpenFileDialog oFD = new OpenFileDialog();
        private string[,] calificaciones;
        private int filas = 0;
        private int columnas = 0;
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        #region BOTONES PARA EXCEL E INICIAR CAPTURA
        private void btnSeleccionarExcel_Click(object sender, EventArgs e)
        {
            oFD.Title = "Seleccionar Archivo de Excel con Calificaciones";
            oFD.Filter = "Archivos de Excel|*.xls;*.xlsx;";

            if (oFD.ShowDialog() == DialogResult.OK)
            {
                this.cmbHojas.Items.Clear();
                this.Cursor = Cursors.WaitCursor;
                    PCargarArchivoExcel(oFD.FileName);
                this.Cursor = Cursors.Default;
            }
        }
        private void btnIniciarCapturaDeCalificaciones_Click(object sender, EventArgs e)
        {
            if (oFD.FileName == null || oFD.FileName == "")
            { 
                MessageBox.Show("Abre un archivo de excel.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return; 
            }
            else if (cmbHojas.SelectedIndex == -1)
            {
                MessageBox.Show("Selecciona al menos una hoja.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Exclamation); 
                return;
            }

            DialogResult respuesta = MessageBox.Show("Está a punto de enviar la información a la página web.\n ¿Desea continuar?", "Captura de Calificaciones CONECBU", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

            if (respuesta == DialogResult.Yes)
            {
                if(chkCapturaDefault.Checked)
                    PIniciarCapturaDeCalificacionesEnParcial();
                else
                    PIniciarCapturaDeCalificacionesNoParcial();
            }
        }
        #endregion

        #region BOTONES WEB BROWSER
        private void btnIr_DetallesPagos_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl_DetallesPagos.Text);
        }
        private void btnDetener_DetallesPagos_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }
        private void btnActualizar_DetallesPagos_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        private void btnAtras_DetallesPagos_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
                PEsperarHastaCargarPagina();
                txtUrl_DetallesPagos.Text = webBrowser1.Url.ToString();
            }
        }
        private void btnAdelante_DetallesPagos_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
                PEsperarHastaCargarPagina();
                txtUrl_DetallesPagos.Text = webBrowser1.Url.ToString();
            }
        }
        #endregion

        #region PROCEDIMIENTOS
        private void PEsperarHastaCargarPagina()
        {
            bool loadFinished = false;
            webBrowser1.DocumentCompleted += delegate { loadFinished = true; };
            while (!loadFinished)
            {
                System.Threading.Thread.Sleep(100);
                Application.DoEvents();
            }
        }
        private void PCargarArchivoExcel(string strRutaArchivo)
        {
            //---------------------------------------------------------
            //*** LEER NOMBRE DE HOJAS DEL DOC DE EXCEL ************************************************************
            //---------------------------------------------------------

            #region CON INTEROP
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strRutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                cmbHojas.Items.Clear();

                foreach (Excel.Worksheet xlWorkSheet in xlWorkBook.Worksheets)
                {
                    this.cmbHojas.Items.Add(xlWorkSheet.Name);
                }

                lblExcelSeleccionado.Text = xlWorkBook.Name;

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();

            }
            catch (Exception error)
            {
                lblExcelSeleccionado.Text = "";
                MessageBox.Show("Se produjo un error.\n" + error.Message, "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            #endregion

            #region CON OLEDB
            /*
            OleDbConnection con = null;
            try
            {
                //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strRutaArchivo + ";Extended Properties=Excel 8.0;";
                //NO JALA -- string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strRutaArchivo + ";";
                //string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strRutaArchivo + ";Persist Security Info=False;";
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + strRutaArchivo + ";Extended Properties=Excel 12.0 Xml;";
                //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strRutaArchivo + ";Extended Properties=Excel 12.0;";
                con = new OleDbConnection(connectionString);
                con.Open();
                DataTable tablas = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                con.Close();
                int noHojas = 0;
                string strNomHoja = "";
                foreach (DataRow row in tablas.Rows)
                {
                    strNomHoja = row[2].ToString().Trim();
                    string strSub = strNomHoja.Substring(strNomHoja.Length - 1, 1);
                    if (string.Compare(strSub, "_") != 0)
                    {
                        this.cmbHojas.Items.Add(strNomHoja);
                    }
                }

                if (noHojas > 0)
                {
                    this.cmbHojas.Text = "";
                    this.cmbHojas.SelectedIndex = 0;
                }
            }

            catch (Exception error)
            {
                MessageBox.Show("Se produjo un error.\n" + error.Message, "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (con != null)
                    if (con.State == ConnectionState.Open)
                        con.Close();
            }

            //---------------------------------------------------------
            //*** LEER NOMBRE DE COLUMNAS DE UNA HOJA DEL DEL DOC DE EXCEL ************************************************************
            //---------------------------------------------------------

            //try
            //{

            //   DataTable columns;

            //   string[] restrictions = { null, null, this.txtTabla.Text, null };

            //   DbConnection connection = factory.CreateConnection();

            //   //string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + strRutaArchivo + ";Extended Properties=Excel 8.0;";

            //   string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;" +
            //      @"Data Source=" + strRutaArchivo + ";" +
            //      @"Extended Properties=" + '"' + "Excel 8.0;HDR=YES" + '"';

            //   connection.ConnectionString = connectionString;

            //   connection.Open();

            //   columns = connection.GetSchema("Columns", restrictions);

            //   this.dataGridView1.DataSource = columns;

            //}

            //catch (Exception)
            //{

            //   MessageBox.Show("Se produjo un error. Puede ser que la hoja de calculo a abrir no exista o posea un esquema diferente.");

            //}
             * */
            #endregion
        }
        private void PIniciarCapturaDeCalificacionesEnParcial()
        {
            if (webBrowser1.Document != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (webBrowser1.Document.Window.Frames[1].Document.Window.Frames[0].Document != null)
                    {
                        if (webBrowser1.Document.Window.Frames[1].Document.Window.Frames[0].Document.GetElementsByTagName("Table")[2] != null)
                        {
                            string strHoja = cmbHojas.SelectedItem.ToString();
                            int cantColumnas;
                            int cantCajas = PGetCantidadDeCajas(oFD.FileName, strHoja, out cantColumnas);
                            PGetTablaDeCalificaciones(oFD.FileName, strHoja);
                            string strCalif = "";

                            HtmlElementCollection cajas = webBrowser1.Document.Window.Frames[1].Document.Window.Frames[0].Document
                                                            .GetElementsByTagName("Table")[2].GetElementsByTagName("input");

                            int contCajas = 1;
                            int jColumna = 0;
                            foreach (HtmlElement input in cajas)
                            {
                                if (input.GetAttribute("type") == "text")
                                {
                                    if (jColumna < cantColumnas)
                                    {
                                        strCalif = PGetCalificacion(contCajas);
                                        if (strCalif == "")
                                            throw new Exception("Se encontró una calificación no asignada. Asegúrese de tener todas las calificaciones en la hoja de excel seleccionada.");
                                        
                                        int intCalif;
                                        if (strCalif == "NC" || strCalif == "NA" || int.TryParse(strCalif, out intCalif))
                                            ;
                                        else
                                            throw new Exception("Se encontró una calificación que no es numérica ni NC o NA. Verifique las calificaciones en la hoja de excel seleccionada.");
                                        
                                        input.SetAttribute("value", strCalif.ToString());

                                        contCajas++;
                                        jColumna++;
                                    }
                                    else
                                        jColumna = 0;
                                }
                            }

                            //==========================================================
                            //              VERSION ANTERIOR 1.0
                            //==========================================================
                            //for (int i = 1; i <= cantCajas; i++)
                            //{
                            //    HtmlElement caja = webBrowser1.Document.Window.Frames[1].Document.Window.Frames[0].Document.GetElementById("Caja" + i);
                            //    if (caja != null)
                            //    {
                            //        strCalif = PGetCalificacion(i);
                            //        caja.SetAttribute("value", strCalif);
                            //    }
                            //    else
                            //    {//no encontró la caja
                            //        MessageBox.Show("Verifique que este en la página web de captura de calificaciones adecuada. Error: no encontró la Caja" + i + ".", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return;
                            //    }
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Verifique que este en la página web de captura de calificaciones. Error: no encontró la tabla de captura.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Verifique que este en la página web de captura de calificaciones. Error: no encontró el documento HTML de captura.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning); 
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Error al intentar capturar calificaciones.\n\n" + ex2.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Verifique que este en la página web de captura de calificaciones. Error: no pudo obtener el documento HTML.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void PIniciarCapturaDeCalificacionesNoParcial()
        {
            if (webBrowser1.Document != null)
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (webBrowser1.Document.Window.Frames[0].Document != null)
                    {
                        if (webBrowser1.Document.Window.Frames[0].Document.GetElementsByTagName("Table")[2] != null)
                        {
                            string strHoja = cmbHojas.SelectedItem.ToString();
                            int cantColumnas;
                            int cantCajas = PGetCantidadDeCajas(oFD.FileName, strHoja, out cantColumnas);
                            PGetTablaDeCalificaciones(oFD.FileName, strHoja);
                            string strCalif = "";

                            HtmlElementCollection cajas = webBrowser1.Document.Window.Frames[0].Document.GetElementsByTagName("Table")[2].GetElementsByTagName("input");

                            int contCajas = 1;
                            int jColumna = 0;
                            foreach (HtmlElement input in cajas)
                            {
                                if (input.GetAttribute("type") == "text")
                                {
                                    if (jColumna < cantColumnas)
                                    {
                                        strCalif = PGetCalificacion(contCajas);
                                        if (strCalif == "")
                                            throw new Exception("Se encontró una calificación no asignada. Asegúrese de tener todas las calificaciones en la hoja de excel seleccionada.");

                                        int intCalif;
                                        if (strCalif == "NC" || strCalif == "NA" || int.TryParse(strCalif, out intCalif))
                                            ;
                                        else
                                            throw new Exception("Se encontró una calificación que no es numérica ni NC o NA. Verifique las calificaciones en la hoja de excel seleccionada.");

                                        input.SetAttribute("value", strCalif.ToString());

                                        contCajas++;
                                        jColumna++;
                                    }
                                    else
                                        jColumna = 0;
                                }
                            }

                            //==========================================================
                            //              VERSION ANTERIOR 1.0
                            //==========================================================
                            //for (int i = 1; i <= cantCajas; i++)
                            //{
                            //    HtmlElement caja = webBrowser1.Document.Window.Frames[1].Document.Window.Frames[0].Document.GetElementById("Caja" + i);
                            //    if (caja != null)
                            //    {
                            //        strCalif = PGetCalificacion(i);
                            //        caja.SetAttribute("value", strCalif);
                            //    }
                            //    else
                            //    {//no encontró la caja
                            //        MessageBox.Show("Verifique que este en la página web de captura de calificaciones adecuada. Error: no encontró la Caja" + i + ".", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            //        return;
                            //    }
                            //}
                        }
                        else
                        {
                            MessageBox.Show("Verifique que este en la página web de captura de calificaciones. Error: no encontró la tabla de captura.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Verifique que este en la página web de captura de calificaciones. Error: no encontró el documento HTML de captura.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex2)
                {
                    MessageBox.Show("Error al intentar capturar calificaciones.\n\n" + ex2.Message);
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }
            }
            else
            {
                MessageBox.Show("Verifique que este en la página web de captura de calificaciones. Error: no pudo obtener el documento HTML.", "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private string PGetCalificacion(int item)
        {
            #region CON INTEROP
            string strResultado = "";

            try
            {
                int columna = item % columnas;
                int fila = item / columnas;

                if (columna > 0)
                    columna--;
                else
                {
                    columna = columnas - 1;
                    fila--;
                }

                strResultado = calificaciones[fila,columna].ToString().Trim();
            }
            catch (Exception error)
            {
                MessageBox.Show("Se produjo un error.\n" + error.Message, "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Error);
                strResultado = "";
            }
            return strResultado;
            #endregion
        }
        private int PGetCantidadDeCajas(string strRutaArchivo, string strHoja, out int cantColumnas)
        {
            #region CON INTEROP
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Range range;

            cantColumnas = 0;
            int resultado = 0;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strRutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                int i = 1;
                foreach (Excel.Worksheet xlWs in xlWorkBook.Worksheets)
                {
                    if (xlWs.Name == strHoja)
                        break;
                    i++;
                }
                
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i);

                range = xlWorkSheet.UsedRange;

                resultado = (range.Rows.Count - 1) * range.Columns.Count; //resto una fila, por la fila del texto de las columnas
                cantColumnas = range.Columns.Count;

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
            }
            catch (Exception error)
            {
                MessageBox.Show("Se produjo un error.\n" + error.Message, "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return resultado;
            #endregion
        }
        private void PGetTablaDeCalificaciones(string strRutaArchivo, string strHoja)
        {
            #region CON INTEROP
            Excel.Application xlApp = null;
            Excel.Workbook xlWorkBook = null;
            Excel.Worksheet xlWorkSheet = null;
            Excel.Range range;

            //string str = "";
            int rCnt = 0;
            int cCnt = 0;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(strRutaArchivo, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                int i = 1;
                foreach (Excel.Worksheet xlWs in xlWorkBook.Worksheets)
                {
                    if (xlWs.Name == strHoja)
                        break;
                    i++;
                }

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(i);

                range = xlWorkSheet.UsedRange;

                filas = range.Rows.Count;
                columnas = range.Columns.Count;

                calificaciones = new string[filas, columnas];
                object objAux = null;
                
                //comenzamos en la 2da fila
                for (rCnt = 2; rCnt <= filas; rCnt++)
                {
                    for (cCnt = 1; cCnt <= columnas; cCnt++)
                    {
                        objAux = (range.Cells[rCnt, cCnt] as Excel.Range).Value;

                        calificaciones[rCnt-2,cCnt-1] = objAux.ToString();
                    }
                }

                xlWorkBook.Close(true, null, null);
                xlApp.Quit();
            }
            catch (Exception error)
            {
                MessageBox.Show("Se produjo un error.\n" + error.Message, "Captura de Calificaciones CONECBU", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            #endregion
        }
        private void releaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Unable to release the Object. \n" + ex.Message);
            }
            finally
            {
                GC.Collect();
            }
        } 
        #endregion

        #region EVENTOS GRAL
        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if ((int)e.MaximumProgress > 0)
            {
                if ( (int)e.CurrentProgress <= (int)e.MaximumProgress)
                    toolStripProgressBar1.Value = ((int)e.CurrentProgress / (int)e.MaximumProgress) * 100;
                else
                    toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            }
            else
                toolStripProgressBar1.Value = 0;
        }
        #endregion
    }
}
